using Microsoft.Xna.Framework;
using Sprint_2.Constants;
using Sprint_2.LevelManager;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.GameObjects.Enemies.BowserClasses
{
    public class BowserFlippedBehavior : Interfaces.IUpdateable
    {
        private Bowser bowser;
        private Vector2 velocity;

        public BowserFlippedBehavior(Bowser bowser)
        {
            this.bowser = bowser;
            velocity = bowser.Velocity;
            GameObjectManager.Instance.Movers.Remove(bowser);
            velocity = new Vector2(0, ItemPhysicsConstants.bounceVelocity);
        }

        public void Update(GameTime gameTime)
        {
            if (velocity.Y < EnemyConstants.maxFallVelocity)
            {
                velocity += EnemyConstants.fallVelocity;
            }
            bowser.YPos += (float)(velocity.Y * gameTime.ElapsedGameTime.TotalSeconds);

            if (bowser.YPos > MiscConstants.despawnHeight)
            {
                DeleteBowser();
            }
        }

        private void DeleteBowser()
        {
            GameObjectManager.Instance.ForeDrawables.Remove(bowser);
            GameObjectManager.Instance.Updateables.Remove(bowser);
        }
    }
}
