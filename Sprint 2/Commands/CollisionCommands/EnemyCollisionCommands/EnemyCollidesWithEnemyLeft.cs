using Microsoft.Xna.Framework;
using Sprint_2.Interfaces;


namespace Sprint_2.Commands.CollisionCommands.EnemyCollisionCommands
{
    public class EnemyCollidesWithEnemyLeft : ICommands
    {
        private IEnemy enemy1;
        private IEnemy enemy2;
        private Rectangle collisionRect;

        public EnemyCollidesWithEnemyLeft(IEnemy enemy1, IEnemy enemy2, Rectangle collisionRect)
        {
            this.enemy1 = enemy1;
            this.enemy2 = enemy2;
            this.collisionRect = collisionRect;
        }

        public void Execute() 
        {
            enemy1.ChangeDirection();
            enemy1.XPos += collisionRect.Width;
        }
    }
}
