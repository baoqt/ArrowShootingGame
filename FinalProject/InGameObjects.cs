using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    abstract class InGameObjects
    {
        /// <summary>
        /// All objects in game need to be updated
        /// as time goes on or user input changes.
        /// All objects also need to be reset whenever
        /// an arrow's flight finishes or the game
        /// finishes.
        /// </summary>
        public abstract void Reset();
    }
}
