using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    class ScoreTime
    {
        private int milliseconds;
        private int seconds;
        private int minutes;
        private int hours;

        public ScoreTime()
        {
            milliseconds = 0;
            seconds = 0;
            minutes = 0;
            hours = 0;
        }

        public int Milliseconds
        {
            get
            {
                return milliseconds;
            }
        }
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

        public void IncrementTime()
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

        public void ResetTime()
        {
            milliseconds = 0;
            seconds = 0;
            minutes = 0;
            hours = 0;
        }
    }
}
