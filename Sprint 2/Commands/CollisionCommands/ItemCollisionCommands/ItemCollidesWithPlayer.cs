using Microsoft.Xna.Framework;
using Sprint_2.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.Commands.CollisionCommands.ItemCollisionCommands
{
    public class ItemCollidesWithPlayer : ICommands
    {
        private IItem item;
        private IPlayer player;
        private Rectangle collisionIntersection;

        public ItemCollidesWithPlayer(IItem item, IPlayer player, Rectangle collisionIntersection)
        {
            this.item = item;
            this.player = player;
            this.collisionIntersection = collisionIntersection;
        }

        public void Execute()
        {
            item.DeleteItem();
        }

    }
}
