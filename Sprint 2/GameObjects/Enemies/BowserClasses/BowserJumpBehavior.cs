using Microsoft.Xna.Framework;
using Sprint_2.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.GameObjects.Enemies.BowserClasses
{
    public class BowserJumpBehavior : Interfaces.IUpdateable
    {
        private Bowser bowser;
        private Vector2 velocity;
        private Interfaces.IUpdateable patrolBehavior;
        public BowserJumpBehavior(Bowser bowser)
        {
            this.bowser = bowser;
            bowser.SetIsJumping(true);

            this.bowser.Velocity = new Vector2(bowser.Velocity.X, ItemPhysicsConstants.bounceVelocity);
            velocity = this.bowser.Velocity;

            patrolBehavior = new BowserPatrolBehavior(bowser);
        }

        public void Update(GameTime gameTime)
        {
            if (velocity.Y < EnemyConstants.maxFallVelocity)
            {
                velocity += EnemyConstants.bowserFallVelocity;
            }
            patrolBehavior.Update(gameTime);
            bowser.YPos += (float)(velocity.Y * gameTime.ElapsedGameTime.TotalSeconds);
        }
    }
}
