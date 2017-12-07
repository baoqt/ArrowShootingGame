using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/// <summary>
/// Name: Bao Tran
/// RedID: 818209256
/// Date: 10.28.2017
/// This assignment was completed from:
/// Memory
/// MSDN page on backgroundworker
/// MSDN page on timers
/// </summary>

namespace FinalProject
{
    public partial class mainWindow : Form
    {
        /// <summary>
        /// Arrow is an object in case I want to have
        /// multiple arrows at once for some reason.
        /// ScoreTime is an object too so I can have
        /// a collection of scores to read/write to json
        /// or something.
        /// </summary>
        Arrow arrow = new Arrow();
        ScoreTime scoreTime = new ScoreTime();
        ArrowInFlight arrowInFlight = new ArrowInFlight();
        ArrowInTarget arrowInTarget = new ArrowInTarget();
        string[] scores = new string[6] { "HIGHSCORES",
                                          "AAA 99:00:00",
                                          "BBB 99:00:01",
                                          "CCC 99:00:02",
                                          "DDD 99:00:03",
                                          "EEE 99:00:04" };
        string[] config = new string[2] { "difficulty: 0",
                                          "cheat: 0" };

        public mainWindow()
        {
            InitializeComponent();
            BowAnimationPictureBox.Parent = BackgroundPictureBox;
            ArrowInFlightPictureBox.Parent = BowAnimationPictureBox;
            StuckArrowPictureBox0.Parent = BowAnimationPictureBox;
            StuckArrowPictureBox1.Parent = BowAnimationPictureBox;
            StuckArrowPictureBox2.Parent = BowAnimationPictureBox;

            try
            {
                scores = System.IO.File.ReadAllLines(@"highscores.txt");
            }
            catch (System.IO.FileNotFoundException)
            {
                System.IO.File.WriteAllLines(@"highscores.txt", scores);
            }

            try
            {
                config = System.IO.File.ReadAllLines(@"config.txt");
            }
            catch (System.IO.FileNotFoundException)
            {
                System.IO.File.WriteAllLines(@"config.txt", config);
            }

            if (config[0].Substring(12, 1).Equals("1"))
            {
                if (!WindBackgroundWorker.IsBusy)
                {
                    WindBackgroundWorker.RunWorkerAsync();
                }
            }
            if (config[1].Substring(7, 1).Equals("1"))
            {
                CheatsButton.Text = "Enable Cheats (All shots hit)";
            }
        }

        /// <summary>
        /// playButton Initializes the game UI, the 
        /// wind, and score. It also displays the 
        /// initial arrow stats in the UI.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void playButton_Click(object sender, EventArgs e)
        {
            gameControlPanel.Visible = true;
            BowAnimationPictureBox.Visible = true;
            ScoreTimer.Enabled = true;
            ArrowPositionTest.Text = $"{arrow.XPos:0.000}, {arrow.YPos:0.000}, {arrow.ZPos:0.000} [X, Y, Z]\n" +
                                     $"{arrow.xVel:0.000}, {arrow.yVel:0.000}, {arrow.zVel:0.000} [X, Y, Z]\n" +
                                     $"{arrow.xAcc:0.000}, {arrow.yAcc:0.000}, {arrow.zAcc:0.000} [X, Y, Z]\n";
        }
        /// <summary>
        /// scoreButton lets the user check high scores.
        /// Pulls the current high scores from a text file.
        /// Creates a new file if it doesn't exist.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void scoreButton_Click(object sender, EventArgs e)
        {
            int scoreIndex = 0;

            ScoresLabel.Text = "";
            foreach (string line in scores)
            {
                if (scoreIndex < 22)
                {
                    ScoresLabel.Text += line + "\n";
                    scoreIndex++;
                }
            }

            BackgroundPictureBox.Visible = false;
            ScoresControlPanel.Visible = true;
            ScoresLabel.Visible = true;
        }

        /// <summary>
        /// settingsButton lets the user enable/disable
        /// the wind.
        /// Calls up a new panel for settings UI.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void settingsButton_Click(object sender, EventArgs e)
        {
            SettingsPanel.Visible = true;
        }

