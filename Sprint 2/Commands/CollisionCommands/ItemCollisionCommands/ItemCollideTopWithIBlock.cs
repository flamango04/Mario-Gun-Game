using Microsoft.Xna.Framework;
using Sprint_2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.Commands.CollisionCommands.ItemCollisionCommands
{
    
    public class ItemCollideTopWithIBlock : ICommands
    {
        private IItem item;
        private ICollideable block;
        private Rectangle collisionIntersection;

        public ItemCollideTopWithIBlock(IItem item, ICollideable block, Rectangle collisionIntersection)
        {
            this.item = item;
            this.block = block;
            this.collisionIntersection = collisionIntersection;
        }

        public void Execute()
        {
            item.YPos -= collisionIntersection.Height;
            item.Velocity = new Vector2(item.Velocity.X, 0);
        }
    }
}
