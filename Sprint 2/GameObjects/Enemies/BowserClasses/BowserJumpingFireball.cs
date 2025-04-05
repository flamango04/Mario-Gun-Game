using Microsoft.Xna.Framework;
using Sprint_2.Constants;
using Sprint_2.Interfaces;

namespace Sprint_2.GameObjects.Enemies.BowserClasses
{
    public class BowserJumpingFireball : Interfaces.IUpdateable
    {
        private Bowser bowser;
        private Interfaces.IUpdateable bowserFireballBehavior;
        private Vector2 velocity;

        public BowserJumpingFireball(Bowser bowser, bool facingLeft, IPlayer mario)
        {
            this.bowser = bowser;
            bowser.SetIsJumping(true);

            this.bowser.Velocity = new Vector2(bowser.Velocity.X, ItemPhysicsConstants.bounceVelocity);
            velocity = this.bowser.Velocity;

            bowserFireballBehavior = new BowserStandingFireball(bowser, facingLeft, mario);
        }

        public void Update(GameTime gameTime)
        {
            if (velocity.Y < EnemyConstants.maxFallVelocity)
            {
                velocity += EnemyConstants.bowserFallVelocity;
            }
            bowser.YPos += (float)(velocity.Y * gameTime.ElapsedGameTime.TotalSeconds);

            bowserFireballBehavior.Update(gameTime);
        }
    }
}
