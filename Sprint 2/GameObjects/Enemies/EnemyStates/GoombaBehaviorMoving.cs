using Microsoft.Xna.Framework;
using Sprint_2.Constants;
using Sprint_2.Sprites.EnemySprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.GameObjects.Enemies.EnemyStates
{
    public class GoombaBehaviorMoving : AbstractGoombaBehavior
    {
        private Goomba goomba;
       
        public GoombaBehaviorMoving(Goomba goomba) : base(goomba)
        {
            this.goomba = goomba;
        }

        public override void RunBehavior(GameTime gameTime)
        {
            goomba.Move();
            if (goomba.Velocity.Y < EnemyConstants.maxFallVelocity)
            {
                goomba.Velocity += EnemyConstants.fallVelocity;
            }

            goomba.YPos += (float)(goomba.Velocity.Y * gameTime.ElapsedGameTime.TotalSeconds);
            goomba.Velocity = new Vector2(goomba.Velocity.X, goomba.Velocity.Y * MarioPhysicsConstants.velocityDecay);
        }
    }
}
