using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    static class Wind
    {
        private static double xMag;
        private static double zMag;
        private static Random range = new Random();

        /// <summary>
        /// Static class handles the random wind.
        /// Updates are done only when needed, and
        /// there's only one wind so no need to new
        /// one up.
        /// </summary>
        public static double XMag
        {
            get
            {
                return xMag;
            }
        }

        public static double ZMag
        {
            get
            {
                return zMag;
            }
        }

        /// <summary>
        /// Function updates the wind stats based
        /// on random rolls.
        /// Small changes are kind of annoying already
        /// so don't let it blow too strong or change
        /// too quickly.
        /// </summary>
        public static void UpdateWind()
        {
            int xRoll = range.Next(10);
            int zRoll = range.Next(10);
            int xDirec = range.Next(2);
            int zDirec = range.Next(2);
            double xChange = 0.0;
            double zChange = 0.0;

            if (xRoll > 7)
            {
                xChange = 0.2;
            }
            else if (xRoll > 4)
            {
                xChange = 0.1;
            }
            else if (xRoll > 2)
            {
                xChange = 0.05;
            }

            if (zRoll > 7)
            {
                zChange = 1.5;
            }
            else if (zRoll > 4)
            {
                zChange = 0.75;
            }
            else if (zRoll > 2)
            {
                zChange = 0.25;
            }

            if ((xDirec == 0) &&(xMag <= 100))
            {
                xMag += xChange;
            }
            else if ((xDirec == 1) && (xMag >= -100))
            {
                xMag -= xChange;
            }

            if ((zDirec == 0) && (zMag <= 100))
            {
                zMag += xChange;
            }
            else if ((zDirec == 1) && (zMag >= -100))
            {
                zMag -= zChange;
            }
        }

        /// <summary>
        /// Called when a game is finished or user quits.
        /// Resets the wind for the next game.
        /// </summary>
        public static void ResetWind()
        {
            xMag = 0.0;
            zMag = 0.0;
        }
    }
}
