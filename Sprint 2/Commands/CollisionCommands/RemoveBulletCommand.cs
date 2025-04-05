using Microsoft.Xna.Framework;
using Sprint_2.GameObjects;
using Sprint_2.Interfaces;

namespace Sprint_2.Commands.CollisionCommands
{
    public class RemoveBulletCommand : ICommands
    {
        private Bullet bullet;
        private ICollideable collideable;
        private Rectangle collisionRect;

        public RemoveBulletCommand(Bullet bullet, ICollideable collideable, Rectangle collisionRect)
        {
            this.bullet = bullet;
            this.collideable = collideable;
            this.collisionRect = collisionRect;
        }

        public void Execute()
        {
            bullet.Delete();
        }
    }
}
