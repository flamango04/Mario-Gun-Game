using Microsoft.Xna.Framework;
using Sprint_2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.Commands.CollisionCommands.ItemCollisionCommands
{
    public class ItemCollideLeftWithIBlock : ICommands
    {
        private IItem item;
        private ICollideable block;
        private Rectangle collisionRectangle;

        public ItemCollideLeftWithIBlock(IItem item, ICollideable block, Rectangle collisionRectangle)
        {
            this.item = item;
            this.block = block;
            this.collisionRectangle = collisionRectangle;
        }

        public void Execute()
        {
            item.XPos += collisionRectangle.Width;
            item.ChangeDirection();
        } 
    }
}
