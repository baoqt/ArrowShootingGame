using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    class ArrowInTarget : AnimatedObjects
    {
        private bool targetHit0;
        private bool targethit1;
        private bool targethit2;

        public ArrowInTarget()
        {
            targetHit0 = false;
            targethit1 = false;
            targethit2 = false;
        }
        public override void Draw(Arrow arrow, mainWindow mainWindow)
        {
            // ArrowInTarget0.Visible = targetHit0;
            // ArrowInTarget1.Visible = targetHit1;
            // ArrowInTarget2.Visible = targetHit2;
        }

        public override void Update(Arrow arrow, mainWindow mainWindow)
        {
            switch (Target.Hit(arrow))
            {
                case 0:
                    targetHit0 = true;
                    break;
                case 1:
                    targethit1 = true;
                    break;
                case 2:
                    targethit2 = true;
                    break;
                default:
                    Reset(mainWindow);
                    break;
            }
        }

        public override void Reset(mainWindow mainWindow)
        {
            targetHit0 = false;
            targethit1 = false;
            targethit2 = false;
        }
    }
}
