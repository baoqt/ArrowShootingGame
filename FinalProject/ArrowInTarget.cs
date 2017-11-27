using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace FinalProject
{
    class ArrowInTarget : AnimatedObjects
    {
        private bool targetHit0;
        private bool targetHit1;
        private bool targetHit2;

        public ArrowInTarget()
        {
            targetHit0 = false;
            targetHit1 = false;
            targetHit2 = false;
        }

        public bool TargetHit0
        {
            get
            {
                return targetHit0;
            }
        }

        public bool TargetHit1
        {
            get
            {
                return targetHit1;
            }
        }

        public bool TargetHit2
        {
            get
            {
                return targetHit2;
            }
        }

        /// <summary>
        /// Function draws the stuck arrow in the right spot.
        /// </summary>
        /// <param name="arrow"></param>
        /// <param name="mainWindow"></param>
        public override void Draw(Arrow arrow, mainWindow mainWindow)
        {
            if (targetHit0)
            {
                mainWindow.StuckArrowPictureBox0.Location = new Point(164, 236);
            }
            if (targetHit1)
            {
                mainWindow.StuckArrowPictureBox1.Location = new Point(460, 175);
            }
            if (targetHit2)
            {
                mainWindow.StuckArrowPictureBox2.Location = new Point(380, 133);
            }
        }

        /// <summary>
        /// Function checks if any flags need to be set, then draws
        /// the new screen based on that.
        /// </summary>
        /// <param name="arrow"></param>
        /// <param name="mainWindow"></param>
        public override void Update(Arrow arrow, mainWindow mainWindow)
        {
            switch (Target.Hit(arrow))
            {
                case 0:
                    targetHit0 = true;
                    break;
                case 1:
                    targetHit1 = true;
                    break;
                case 2:
                    targetHit2 = true;
                    break;
            }

            Draw(arrow, mainWindow);
        }

        /// <summary>
        /// Function just sticks the arrows in despite any
        /// angle, effectively cheating the game.
        /// </summary>
        /// <param name="mainWindow"></param>
        public void Cheat(mainWindow mainWindow)
        {
            if (!targetHit0)
            {
                mainWindow.StuckArrowPictureBox0.Location = new Point(164, 236);
                targetHit0 = true;
            }
            else if (!targetHit1)
            {
                mainWindow.StuckArrowPictureBox1.Location = new Point(460, 175);
                targetHit1 = true;
            }
            else
            {
                mainWindow.StuckArrowPictureBox2.Location = new Point(380, 133);
                targetHit2 = true;
            }  
        }

        /// <summary>
        /// Function resets all objects and flags.
        /// </summary>
        /// <param name="mainWindow"></param>
        public override void Reset(mainWindow mainWindow)
        {
            targetHit0 = false;
            mainWindow.StuckArrowPictureBox0.Location = new Point(1000, 1000);
            targetHit1 = false;
            mainWindow.StuckArrowPictureBox1.Location = new Point(1000, 1000);
            targetHit2 = false;
            mainWindow.StuckArrowPictureBox2.Location = new Point(1000, 1000);
        }
    }
}
