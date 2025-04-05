using Microsoft.Xna.Framework;
using Sprint_2.Interfaces;
using Sprint_2.Sprites;
using Sprint_2.Constants;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.MarioPhysicsStates
{
    public class Jumping : IMarioPhysicsStates
    {
        private IPlayer mario;
        private float originalMarioY;

        public Jumping(IPlayer mario)
        {
            this.mario = mario;
            originalMarioY = mario.YPos;
        }

        public void Update(GameTime gameTime)
        {
            /* Makes mario move upwards until the max jump velocity is achieved */
            if (mario.PlayerVelocity.Y > MarioPhysicsConstants.maxJumpVelocity)
            {
                mario.PlayerVelocity += MarioPhysicsConstants.marioJumpVelocity;
            }

            mario.YPos += (int)(mario.PlayerVelocity.Y * gameTime.ElapsedGameTime.TotalSeconds);
            mario.XPos += (int)(mario.PlayerVelocity.X * gameTime.ElapsedGameTime.TotalSeconds);

            mario.PlayerVelocity *= MarioPhysicsConstants.velocityDecay;

            /* If max Jump height is reached, make mario fall */
            if (Math.Abs(mario.YPos - originalMarioY) > MarioPhysicsConstants.maxJumpHeight)
            {
                mario.Fall();
            }
        }
    }
}
