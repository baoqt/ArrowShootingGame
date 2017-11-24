using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        /// <summary>
        /// Public constructor.
        /// There's probably a better way to do this using a built in timer.
        /// </summary>
        public ScoreTime()
        {
            seconds = 0;
            minutes = 0;
            hours = 0;
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
