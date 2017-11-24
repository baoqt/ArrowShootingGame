using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    abstract class BackgroundObjects : InGameObjects
    {
        /// <summary>
        /// Background processes update without any parameters.
        /// Background processes need to report their status.
        /// </summary>
        /// <returns></returns>
        public abstract void Update();
        public abstract override string ToString();
    }
}
