using Microsoft.Xna.Framework;
using Sprint_2.Interfaces;
using Sprint_2.Sprites.EnemySprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.GameObjects.Enemies.EnemyStates
{
    public abstract class AbstractGoombaBehavior : IGoombaBehavior
    {
        private Goomba goomba;

        public AbstractGoombaBehavior(Goomba goomba)
        {
            this.goomba = goomba;
        }

        public void Update(GameTime gameTime)
        {
            RunBehavior(gameTime);
        }

        public abstract void RunBehavior(GameTime gameTime);
    }
}
