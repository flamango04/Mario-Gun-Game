using Microsoft.Xna.Framework;
using Sprint_2.Constants;
using Sprint_2.LevelManager;
using Sprint_2.Sprites.EnemySprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.GameObjects.Enemies.EnemyStates
{
    public class GoombaBehaviorStomped : AbstractGoombaBehavior
    {
        private Goomba goomba;
        private float stompTimer;

        public GoombaBehaviorStomped(Goomba goomba) : base(goomba)
        {
            this.goomba = goomba;
            stompTimer = EnemyConstants.stompTimer;
        }

        public override void RunBehavior(GameTime gameTime)
        {
            stompTimer -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (stompTimer < 0)
            {
                //Remove Goomba from enemies list
                GameObjectManager.Instance.Updateables.Remove(goomba);
                GameObjectManager.Instance.BackDrawables.Remove(goomba);
            }
        }
    }
}
