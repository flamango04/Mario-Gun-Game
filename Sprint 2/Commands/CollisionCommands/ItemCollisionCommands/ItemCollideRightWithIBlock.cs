using Microsoft.Xna.Framework;
using Sprint_2.Interfaces;


namespace Sprint_2.Commands.CollisionCommands.ItemCollisionCommands
{
    public class ItemCollideRightWithIBlock : ICommands
    {
        private ICollideable block;
        private IItem item;
        private Rectangle collisionIntersection;

        public ItemCollideRightWithIBlock(IItem item, ICollideable block,  Rectangle collisionIntersection)
        {
            this.block = block;
            this.item = item;
            this.collisionIntersection = collisionIntersection;
        }

        public void Execute()
        {
            item.XPos -= collisionIntersection.Width;
            item.ChangeDirection();
        }
    }
}
