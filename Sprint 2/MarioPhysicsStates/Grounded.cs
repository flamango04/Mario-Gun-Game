using Microsoft.Xna.Framework;
using Sprint_2.Interfaces;
using Sprint_2.Constants;
using Sprint_2.Sprites;
using System.Diagnostics;
using System;

namespace Sprint_2.MarioPhysicsStates
{
    public class Grounded : IMarioPhysicsStates
    {
        private IPlayer mario;
        private float originalYPos;
        public Grounded(IPlayer mario)
        {
            this.mario = mario;
            this.mario.PlayerVelocity = new Vector2(this.mario.PlayerVelocity.X, 0);
            originalYPos = this.mario.YPos;
        }

        public void Update(GameTime gameTime)
        {
            if (mario.PlayerVelocity.X > -MarioPhysicsConstants.maxSlideVelocity && mario.PlayerVelocity.X < MarioPhysicsConstants.maxSlideVelocity)
            {
                if (!mario.isCrouching)
                {
                    mario.Idle();
                }

            }
            if (mario.PlayerVelocity.Y < MarioPhysicsConstants.maxFallVelocity)
            {
                mario.PlayerVelocity += MarioPhysicsConstants.marioFallVelocity;
            }

            mario.XPos += (int)(mario.PlayerVelocity.X * gameTime.ElapsedGameTime.TotalSeconds);
            mario.YPos += (int)(mario.PlayerVelocity.Y * gameTime.ElapsedGameTime.TotalSeconds);

            mario.PlayerVelocity *= MarioPhysicsConstants.velocityDecay;

            if (mario.PlayerVelocity.Y > MarioPhysicsConstants.fallRange)
            {
                mario.Fall();
            }
            
            
        }
    }
}
