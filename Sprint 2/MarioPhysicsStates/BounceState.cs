using Microsoft.Xna.Framework;
using Sprint_2.Constants;
using Sprint_2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.MarioPhysicsStates
{
    public class BounceState : IMarioPhysicsStates
    {
        private IPlayer mario;

        public BounceState(IPlayer player)
        {
            this.mario = player;
        }

        public void Update(GameTime gameTime)
        {
            mario.PlayerVelocity += MarioPhysicsConstants.marioFallVelocity;
            mario.YPos += (int)(mario.PlayerVelocity.Y * gameTime.ElapsedGameTime.TotalSeconds);
            mario.XPos += (int)(mario.PlayerVelocity.X * gameTime.ElapsedGameTime.TotalSeconds);

            mario.PlayerVelocity *= MarioPhysicsConstants.velocityDecay;

            /* If max Jump height is reached, make mario fall */
            if (mario.PlayerVelocity.Y > MarioPhysicsConstants.minTransitionToFallState)
            {
                mario.Fall();
            }
        }
    }
}
