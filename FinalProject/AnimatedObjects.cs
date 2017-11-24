using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    abstract class AnimatedObjects : InGameObjects
    {
        /// <summary>
        /// Animated objects need to be periodically
        /// drawn on the screen depending on their current
        /// locations.
        /// Animated objects need to update based on arrow
        /// stats.
        /// </summary>
        public abstract void Draw(int xPos, int yPos);
        public abstract void Update(Arrow arrow);
    }
}
