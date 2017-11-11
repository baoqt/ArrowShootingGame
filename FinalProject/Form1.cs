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
        Arrow arrow = new Arrow();
        ScoreTime scoreTime = new ScoreTime();

        public mainWindow()
        {
            InitializeComponent();
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            gameControlPanel.Visible = true;
            WindBackgroundWorker.RunWorkerAsync();
            ScoreTimer.Enabled = true;
            ArrowPositionTest.Text = $"{arrow.XPos:0.000}, {arrow.YPos:0.000}, {arrow.ZPos:0.000} [X, Y, Z]\n" +
                                     $"{arrow.xVel:0.000}, {arrow.yVel:0.000}, {arrow.zVel:0.000} [X, Y, Z]\n" +
                                     $"{arrow.xAcc:0.000}, {arrow.yAcc:0.000}, {arrow.zAcc:0.000} [X, Y, Z]\n";
        }

        private void scoreButton_Click(object sender, EventArgs e)
        {

        }

        private void settingsButton_Click(object sender, EventArgs e)
        {

        }
        private void quitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

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

        private void upButton_Click(object sender, EventArgs e)
        {
            arrow.ChangeAngle("up");
            angleReading.Text = $"Starting Angle: {arrow.XAngle}°, {arrow.YAngle}° [X, Y]";
        }

        private void rightButton_Click(object sender, EventArgs e)
        {
            arrow.ChangeAngle("right");
            angleReading.Text = $"Starting Angle: {arrow.XAngle}°, {arrow.YAngle}° [X, Y]";
        }

        private void downButton_Click(object sender, EventArgs e)
        {
            arrow.ChangeAngle("down");
            angleReading.Text = $"Starting Angle: {arrow.XAngle}°, {arrow.YAngle}° [X, Y]";
        }

        private void leftButton_Click(object sender, EventArgs e)
        {
            arrow.ChangeAngle("left");
            angleReading.Text = $"Starting Angle: {arrow.XAngle}°, {arrow.YAngle}° [X, Y]";
        }

        private void fireButton_Click(object sender, EventArgs e)
        {
            arrow.Fire();
            ArrowPositionBackgroundWorker.RunWorkerAsync();
        }

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

        private void WindBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            windReading.Text = $"Wind: {Wind.XMag:0.000}m/s, {Wind.ZMag:0.000}m/s [X, Z]";
        }

        private void ScoreTimer_Tick(object sender, EventArgs e)
        {
            scoreTime.IncrementTime();
            ScoreTimerLabel.Text = $"{scoreTime.Hours:00}:{scoreTime.Minutes:00}:{scoreTime.Seconds:00}";
        }

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

        private void ArrowPositionBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ArrowPositionTest.Text = $"{arrow.XPos:0.000}, {arrow.YPos:0.000}, {arrow.ZPos:0.000} [X, Y, Z]\n" +
                                     $"{arrow.xVel:0.000}, {arrow.yVel:0.000}, {arrow.zVel:0.000} [X, Y, Z]\n" +
                                     $"{arrow.xAcc:0.000}, {arrow.yAcc:0.000}, {arrow.zAcc:0.000} [X, Y, Z]\n" +
                                     $"Hit: {Target.Hit(arrow)}";
        }

        private void mainScreen_Click(object sender, EventArgs e)
        {

        }
    }
}