        /// <summary>
        /// quitButton fully exits the game.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void quitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// This quitButton just quits the current game, taking user
        /// back to the main menu.
        /// It disables game mechanics like wind and score and resets
        /// them. Also makes the game UI invisible.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void quitGameButton_Click(object sender, EventArgs e)
        {
            gameControlPanel.Visible = false;
            BowAnimationPictureBox.Visible = false;
            WindBackgroundWorker.CancelAsync();
            ScoreTimer.Enabled = false;
            Wind.ResetWind();
            scoreTime.Reset();
            ScoreTimerLabel.Text = "00:00:00";
            ArrowPositionBackgroundWorker.CancelAsync();
            arrowInTarget.Reset(this);
        }

        /// <summary>
        /// Adjusts the arrow angle up by a degree.
        /// Also updates the angle stats on the UI.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void upButton_Click(object sender, EventArgs e)
        {
            arrow.ChangeAngle("up");
            angleReading.Text = $"Starting Angle: {arrow.XAngle}°, {90.0 + (90.0 - arrow.YAngle)}° [X, Y]";
        }

        /// <summary>
        /// Adjusts the arrow angle right by a degree.
        /// Also updates the angle stats on the UI.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rightButton_Click(object sender, EventArgs e)
        {
            arrow.ChangeAngle("right");
            angleReading.Text = $"Starting Angle: {arrow.XAngle}°, {90.0 + (90.0 - arrow.YAngle)}° [X, Y]";
        }

        /// <summary>
        /// Adjusts the arrow angle down by a degree.
        /// Also updates the angle stats on the UI.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void downButton_Click(object sender, EventArgs e)
        {
            arrow.ChangeAngle("down");
            angleReading.Text = $"Starting Angle: {arrow.XAngle}°, {90.0 + (90.0 - arrow.YAngle)}° [X, Y]";
        }

        /// <summary>
        /// Adjusts the arrow angle left by a degree.
        /// Also updats the angle stats on the UI.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void leftButton_Click(object sender, EventArgs e)
        {
            arrow.ChangeAngle("left");
            angleReading.Text = $"Starting Angle: {arrow.XAngle}°, {90.0 + (90.0 - arrow.YAngle)}° [X, Y]";
        }

        /// <summary>
        /// Calls the fire function from arrow class,
        /// starting the arrow's flight.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fireButton_Click(object sender, EventArgs e)
        {
            if (!ArrowInFlightBackgroundWorker.IsBusy && !ArrowPositionBackgroundWorker.IsBusy && !BowAnimationBackgroundWorker.IsBusy)
            {
                if (config[1].Substring(7, 1).Equals("1"))
                {
                    arrowInTarget.Cheat(this);
                }
                arrow.Fire();
                ArrowPositionBackgroundWorker.RunWorkerAsync();
                ArrowInFlightBackgroundWorker.RunWorkerAsync();
                BowAnimationBackgroundWorker.RunWorkerAsync();
                ArrowInFlightPictureBox.Visible = true;
            }
        }

        /// <summary>
        /// All the previous functions but with keyboard shortcuts
        /// instead of mouse clicks.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mainWindow_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (gameControlPanel.Visible)
            {

                if (e.KeyChar == 'w')
                {
                    arrow.ChangeAngle("up");
                }
                else if (e.KeyChar == 'd')
                {
                    arrow.ChangeAngle("right");
                }
                else if (e.KeyChar == 's')
                {
                    arrow.ChangeAngle("down");
                }
                else if (e.KeyChar == 'a')
                {
                    arrow.ChangeAngle("left");
                }
                else if (e.KeyChar == 'f')
                {
                    if (!ArrowInFlightBackgroundWorker.IsBusy && !ArrowPositionBackgroundWorker.IsBusy && !BowAnimationBackgroundWorker.IsBusy)
                    {
                        if (config[1].Substring(7, 1).Equals("1"))
                        {
                            arrowInTarget.Cheat(this);
                        }
                        arrow.Fire();
                        ArrowPositionBackgroundWorker.RunWorkerAsync();
                        ArrowInFlightBackgroundWorker.RunWorkerAsync();
                        BowAnimationBackgroundWorker.RunWorkerAsync();
                        ArrowInFlightPictureBox.Visible = true;
                    }
                }

                angleReading.Text = $"Starting Angle: {arrow.XAngle}°, {90.0 + (90.0 - arrow.YAngle)}° [X, Y]";
            }
        }

