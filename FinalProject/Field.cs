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
    static class Field
    {
        private static double xFieldBoundaries = 10.0;
        private static double zFieldBoundaries = 300.0;

        /// <summary>
        /// Function returns whether the arrow is within bounds
        /// of the shooting area as a bool.
        /// </summary>
        /// <param name="var">Arrow to be checked</param>
        /// <returns></returns>
        public static bool OutOfBounds(Arrow var)
        {
            if (((var.XPos > xFieldBoundaries) || (var.XPos < 0)) || var.YPos < 0)/* || (var.ZPos > zFieldBoundaries))*/
            {
                return true;
            }
            return false;
        }
    }
}
