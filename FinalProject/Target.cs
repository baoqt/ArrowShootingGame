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
    static class Target
    {
        /// <summary>
        /// Static class holds the positions of the targets.
        /// They don't move in this game so there's no reason
        /// to make or remake them anyway.
        /// </summary>
        private const double target1XPos = 2.5;
        private const double target1YPos = 1.0;
        private const double target1ZPos = 25.0;
        private const double target2XPos = 7.5;
        private const double target2YPos = 1.1;
        private const double target2ZPos = 100.0;
        private const double target3XPos = 5.0;
        private const double target3YPos = 1.0;
        private const double target3ZPos = 295.0;

        /// <summary>
        /// Function returns the number of the target
        /// hit or 0 if no target is hit as an int.
        /// </summary>
        /// <param name="var">Arrow to be checked</param>
        /// <returns>Which target was hit as an int</returns>
        public static int Hit(Arrow var)
        {
            if (Math.Abs(var.YPos - target1YPos) <= 1.0)
            {
                if (Math.Abs(var.ZPos - target1ZPos) <= 0.5)
                {
                    if (Math.Abs(var.XPos - target1XPos) <= (1.0 - Math.Sin(Math.Abs(var.YPos - target1YPos))))
                    {
                        return 0;
                    }
                }
            }
            if (Math.Abs(var.YPos - target2YPos) <= 1.0)
            {
                if (Math.Abs(var.ZPos - target2ZPos) <= 0.5)
                {
                    if (Math.Abs(var.XPos - target2XPos) <= (1.0 - Math.Sin(Math.Abs(var.YPos - target2YPos))))
                    {
                        return 1;
                    }
                }
            }
            if (Math.Abs(var.YPos - target3YPos) <= 1.0)
            {
                if (Math.Abs(var.ZPos - target3ZPos) <= 0.5)
                {
                    if (Math.Abs(var.XPos - target3XPos) <= (1.0 - Math.Sin(Math.Abs(var.YPos - target3YPos))))
                    {
                        return 2;
                    }
                }
            }
            return -1;
        }
    }
}
