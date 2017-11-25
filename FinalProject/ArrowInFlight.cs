using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

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
            flightPath0 = new int[,] { { 174, 2, 3, 4, 5 },
                                       { 233, 2, 3, 4, 5 } };
            flightPath1 = new int[,] { { 174, 242, 312, 350, 362 },
                                       { 233, 151, 120, 106, 109 } };
            flightPath2 = new int[,] { { 174, 2, 3, 4, 5 },
                                       { 233, 2, 3, 4, 5 } };
            xIndex = 0;
        } 

        public override void Draw(Arrow arrow, mainWindow mainWindow)
        {
            switch (DetermineFlightPath(arrow))
            {
                case -1:
                    Reset(mainWindow);
                    break;
                case 0:
                    mainWindow.ArrowInFlightPictureBox.Location = new Point(flightPath0[0, xIndex], flightPath0[1, xIndex]);
                    break;
                case 1:
                    mainWindow.ArrowInFlightPictureBox.Location = new Point(flightPath1[0, xIndex], flightPath1[1, xIndex]);
                    break;
                case 2:
                    mainWindow.ArrowInFlightPictureBox.Location = new Point(flightPath2[0, xIndex], flightPath2[1, xIndex]);
                    break;
                default:
                    Reset(mainWindow);
                    break;
            }
        }

        public override void Update(Arrow arrow, mainWindow mainWindow)
        {
            if (DetermineFlightPath(arrow) == -1)
            {
                Reset(mainWindow);
            }
            else
            {
                switch (xIndex)
                {
                    case 0:
                        switch (DetermineFlightPath(arrow))
                        {
                            case 0:
                                break;
                            case 1:
                                mainWindow.ArrowInFlightPictureBox.Image = Properties.Resources.ArrowInFlight_Path1_0;
                                break;
                            case 2:
                                break;
                            default:
                                Reset(mainWindow);
                                break;
                        }
                        Draw(arrow, mainWindow);
                        xIndex++;
                        break;
                    case 1:
                        switch (DetermineFlightPath(arrow))
                        {
                            case 0:
                                break;
                            case 1:
                                mainWindow.ArrowInFlightPictureBox.Image = Properties.Resources.ArrowInFlight_Path1_1;
                                break;
                            case 2:
                                break;
                            default:
                                Reset(mainWindow);
                                break;
                        }
                        Draw(arrow, mainWindow);
                        xIndex++;
                        break;
                    case 2:
                        switch (DetermineFlightPath(arrow))
                        {
                            case 0:
                                break;
                            case 1:
                                mainWindow.ArrowInFlightPictureBox.Image = Properties.Resources.ArrowInFlight_Path1_2;
                                break;
                            case 2:
                                break;
                            default:
                                Reset(mainWindow);
                                break;
                        }
                        Draw(arrow, mainWindow);
                        xIndex++;
                        break;
                    case 3:
                        switch (DetermineFlightPath(arrow))
                        {
                            case 0:
                                break;
                            case 1:
                                mainWindow.ArrowInFlightPictureBox.Image = Properties.Resources.ArrowInFlight_Path1_3;
                                break;
                            case 2:
                                break;
                            default:
                                Reset(mainWindow);
                                break;
                        }
                        Draw(arrow, mainWindow);
                        xIndex++;
                        break;
                    case 4:
                        switch (DetermineFlightPath(arrow))
                        {
                            case 0:
                                break;
                            case 1:
                                mainWindow.ArrowInFlightPictureBox.Image = Properties.Resources.ArrowInFlight_Path1_4;
                                break;
                            case 2:
                                break;
                            default:
                                Reset(mainWindow);
                                break;
                        }
                        Draw(arrow, mainWindow);
                        xIndex++;
                        break;
                    default:
                        Reset(mainWindow);
                        mainWindow.ArrowInFlightPictureBox.Image = Properties.Resources.ArrowInFlight_Path1_0;
                        break;
                }
            }
        }

        public override void Reset(mainWindow mainWindow)
        {
            xIndex = 0;
            mainWindow.ArrowInFlightPictureBox.Visible = false;
            mainWindow.ArrowInFlightPictureBox.Location = new Point(flightPath0[0, 0], flightPath0[1, 0]);
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
