using Microsoft.Xna.Framework;
using Sprint_2.Constants;
using Sprint_2.GameObjects.Enemies.EnemySprites;
using Sprint_2.Interfaces;
using Sprint_2.Sprites.EnemySprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.GameObjects.Enemies.EnemyStates
{
    public class BulletMovingState : AbstractBulletState
    {
        private BulletBill bullet;
       
        public BulletMovingState(BulletBill bullet) : base(bullet)
        {
            this.bullet = bullet;
        }

        public override void RunBehavior(GameTime gameTime)
        {
            bullet.Move();
        }
    }
}
