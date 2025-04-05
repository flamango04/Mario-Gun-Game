using Sprint_2.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint_2.Constants;
using Sprint_2.MarioPhysicsStates;
using Sprint_2.Sprites;
using System.Diagnostics;

namespace Sprint_2.Commands.MarioCollisionCommands
{
    public class MarioCollideTopCommand : ICommands
    {
        private IPlayer mario;
        private ICollideable collideable;
        private int height;
        public MarioCollideTopCommand(IPlayer player, ICollideable block, Rectangle collisionIntersection)
        {
            mario = player;
            collideable = block;
            height = collisionIntersection.Height;
        }

        public void Execute()
        {
            /* This check is needed for when mario shoots a target while jumping to prevent him from being stuck in the jump sprite
             when colliding with the ground */
            if (!mario.isFalling && !mario.isJumping && mario.PhysicsState is not Grounded)
            {
                mario.YPos -= height;
                mario.Idle();
                mario.PhysicsState = new Grounded(mario);
            }
            if (mario.isFalling)
            {
                mario.YPos -= height;
                mario.Idle();
                mario.PhysicsState = new Grounded(mario);
            }
            else if (!mario.isJumping)
            {
                mario.YPos -= height;
                mario.PlayerVelocity = new Vector2(mario.PlayerVelocity.X, MarioPhysicsConstants.gravity);
            }
            
        }
    }
}
