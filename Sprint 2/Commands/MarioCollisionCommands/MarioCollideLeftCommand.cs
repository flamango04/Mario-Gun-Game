using Sprint_2.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.Commands.MarioCollisionCommands
{
    public class MarioCollideLeftCommand : ICommands
    {
        private IPlayer mario;
        private int width;
        public MarioCollideLeftCommand(IPlayer player, ICollideable block, Rectangle collisionIntersection)
        {
            mario = player;
            width = collisionIntersection.Width;
        }

        public void Execute()
        {
            mario.XPos += width;
        }
    }
}
