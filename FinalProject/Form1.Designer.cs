namespace FinalProject
{
    partial class mainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.WindBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.ScoreTimer = new System.Windows.Forms.Timer(this.components);
            this.ArrowPositionBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.mainMenuControlPanel = new System.Windows.Forms.Panel();
            this.mainMenuLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.mainMenuInnerLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.quitButton = new System.Windows.Forms.Button();
            this.playButton = new System.Windows.Forms.Button();
            this.scoreButton = new System.Windows.Forms.Button();
            this.settingsButton = new System.Windows.Forms.Button();
            this.gameControlPanel = new System.Windows.Forms.Panel();
            this.gameLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.gameInnerLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.rightButton = new System.Windows.Forms.Button();
            this.leftButton = new System.Windows.Forms.Button();
            this.ganeInnerLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.downButton = new System.Windows.Forms.Button();
            this.fireButton = new System.Windows.Forms.Button();
            this.upButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.quitGameButton = new System.Windows.Forms.Button();
            this.dataWindow = new System.Windows.Forms.TableLayoutPanel();
            this.angleReading = new System.Windows.Forms.Label();
            this.windReading = new System.Windows.Forms.Label();
            this.CompassPictureBox = new System.Windows.Forms.PictureBox();
            this.ScoreTimerLabel = new System.Windows.Forms.Label();
            this.ArrowPositionTest = new System.Windows.Forms.Label();
            this.BackgroundPictureBox = new System.Windows.Forms.PictureBox();
            this.mainMenuControlPanel.SuspendLayout();
            this.mainMenuLayoutPanel.SuspendLayout();
            this.mainMenuInnerLayoutPanel.SuspendLayout();
            this.gameControlPanel.SuspendLayout();
            this.gameLayoutPanel.SuspendLayout();
            this.gameInnerLayoutPanel.SuspendLayout();
            this.ganeInnerLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.dataWindow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CompassPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BackgroundPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // WindBackgroundWorker
            // 
            this.WindBackgroundWorker.WorkerReportsProgress = true;
            this.WindBackgroundWorker.WorkerSupportsCancellation = true;
            this.WindBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.WindBackgroundWorker_DoWork);
            this.WindBackgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.WindBackgroundWorker_ProgressChanged);
            // 
            // ScoreTimer
            // 
            this.ScoreTimer.Interval = 1000;
            this.ScoreTimer.Tick += new System.EventHandler(this.ScoreTimer_Tick);
            // 
            // ArrowPositionBackgroundWorker
            // 
            this.ArrowPositionBackgroundWorker.WorkerReportsProgress = true;
            this.ArrowPositionBackgroundWorker.WorkerSupportsCancellation = true;
            this.ArrowPositionBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.ArrowPositionBackgroundWorker_DoWork);
            this.ArrowPositionBackgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.ArrowPositionBackgroundWorker_ProgressChanged);
            // 
            // mainMenuControlPanel
            // 
            this.mainMenuControlPanel.Controls.Add(this.mainMenuLayoutPanel);
            this.mainMenuControlPanel.Location = new System.Drawing.Point(821, 0);
            this.mainMenuControlPanel.Margin = new System.Windows.Forms.Padding(0);
            this.mainMenuControlPanel.Name = "mainMenuControlPanel";
            this.mainMenuControlPanel.Size = new System.Drawing.Size(172, 593);
            this.mainMenuControlPanel.TabIndex = 4;
            // 
            // mainMenuLayoutPanel
            // 
            this.mainMenuLayoutPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.mainMenuLayoutPanel.ColumnCount = 1;
            this.mainMenuLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainMenuLayoutPanel.Controls.Add(this.mainMenuInnerLayoutPanel, 0, 1);
            this.mainMenuLayoutPanel.Location = new System.Drawing.Point(15, -4);
            this.mainMenuLayoutPanel.Name = "mainMenuLayoutPanel";
            this.mainMenuLayoutPanel.RowCount = 3;
            this.mainMenuLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.mainMenuLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.mainMenuLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.mainMenuLayoutPanel.Size = new System.Drawing.Size(142, 601);
            this.mainMenuLayoutPanel.TabIndex = 0;
            // 
            // mainMenuInnerLayoutPanel
            // 
            this.mainMenuInnerLayoutPanel.ColumnCount = 1;
            this.mainMenuInnerLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainMenuInnerLayoutPanel.Controls.Add(this.quitButton, 0, 3);
            this.mainMenuInnerLayoutPanel.Controls.Add(this.playButton, 0, 0);
            this.mainMenuInnerLayoutPanel.Controls.Add(this.scoreButton, 0, 1);
            this.mainMenuInnerLayoutPanel.Controls.Add(this.settingsButton, 0, 2);
            this.mainMenuInnerLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainMenuInnerLayoutPanel.Location = new System.Drawing.Point(0, 75);
            this.mainMenuInnerLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.mainMenuInnerLayoutPanel.Name = "mainMenuInnerLayoutPanel";
            this.mainMenuInnerLayoutPanel.RowCount = 4;
            this.mainMenuInnerLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.mainMenuInnerLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.mainMenuInnerLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.mainMenuInnerLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.mainMenuInnerLayoutPanel.Size = new System.Drawing.Size(142, 180);
            this.mainMenuInnerLayoutPanel.TabIndex = 0;
            // 
            // quitButton
            // 
            this.quitButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.quitButton.Location = new System.Drawing.Point(33, 146);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(75, 23);
            this.quitButton.TabIndex = 0;
            this.quitButton.TabStop = false;
            this.quitButton.Text = "Quit";
            this.quitButton.UseVisualStyleBackColor = true;
            this.quitButton.Click += new System.EventHandler(this.quitButton_Click);
            // 
            // playButton
            // 
            this.playButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.playButton.Location = new System.Drawing.Point(33, 11);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(75, 23);
            this.playButton.TabIndex = 1;
            this.playButton.TabStop = false;
            this.playButton.Text = "Play";
            this.playButton.UseVisualStyleBackColor = true;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // scoreButton
            // 
            this.scoreButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.scoreButton.Location = new System.Drawing.Point(33, 56);
            this.scoreButton.Name = "scoreButton";
            this.scoreButton.Size = new System.Drawing.Size(75, 23);
            this.scoreButton.TabIndex = 2;
            this.scoreButton.TabStop = false;
            this.scoreButton.Text = "High Scores";
            this.scoreButton.UseVisualStyleBackColor = true;
            this.scoreButton.Click += new System.EventHandler(this.scoreButton_Click);
            // 
            // settingsButton
            // 
            this.settingsButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.settingsButton.Location = new System.Drawing.Point(33, 101);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(75, 23);
            this.settingsButton.TabIndex = 3;
            this.settingsButton.TabStop = false;
            this.settingsButton.Text = "Settings";
            this.settingsButton.UseVisualStyleBackColor = true;
            this.settingsButton.Click += new System.EventHandler(this.settingsButton_Click);
            // 
            // gameControlPanel
            // 
            this.gameControlPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gameControlPanel.Controls.Add(this.gameLayoutPanel);
            this.gameControlPanel.Location = new System.Drawing.Point(821, 0);
            this.gameControlPanel.Margin = new System.Windows.Forms.Padding(0);
            this.gameControlPanel.Name = "gameControlPanel";
            this.gameControlPanel.Size = new System.Drawing.Size(172, 593);
            this.gameControlPanel.TabIndex = 7;
            this.gameControlPanel.Visible = false;
            // 
            // gameLayoutPanel
            // 
            this.gameLayoutPanel.ColumnCount = 1;
            this.gameLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.gameLayoutPanel.Controls.Add(this.gameInnerLayoutPanel, 0, 1);
            this.gameLayoutPanel.Controls.Add(this.tableLayoutPanel3, 0, 2);
            this.gameLayoutPanel.Controls.Add(this.ScoreTimerLabel, 0, 0);
            this.gameLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gameLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.gameLayoutPanel.Name = "gameLayoutPanel";
            this.gameLayoutPanel.RowCount = 3;
            this.gameLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 175F));
            this.gameLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.gameLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.gameLayoutPanel.Size = new System.Drawing.Size(172, 593);
            this.gameLayoutPanel.TabIndex = 5;
            // 
            // gameInnerLayoutPanel
            // 
            this.gameInnerLayoutPanel.ColumnCount = 3;
            this.gameInnerLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.gameInnerLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.gameInnerLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.gameInnerLayoutPanel.Controls.Add(this.rightButton, 2, 0);
            this.gameInnerLayoutPanel.Controls.Add(this.leftButton, 0, 0);
            this.gameInnerLayoutPanel.Controls.Add(this.ganeInnerLayoutPanel2, 1, 0);
            this.gameInnerLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gameInnerLayoutPanel.Location = new System.Drawing.Point(0, 175);
            this.gameInnerLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.gameInnerLayoutPanel.Name = "gameInnerLayoutPanel";
            this.gameInnerLayoutPanel.RowCount = 1;
            this.gameInnerLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.gameInnerLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.gameInnerLayoutPanel.Size = new System.Drawing.Size(172, 180);
            this.gameInnerLayoutPanel.TabIndex = 0;
            // 
            // rightButton
            // 
            this.rightButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rightButton.Location = new System.Drawing.Point(129, 78);
            this.rightButton.Margin = new System.Windows.Forms.Padding(0);
            this.rightButton.Name = "rightButton";
            this.rightButton.Size = new System.Drawing.Size(43, 23);
            this.rightButton.TabIndex = 2;
            this.rightButton.Text = "Right";
            this.rightButton.UseVisualStyleBackColor = true;
            this.rightButton.Click += new System.EventHandler(this.rightButton_Click);
            // 
            // leftButton
            // 
            this.leftButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.leftButton.Location = new System.Drawing.Point(0, 78);
            this.leftButton.Margin = new System.Windows.Forms.Padding(0);
            this.leftButton.Name = "leftButton";
            this.leftButton.Size = new System.Drawing.Size(43, 23);
            this.leftButton.TabIndex = 1;
            this.leftButton.Text = "Left";
            this.leftButton.UseVisualStyleBackColor = true;
            this.leftButton.Click += new System.EventHandler(this.leftButton_Click);
            // 
            // ganeInnerLayoutPanel2
            // 
            this.ganeInnerLayoutPanel2.ColumnCount = 1;
            this.ganeInnerLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ganeInnerLayoutPanel2.Controls.Add(this.downButton, 0, 2);
            this.ganeInnerLayoutPanel2.Controls.Add(this.fireButton, 0, 1);
            this.ganeInnerLayoutPanel2.Controls.Add(this.upButton, 0, 0);
            this.ganeInnerLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ganeInnerLayoutPanel2.Location = new System.Drawing.Point(43, 0);
            this.ganeInnerLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.ganeInnerLayoutPanel2.Name = "ganeInnerLayoutPanel2";
            this.ganeInnerLayoutPanel2.RowCount = 3;
            this.ganeInnerLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.ganeInnerLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ganeInnerLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.ganeInnerLayoutPanel2.Size = new System.Drawing.Size(86, 180);
            this.ganeInnerLayoutPanel2.TabIndex = 0;
            // 
            // downButton
            // 
            this.downButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.downButton.Location = new System.Drawing.Point(20, 135);
            this.downButton.Margin = new System.Windows.Forms.Padding(0);
            this.downButton.Name = "downButton";
            this.downButton.Size = new System.Drawing.Size(45, 23);
            this.downButton.TabIndex = 2;
            this.downButton.Text = "Down";
            this.downButton.UseVisualStyleBackColor = true;
            this.downButton.Click += new System.EventHandler(this.downButton_Click);
            // 
            // fireButton
            // 
            this.fireButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.fireButton.Location = new System.Drawing.Point(20, 78);
            this.fireButton.Margin = new System.Windows.Forms.Padding(0);
            this.fireButton.Name = "fireButton";
            this.fireButton.Size = new System.Drawing.Size(45, 23);
            this.fireButton.TabIndex = 1;
            this.fireButton.Text = "Fire";
            this.fireButton.UseVisualStyleBackColor = true;
            this.fireButton.Click += new System.EventHandler(this.fireButton_Click);
            // 
            // upButton
            // 
            this.upButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.upButton.Location = new System.Drawing.Point(20, 22);
            this.upButton.Margin = new System.Windows.Forms.Padding(0);
            this.upButton.Name = "upButton";
            this.upButton.Size = new System.Drawing.Size(45, 23);
            this.upButton.TabIndex = 0;
            this.upButton.Text = "Up";
            this.upButton.UseVisualStyleBackColor = true;
            this.upButton.Click += new System.EventHandler(this.upButton_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.quitGameButton, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.dataWindow, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 355);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(172, 238);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // quitGameButton
            // 
            this.quitGameButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.quitGameButton.Location = new System.Drawing.Point(48, 200);
            this.quitGameButton.Margin = new System.Windows.Forms.Padding(0);
            this.quitGameButton.Name = "quitGameButton";
            this.quitGameButton.Size = new System.Drawing.Size(75, 27);
            this.quitGameButton.TabIndex = 0;
            this.quitGameButton.Text = "Quit Game";
            this.quitGameButton.UseVisualStyleBackColor = true;
            this.quitGameButton.Click += new System.EventHandler(this.quitGameButton_Click);
            // 
            // dataWindow
            // 
            this.dataWindow.ColumnCount = 1;
            this.dataWindow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.dataWindow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.dataWindow.Controls.Add(this.angleReading, 0, 0);
            this.dataWindow.Controls.Add(this.windReading, 0, 2);
            this.dataWindow.Controls.Add(this.CompassPictureBox, 0, 1);
            this.dataWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataWindow.Location = new System.Drawing.Point(0, 0);
            this.dataWindow.Margin = new System.Windows.Forms.Padding(0);
            this.dataWindow.Name = "dataWindow";
            this.dataWindow.RowCount = 3;
            this.dataWindow.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.142857F));
            this.dataWindow.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 92.85714F));
            this.dataWindow.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 13F));
            this.dataWindow.Size = new System.Drawing.Size(172, 190);
            this.dataWindow.TabIndex = 1;
            // 
            // angleReading
            // 
            this.angleReading.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.angleReading.AutoSize = true;
            this.angleReading.Location = new System.Drawing.Point(0, 0);
            this.angleReading.Margin = new System.Windows.Forms.Padding(0);
            this.angleReading.Name = "angleReading";
            this.angleReading.Size = new System.Drawing.Size(172, 12);
            this.angleReading.TabIndex = 2;
            this.angleReading.Text = "Starting Angle: 90°, 90° [X, Y]";
            this.angleReading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // windReading
            // 
            this.windReading.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.windReading.AutoSize = true;
            this.windReading.Location = new System.Drawing.Point(0, 177);
            this.windReading.Margin = new System.Windows.Forms.Padding(0);
            this.windReading.Name = "windReading";
            this.windReading.Size = new System.Drawing.Size(172, 13);
            this.windReading.TabIndex = 3;
            this.windReading.Text = "Wind: 0m/s, 0,m/s [X, Z]";
            this.windReading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CompassPictureBox
            // 
            this.CompassPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CompassPictureBox.Location = new System.Drawing.Point(0, 12);
            this.CompassPictureBox.Margin = new System.Windows.Forms.Padding(0);
            this.CompassPictureBox.Name = "CompassPictureBox";
            this.CompassPictureBox.Size = new System.Drawing.Size(172, 164);
            this.CompassPictureBox.TabIndex = 4;
            this.CompassPictureBox.TabStop = false;
            // 
            // ScoreTimerLabel
            // 
            this.ScoreTimerLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ScoreTimerLabel.AutoSize = true;
            this.ScoreTimerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScoreTimerLabel.Location = new System.Drawing.Point(34, 75);
            this.ScoreTimerLabel.Name = "ScoreTimerLabel";
            this.ScoreTimerLabel.Size = new System.Drawing.Size(104, 25);
            this.ScoreTimerLabel.TabIndex = 2;
            this.ScoreTimerLabel.Text = "00:00:00";
            // 
            // ArrowPositionTest
            // 
            this.ArrowPositionTest.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ArrowPositionTest.AutoSize = true;
            this.ArrowPositionTest.Location = new System.Drawing.Point(388, 516);
            this.ArrowPositionTest.Name = "ArrowPositionTest";
            this.ArrowPositionTest.Size = new System.Drawing.Size(79, 13);
            this.ArrowPositionTest.TabIndex = 8;
            this.ArrowPositionTest.Text = "0, 0, 0 [X, Y, Z]";
            this.ArrowPositionTest.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BackgroundPictureBox
            // 
            this.BackgroundPictureBox.Image = global::FinalProject.Properties.Resources.Background;
            this.BackgroundPictureBox.Location = new System.Drawing.Point(9, 9);
            this.BackgroundPictureBox.Margin = new System.Windows.Forms.Padding(0);
            this.BackgroundPictureBox.Name = "BackgroundPictureBox";
            this.BackgroundPictureBox.Size = new System.Drawing.Size(800, 450);
            this.BackgroundPictureBox.TabIndex = 9;
            this.BackgroundPictureBox.TabStop = false;
            // 
            // mainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1001, 601);
            this.Controls.Add(this.BackgroundPictureBox);
            this.Controls.Add(this.ArrowPositionTest);
            this.Controls.Add(this.gameControlPanel);
            this.Controls.Add(this.mainMenuControlPanel);
            this.KeyPreview = true;
            this.MaximumSize = new System.Drawing.Size(1017, 640);
            this.MinimumSize = new System.Drawing.Size(1017, 640);
            this.Name = "mainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Target Shooting";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mainWindow_KeyPress);
            this.mainMenuControlPanel.ResumeLayout(false);
            this.mainMenuLayoutPanel.ResumeLayout(false);
            this.mainMenuInnerLayoutPanel.ResumeLayout(false);
            this.gameControlPanel.ResumeLayout(false);
            this.gameLayoutPanel.ResumeLayout(false);
            this.gameLayoutPanel.PerformLayout();
            this.gameInnerLayoutPanel.ResumeLayout(false);
            this.ganeInnerLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.dataWindow.ResumeLayout(false);
            this.dataWindow.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CompassPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BackgroundPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.ComponentModel.BackgroundWorker WindBackgroundWorker;
        private System.Windows.Forms.Timer ScoreTimer;
        private System.ComponentModel.BackgroundWorker ArrowPositionBackgroundWorker;
        private System.Windows.Forms.Panel mainMenuControlPanel;
        private System.Windows.Forms.TableLayoutPanel mainMenuLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel mainMenuInnerLayoutPanel;
        private System.Windows.Forms.Button quitButton;
        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.Button scoreButton;
        private System.Windows.Forms.Button settingsButton;
        private System.Windows.Forms.Panel gameControlPanel;
        private System.Windows.Forms.TableLayoutPanel gameLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel gameInnerLayoutPanel;
        private System.Windows.Forms.Button rightButton;
        private System.Windows.Forms.Button leftButton;
        private System.Windows.Forms.TableLayoutPanel ganeInnerLayoutPanel2;
        private System.Windows.Forms.Button downButton;
        private System.Windows.Forms.Button fireButton;
        private System.Windows.Forms.Button upButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button quitGameButton;
        private System.Windows.Forms.TableLayoutPanel dataWindow;
        private System.Windows.Forms.Label angleReading;
        private System.Windows.Forms.Label windReading;
        private System.Windows.Forms.PictureBox CompassPictureBox;
        private System.Windows.Forms.Label ScoreTimerLabel;
        private System.Windows.Forms.Label ArrowPositionTest;
        private System.Windows.Forms.PictureBox BackgroundPictureBox;
    }
}

