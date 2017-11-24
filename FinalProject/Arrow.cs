using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Name: Bao Tran
/// RedID: 818209256
/// Date: 10.28.2017
/// Drag eqation, -kV^2, from https://sites.google.com/site/technicalarchery/technical-discussions-1/trajectory
/// </summary>
namespace FinalProject
{
    class Arrow : BackgroundObjects
    {
        private double xPos;
        private double yPos;
        private double zPos;
        private double xAngle;
        private double yAngle;
        public double xVel;
        public double yVel;
        public double zVel;
        public double xAcc;
        public double yAcc;
        public double zAcc;
        private const double Gravity = -9.807;
        private const double DragCoefficient = -0.0026;
        private bool stationary;
        private bool redrawn;

        /// <summary>
        /// Constructor creates an arrow at the center of the field.
        /// Arrow is at rest, having 0 velocity and acceleration.
        /// Gravity is defined as -9.807 m/s^2, where the origin 
        /// of the y axis is at the ground and the positive
        /// direction is up into the sky. It is assumed that
        /// the change in acceleration due to the distance from
        /// the earth is negligible. The arrow is assumed to have
        /// a drag coefficient of -0.0026 1/m.
        /// </summary>
        public Arrow()
        {
            xPos = 5.0;
            yPos = 1.0;
            zPos = 0.0;
            xAngle = 90.0;
            yAngle = 90.0;
            xVel = 0.0;
            yVel = 0.0;
            zVel = 0.0;
            xAcc = 0.0;
            yAcc = 0.0;
            zAcc = 0.0;
            stationary = true;
            redrawn = false;
        }

        /// <summary>
        /// Public accessors of the arrow's current position and angle.
        /// </summary>
        public double XPos {
            get
            {
                return xPos;
            }
        }

        public double YPos {
            get
            {
                return yPos;
            }
        }

        public double ZPos {
            get
            {
                return zPos;
            }
        }

        public double XAngle {
            get
            {
                return xAngle;
            }
        }

        public double YAngle
        {
            get
            {
                return yAngle;
            }
        }

        /// <summary>
        /// Public accessor of the arrow's flight status.
        /// </summary>
        public bool Stationary {
            get
            {
                return stationary;
            }
        }

        public bool Redrawn
        {
            get
            {
                return redrawn;
            }
        }

        /// <summary>
        /// Function updates all stats of the arrow. Should be
        /// called once every 0.004 seconds. Also checks and handles 
        /// if the arrow has gone out of bounds or hit a target.
        /// </summary>
        public override void Update()
        {
            double timeConstant = 0.004;

            xPos += xVel * timeConstant;
            yPos += yVel * timeConstant;
            zPos += zVel * timeConstant;
            xVel += (xAcc + Wind.XMag) * timeConstant;
            yVel += yAcc * timeConstant;
            if ((zVel + ((zAcc + Wind.ZMag) * timeConstant)) > 0) 
            {
                zVel += (zAcc + Wind.ZMag) * timeConstant;
            }
            xAcc += DragCoefficient * Math.Pow(xVel, 2) * timeConstant;
            yAcc += (DragCoefficient * Math.Pow(yVel, 2) + Gravity) * timeConstant;
            zAcc += DragCoefficient * Math.Pow(zVel, 2) * timeConstant;

            if (Field.OutOfBounds(this) || (Target.Hit(this) != -1))
            {
                xVel = 0.0;
                yVel = 0.0;
                zVel = 0.0;
                xAcc = 0.0;
                yAcc = 0.0;
                zAcc = 0.0;
                stationary = true;
                redrawn = true;

                if (Target.Hit(this) != -1)
                {
                    /// DrawStuckArrow(Target.Hit(this), this);
                }
            }
        }

        /// <summary>
        /// Resets the arrow's stats in case of emergency.
        /// </summary>
        public override void Reset()
        {
            xPos = 5.0;
            yPos = 1.0;
            zPos = 0.0;
            xAngle = 90.0;
            yAngle = 90.0;
            xVel = 0.0;
            yVel = 0.0;
            zVel = 0.0;
            xAcc = 0.0;
            yAcc = 0.0;
            zAcc = 0.0;
            stationary = true;
            redrawn = false;
        }

        /// <summary>
        /// Function changes the starting angle of the arrow.
        /// </summary>
        /// <param name="direction">Direction of angle change</param>
        public void ChangeAngle(string direction)
        {
            if (direction.Equals("up"))
            {
                if (yAngle <= 135 && yAngle > 45)
                {
                    yAngle--;
                }
            }
            else if (direction.Equals("right"))
            {
                if (xAngle <= 135 && xAngle > 45)
                {
                    xAngle--;
                }
            }
            else if (direction.Equals("down"))
            {
                if (yAngle < 135 && yAngle >= 45)
                {
                    yAngle++;
                }
            }
            else if (direction.Equals("left"))
            {
                if (xAngle < 135 && xAngle >= 45)
                {
                    xAngle++;
                }
            }
        }

        /// <summary>
        /// Function gives the arrow initial acceleration depending
        /// on the starting angle. Also sets the flight status.
        /// </summary>
        public void Fire()
        {
            if (zPos != 0)
            {
                xPos = 5.0;
                yPos = 1.0;
                zPos = 0.0;
            }
            if (stationary)
            {
                xAcc = 100.0 * Math.Cos((xAngle * Math.PI) / 180.0);
                yAcc = 100.0 * Math.Cos((yAngle * Math.PI) / 180.0);
                zAcc = 100.0 - (100.0 * Math.Abs(Math.Cos((xAngle * Math.PI) / 180.0))) - (100 * Math.Abs(Math.Cos((yAngle * Math.PI) / 180.0)));
                stationary = false;
                redrawn = false;
            }
        }

        /// <summary>
        /// Function for testing, full stats shouldn't be shown in completed game
        /// </summary>
        /// <returns>All stats of the arrow</returns>
        public override string ToString()
        {
            return $"{XPos:0.000}, {YPos:0.000}, {ZPos:0.000} POS[X, Y, Z]\n" +
                   $"{xVel:0.000}, {yVel:0.000}, {zVel:0.000} VEL[X, Y, Z]\n" +
                   $"{xAcc:0.000}, {yAcc:0.000}, {zAcc:0.000} ACC[X, Y, Z]\n";
        }
    }
}
