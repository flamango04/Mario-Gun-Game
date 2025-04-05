using Microsoft.Xna.Framework;
using Sprint_2.Constants;
using Sprint_2.GameObjects.Misc;
using Sprint_2.Interfaces;
using Sprint_2.MarioPhysicsStates;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.Commands.MarioCollisionCommands
{
    public class MarioCollideTopMovingPlatform : ICommands
    {
        private IPlayer mario;
        private ICollideable collideable;
        private Rectangle collisionRect;

        private int height;

        public MarioCollideTopMovingPlatform(IPlayer mario, ICollideable collideable, Rectangle collisionRect)
        {
            this.mario = mario;
            this.collideable = collideable;
            this.collisionRect = collisionRect;

            height = collisionRect.Height;
        }

        public void Execute()
        {
            MoveablePlatform platform = (MoveablePlatform)collideable;
            if (mario.isFalling)
            {
                mario.YPos -= height;
                mario.Idle();
                mario.PhysicsState = new Grounded(mario);
               
            }
            else if (!mario.isJumping)
            {
                // Moves mario along with the platform
                mario.XPos += platform.GetSpeed();

                mario.YPos -= height;
                mario.PlayerVelocity = new Vector2(mario.PlayerVelocity.X, MarioPhysicsConstants.gravity);
            }
        } 
    }
}
