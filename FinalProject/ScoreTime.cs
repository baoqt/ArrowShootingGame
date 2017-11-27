using System;
using System.Collections.Generic;
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
/// </summary>
namespace FinalProject
{
    class ScoreTime : BackgroundObjects
    {
        private int seconds;
        private int minutes;
        private int hours;
        private string name;

        /// <summary>
        /// Public constructor.
        /// There's probably a better way to do this using a built in timer.
        /// </summary>
        public ScoreTime()
        {
            seconds = 0;
            minutes = 0;
            hours = 0;
            name = string.Empty;
        }

        /// <summary>
        /// Public accessors.
        /// </summary>
        public int Seconds
        {
            get
            {
                return seconds;
            }
        }
        public int Minutes
        {
            get
            {
                return minutes;
            }
        }
        public int Hours
        {
            get
            {
                return hours;
            }
        }

        /// <summary>
        /// Called every second.
        /// </summary>
        public override void Update()
        {
            if (seconds == 59)
            {
                seconds = 0;
                minutes++;

                if (minutes == 59)
                {
                    minutes = 0;
                    hours++;
                }
            }
            else
            {
                seconds++;
            }
        }

        /// <summary>
        /// Function inserts new high score if it beats any of the current ones.
        /// Otherwise it just tells the user he won.
        /// </summary>
        /// <param name="lines"></param>
        /// <param name="mainWindow"></param>
        public void RecordScore(ref string[] lines, mainWindow mainWindow)
        {
            int lineIndex = 1;
            int linePushIndex = lines.Length - 1;

            for (lineIndex = 1; lineIndex < lines.Length; lineIndex++)
            {
                if (string.Compare(lines[lineIndex].Substring(lines[lineIndex].Length - 8), ToString()) > 0)
                {
                    string userName = Microsoft.VisualBasic.Interaction.InputBox("New high score!", "Enter your name.", "NAME", 1080, 620);
                    while (linePushIndex > lineIndex)
                    {
                        lines[linePushIndex] = lines[linePushIndex - 1];
                        linePushIndex--;
                    }

                    lines[lineIndex] = $"{userName} {ToString()}";
                    System.IO.File.WriteAllLines(@"highscores.txt", lines);

                    return;
                }
            }

            DialogResult winScreen = MessageBox.Show($"Your score is {ToString()}", "Winner!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Called when the game finishes or the user quits.
        /// </summary>
        public override void Reset()
        {
            seconds = 0;
            minutes = 0;
            hours = 0;
        }

        /// <summary>
        /// For recording the user score after a finished game.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{hours:00}:{minutes:00}:{seconds:00}";
        }
    }
}
