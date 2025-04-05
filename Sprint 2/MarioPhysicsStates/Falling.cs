using Microsoft.Xna.Framework;
using Sprint_2.Interfaces;
using Sprint_2.Constants;


namespace Sprint_2.MarioPhysicsStates
{
    public class Falling : IMarioPhysicsStates
    {
        private IPlayer mario;
        private int originalPlayerHeight;
        public Falling(IPlayer mario)
        {
            this.mario = mario;
            this.mario.isJumping = false;
            this.mario.isFalling = true;
            this.mario.PlayerVelocity = new Vector2(this.mario.PlayerVelocity.X, 0);

        }

        public void Update(GameTime gameTime)
        {
            if (mario.PlayerVelocity.Y < MarioPhysicsConstants.maxFallVelocity)
            {
                mario.PlayerVelocity += MarioPhysicsConstants.marioFallVelocity;
            }

            mario.YPos += (int)(mario.PlayerVelocity.Y * gameTime.ElapsedGameTime.TotalSeconds);
            mario.XPos += (int)(mario.PlayerVelocity.X * gameTime.ElapsedGameTime.TotalSeconds);
            mario.PlayerVelocity *= MarioPhysicsConstants.velocityDecay;
        }
    }
}
