using Microsoft.Xna.Framework;
using Sprint_2.GameObjects;
using Sprint_2.Interfaces;
using Sprint_2.Sound;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.Commands.CollisionCommands
{
    public class BlockHitCommand : ICommands
    {
        private ICollideable block;
        private IPlayer player;

        public BlockHitCommand(ICollideable block, IPlayer player, Rectangle rect)
        {
            this.block = block;
            this.player = player;
        }

        public void Execute() 
        {
            if (player.isJumping && block.GetType().Equals(typeof(Block)))
            {

                ((Block)block).BeHit(player);
            }
        }
    }
}
