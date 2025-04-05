using Microsoft.Xna.Framework;
using Sprint_2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.GameObjects.Enemies.BowserClasses
{
    public class BowserPatrolBehavior : Interfaces.IUpdateable
    {
        private Bowser bowser;
        private float leftMostXPos;
        private float rightMostXPos;

        private bool movingLeft;
        public BowserPatrolBehavior(Bowser bowser)
        {
            this.bowser = bowser;
            (float, float) bounds = bowser.GetMaxPatrolBounds();
            this.leftMostXPos = bounds.Item1;
            this.rightMostXPos = bounds.Item2;
            if (bowser.Velocity.X < 0)
            {
                movingLeft = true;
            }
            else
            {
                movingLeft = false;
            }

        }

        public void Update(GameTime gameTime)
        {
            if (bowser.XPos <= leftMostXPos)
            {
                bowser.XPos = leftMostXPos;
                movingLeft = false;
                bowser.Velocity *= new Vector2(-1, 1);
            }
            else if (bowser.XPos >= rightMostXPos)
            {
                bowser.XPos = rightMostXPos;
                movingLeft = true;
                bowser.Velocity *= new Vector2(-1, 1);
            }
            bowser.XPos += (float)(bowser.Velocity.X * gameTime.ElapsedGameTime.TotalSeconds);
        }
    }
}
