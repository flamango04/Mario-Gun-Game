using Microsoft.Xna.Framework;
using Sprint_2.Constants;
using Sprint_2.Interfaces;
using Sprint_2.LevelManager;
using Sprint_2.Sprites.EnemySprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.GameObjects.Enemies.EnemyStates
{
    public class GoombaBehaviorFlipped : AbstractGoombaBehavior
    {
        private Goomba goomba;

        public GoombaBehaviorFlipped(Goomba goomba) : base(goomba)
        {
            this.goomba = goomba;
        }

        public override void RunBehavior(GameTime gameTime)
        {
            goomba.YPos += (float)(goomba.Velocity.Y * gameTime.ElapsedGameTime.TotalSeconds);
            goomba.Velocity = new Vector2(goomba.Velocity.X, goomba.Velocity.Y * MarioPhysicsConstants.velocityDecay);

            if (goomba.Velocity.Y < EnemyConstants.maxFallVelocity)
            {
                goomba.Velocity += EnemyConstants.fallVelocity;
            }

            if (goomba.YPos > MiscConstants.despawnHeight)
            {
                GameObjectManager.Instance.Updateables.Remove(goomba);
                GameObjectManager.Instance.BackDrawables.Remove(goomba);
            }
        }
    }
}