        /// <summary>
        /// Calls the wind update function every 2 seconds.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WindBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Random range = new Random();
            BackgroundWorker worker = sender as BackgroundWorker;

            while (true)
            {
                if (worker.CancellationPending == true)
                {
                    e.Cancel = true;
                    break;
                }
                else
                {
                    Wind.UpdateWind();
                    worker.ReportProgress(0);
                    System.Threading.Thread.Sleep(2000);
                }
            }
        }

        /// <summary>
        /// Updates the wind stats UI element.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WindBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            double tempAngle = 0.0;
            
            if (Wind.XMag == 0)
            {
                tempAngle = 90;
            }
            else
            {
                tempAngle = ((Math.Atan(Wind.ZMag / Wind.XMag) / Math.PI) * 180.0);
            }

            if (((Wind.XMag < 0) && (Wind.ZMag >= 0)) || ((Wind.XMag <= 0) && (Wind.ZMag <= 0)))
            {
                tempAngle += 180.0;
            }

            if ((tempAngle < 112.5) && (tempAngle >= 67.5))
            {
                CompassPictureBox.Image = Properties.Resources.CompassNorth;
            }
            else if ((tempAngle < 67.5) && (tempAngle >= 22.5))
            {
                CompassPictureBox.Image = Properties.Resources.CompassNorthEast;
            }
            else if (((tempAngle < 22.5) && (tempAngle >= 0.0)) || (tempAngle < 360.0) && (tempAngle >= 337.5))
            {
                CompassPictureBox.Image = Properties.Resources.CompassEast;
            }
            else if ((tempAngle < 157.5) && (tempAngle >= 112.5))
            {
                CompassPictureBox.Image = Properties.Resources.CompassNorthWest;
            }
            else if ((tempAngle < 202.5) && (tempAngle >= 157.5))
            {
                CompassPictureBox.Image = Properties.Resources.CompassWest;
            }
            else if ((tempAngle < 247.5) && (tempAngle >= 202.5))
            {
                CompassPictureBox.Image = Properties.Resources.CompassSouthWest;
            }
            else if ((tempAngle < 292.5) && (tempAngle >= 247.5))
            {
                CompassPictureBox.Image = Properties.Resources.CompassSouth;
            }
            else if ((tempAngle < 337.5) && (tempAngle >= 292.5))
            {
                CompassPictureBox.Image = Properties.Resources.CompassSouthEast;
            }

            windReading.Text = $"Wind: {Wind.XMag:0.000}m/s, {Wind.ZMag:0.000}m/s [X, Z]";
        }

        /// <summary>
        /// Increases the score tracker every second.
        /// Also updates the UI element.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScoreTimer_Tick(object sender, EventArgs e)
        {
            scoreTime.Update();
            ScoreTimerLabel.Text = $"{scoreTime.Hours:00}:{scoreTime.Minutes:00}:{scoreTime.Seconds:00}";
        }

        /// <summary>
        /// Updates the arrow's stats if it's not stationary.
        /// Keeps doing this until it hits the ground.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ArrowPositionBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            System.Threading.Thread.Sleep(600);

            while (!arrow.Redrawn)
            {
                if (worker.CancellationPending == true)
                {
                    e.Cancel = true;
                    break;
                }
                else if (!arrow.Stationary)
                {
                    arrow.Update();
                    arrowInTarget.Update(arrow, this);
                    worker.ReportProgress(0);

                    if (arrowInTarget.TargetHit0 && arrowInTarget.TargetHit1 && arrowInTarget.TargetHit2)
                    {
                        WindBackgroundWorker.CancelAsync();
                        Wind.ResetWind();
                        ScoreTimer.Enabled = false;
                        scoreTime.RecordScore(ref scores, this);
                        gameControlPanel.Visible = false;
                        BowAnimationPictureBox.Visible = false;
                        scoreTime.Reset();
                        ScoreTimerLabel.Text = "00:00:00";
                        arrowInTarget.Reset(this);
                    }
                }
                System.Threading.Thread.Sleep(4);
            }
        }

        /// <summary>
        /// Updates the arrow position, velocity, and acceleration stats
        /// on the UI element.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ArrowPositionBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ArrowPositionTest.Text = $"{arrow.XPos:0.000}, {arrow.YPos:0.000}, {arrow.ZPos:0.000} [X, Y, Z]\n" +
                                     $"{arrow.xVel:0.000}, {arrow.yVel:0.000}, {arrow.zVel:0.000} [X, Y, Z]\n" +
                                     $"{arrow.xAcc:0.000}, {arrow.yAcc:0.000}, {arrow.zAcc:0.000} [X, Y, Z]\n" +
                                     $"Hit: {Target.Hit(arrow) + 1}";
        }

        /// <summary>
        /// Disables the wind in gme.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NormalModeButton_Click(object sender, EventArgs e)
        {
            WindBackgroundWorker.CancelAsync();
            Wind.ResetWind();
            windReading.Text = $"Wind: {Wind.XMag:0.000}m/s, {Wind.ZMag:0.000}m/s [X, Z]";
            config[0] = "difficulty: 0";
            System.IO.File.WriteAllLines(@"config.txt", config);
            SettingsPanel.Visible = false;
        }

        /// <summary>
        /// Enables the wind in game.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HardModeButton_Click(object sender, EventArgs e)
        {
            if (!WindBackgroundWorker.IsBusy)
            {
                WindBackgroundWorker.RunWorkerAsync();
            }
            config[0] = "difficulty: 1";
            System.IO.File.WriteAllLines(@"config.txt", config);
            SettingsPanel.Visible = false;
        }

        /// <summary>
        /// Returns from the high score menu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackButton_Click(object sender, EventArgs e)
        {
            BackgroundPictureBox.Visible = true;
            ScoresControlPanel.Visible = false;
            ScoresLabel.Visible = false;
        }

        /// <summary>
        /// Toggle for cheat mode.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheatsButton_Click(object sender, EventArgs e)
        {
            if (CheatsButton.Text == "Enable Cheats (All shots hit)")
            {
                CheatsButton.Text = "Disable Cheats (Normal Shots)";
                config[1] = "cheat: 1";
                System.IO.File.WriteAllLines(@"config.txt", config);
            }
            else
            {
                CheatsButton.Text = "Enable Cheats (All shots hit)";
                config[1] = "cheat: 0";
                System.IO.File.WriteAllLines(@"config.txt", config);
            }
        }

        /// <summary>
        /// Plays the animation of the arrow flying after begin shot.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ArrowInFlightBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            int frameIndex = 0;

            System.Threading.Thread.Sleep(600);

            for (frameIndex = 0; frameIndex < 6; frameIndex++)
            {
                arrowInFlight.Update(arrow, this);
                System.Threading.Thread.Sleep(100);
            }

            ArrowInFlightPictureBox.Location = new Point(1000, 1000);
        }

        /// <summary>
        /// Plays the animation of the bow shooting the arrow.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BowAnimationBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BowAnimationPictureBox.Image = Properties.Resources.BowAnimation_1;
            System.Threading.Thread.Sleep(300);
            BowAnimationPictureBox.Image = Properties.Resources.BowAnimation_2;
            System.Threading.Thread.Sleep(300);
            BowAnimationPictureBox.Image = Properties.Resources.BowAnimation_3;
            System.Threading.Thread.Sleep(300);
            BowAnimationPictureBox.Image = Properties.Resources.BowAnimation_4;
            System.Threading.Thread.Sleep(300);
            BowAnimationPictureBox.Image = Properties.Resources.BowAnimation_0;
        }
        
        /// <summary>
        /// Function opens up the README for the user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                try
                {
                    Process.Start(@"README.txt");
                }
                catch (Win32Exception exception)
                {
                    string[] readmeText = new string[] { "Up, down, left, and right are also bound to 'w', 'a', 's', and 'd', respectively",
                                                         "Fire is also bound to 'f'.",
                                                         " ",
                                                         "Change the starting angle of the arrow to hit the three targets.",
                                                         "The wind option makes this much more difficult.",
                                                         " ",
                                                         "Hint: The targets are at 95, 0",
                                                         "			 90, 95",
                                                         "		     and 89, 93 with the wind disabled." };
                    System.IO.File.WriteAllLines(@"README.txt", readmeText);

                    Process.Start(@"README.txt");
                }
            }
        }
    }
}
