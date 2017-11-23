using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        public mainWindow()
        {
            InitializeComponent();
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
            string[] lines = new string[11] { "HIGHSCORES",
                                              "\n",
                                              "AAA 00:00:00",
                                              "\n",
                                              "BBB 00:00:01",
                                              "\n",
                                              "CCC 00:00:02",
                                              "\n",
                                              "DDD 00:00:03",
                                              "\n",
                                              "EEE 00:00:04" };

            try
            {
                lines = System.IO.File.ReadAllLines(@"highscores.txt");
            }
            catch (System.IO.FileNotFoundException)
            {
                System.IO.File.WriteAllLines(@"highscores.txt", lines);
            }

            ScoresLabel.Text = "";
            foreach (string line in lines)
            {
                if (scoreIndex < 22)
                {
                    ScoresLabel.Text += line + "\n";
                    scoreIndex++;
                }
            }

            BackgroundPictureBox.Visible = false;
            ScoresControlPanel.Visible = true;
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
            WindBackgroundWorker.CancelAsync();
            ScoreTimer.Enabled = false;
            Wind.ResetWind();
            scoreTime.ResetTime();
            ScoreTimerLabel.Text = "00:00:00";
            ArrowPositionBackgroundWorker.CancelAsync();
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
            angleReading.Text = $"Starting Angle: {arrow.XAngle}°, {arrow.YAngle}° [X, Y]";
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
            angleReading.Text = $"Starting Angle: {arrow.XAngle}°, {arrow.YAngle}° [X, Y]";
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
            angleReading.Text = $"Starting Angle: {arrow.XAngle}°, {arrow.YAngle}° [X, Y]";
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
            angleReading.Text = $"Starting Angle: {arrow.XAngle}°, {arrow.YAngle}° [X, Y]";
        }

        /// <summary>
        /// Calls the fire function from arrow class,
        /// starting the arrow's flight.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fireButton_Click(object sender, EventArgs e)
        {
            arrow.Fire();
            ArrowPositionBackgroundWorker.RunWorkerAsync();
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
                    arrow.Fire();
                    ArrowPositionBackgroundWorker.RunWorkerAsync();
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
            scoreTime.IncrementTime();
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
            while (!arrow.Redrawn)
            {
                if (worker.CancellationPending == true)
                {
                    e.Cancel = true;
                    break;
                }
                else if (!arrow.Stationary)
                {
                    arrow.UpdateStats();
                    worker.ReportProgress(0);
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
                                     $"Hit: {Target.Hit(arrow)}";
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
        }
    }
}
