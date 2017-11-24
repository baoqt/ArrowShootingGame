using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    class ArrowInFlight : AnimatedObjects
    {
        private int[,] flightPath0;
        private int[,] flightPath1;
        private int[,] flightPath2;
        private int xIndex;

        public ArrowInFlight()
        {
            flightPath0 = new int[,] { { 1, 2, 3, 4, 5 },
                                       { 1, 2, 3, 4, 5 } };
            flightPath1 = new int[,] { { 1, 2, 3, 4, 5 },
                                       { 1, 2, 3, 4, 5 } };
            flightPath2 = new int[,] { { 1, 2, 3, 4, 5 },
                                       { 1, 2, 3, 4, 5 } };
            xIndex = 0;
        } 

        public override void Draw(int xPos, int yPos)
        {
            // ArrowInFlight.Position = newPosition;
            // ArrowInFlight.Visible = true;
        }

        public override void Update(Arrow arrow)
        {
            if (DetermineFlightPath(arrow) == -1)
            {
                Reset();
            }
            else
            {
                switch (DetermineFlightPath(arrow))
                {
                    case 0:
                        Draw(flightPath0[0, xIndex], flightPath0[1, xIndex]);
                        break;
                    case 1:
                        Draw(flightPath1[0, xIndex], flightPath1[1, xIndex]);
                        break;
                    case 2:
                        Draw(flightPath2[0, xIndex], flightPath2[1, xIndex]);
                        break;
                    default:
                        Reset();
                        break;
                }
                xIndex++;
            }
        }

        public override void Reset()
        {
            xIndex = 0;
            // ArrowInFlight.Visible = false;
            // ArrowInFlight.Position = origin;
        }

        /// <summary>
        /// Function returns which flight path to use
        /// based on starting angle. Sets it to -1 if
        /// angle is somehow out of bounds.
        /// </summary>
        /// <param name="arrow"></param>
        private int DetermineFlightPath(Arrow arrow)
        {
            if (arrow.XAngle <= 135 && arrow.XAngle > 105)
            {
                return 0;
            }
            else if (arrow.XAngle <= 105 && arrow.XAngle > 75)
            {
                return 1;
            }
            else if (arrow.XAngle <= 75 && arrow.XAngle >= 45)
            {
                return 2;
            }

            return -1;
        }
    }
}
