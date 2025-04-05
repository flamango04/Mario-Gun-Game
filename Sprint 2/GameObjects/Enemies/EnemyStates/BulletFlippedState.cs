using Microsoft.Xna.Framework;
using Sprint_2.Constants;
using Sprint_2.GameObjects.Enemies.EnemySprites;
using Sprint_2.Interfaces;
using Sprint_2.LevelManager;
using Sprint_2.Sprites.EnemySprites;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.GameObjects.Enemies.EnemyStates
{
    public class BulletFlippedState : AbstractBulletState
    {
        private BulletBill bullet;

        public BulletFlippedState(BulletBill bullet) : base(bullet)
        {
            this.bullet = bullet;
        }

        public override void RunBehavior(GameTime gameTime)
        {
            bullet.YPos += (float)(bullet.Velocity.Y * gameTime.ElapsedGameTime.TotalSeconds);
            bullet.Velocity = new Vector2(bullet.Velocity.X, bullet.Velocity.Y * MarioPhysicsConstants.velocityDecay);

            if (bullet.Velocity.Y < EnemyConstants.maxFallVelocity)
            {
                bullet.Velocity += EnemyConstants.fallVelocity;
            }

            if (bullet.YPos > MiscConstants.despawnHeight)
            {
                GameObjectManager.Instance.Updateables.Remove(bullet);
                GameObjectManager.Instance.BackDrawables.Remove(bullet);
            }
        }
    }
}

