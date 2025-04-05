using Microsoft.Xna.Framework;
using Sprint_2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.Commands.CollisionCommands.EnemyCollisionCommands
{
    public class EnemyCollidesWithEnemy : ICommands
    {
        private IEnemy enemy1;
        private IEnemy enemy2;
        private Rectangle collisionRect;

        public EnemyCollidesWithEnemy(IEnemy enemy1, IEnemy enemy2, Rectangle collisionRect)
        {
            this.enemy1 = enemy1;
            this.enemy2 = enemy2;
            this.collisionRect = collisionRect;
        }
        public void Execute()
        {
            enemy1.XPos -= collisionRect.Width;
            enemy1.ChangeDirection();
            enemy2.ChangeDirection();
        }
    }
}
