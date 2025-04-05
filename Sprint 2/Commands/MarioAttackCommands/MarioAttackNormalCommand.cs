using Microsoft.Xna.Framework.Graphics;
using Sprint_2.Interfaces;
using Sprint_2.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Sprint_2.Commands.MarioAttackCommands
{
    public class MarioAttackNormalCommand : ICommands
    {
        private IPlayer mario;

        public MarioAttackNormalCommand(IPlayer player)
        {
            mario = player;
        }

        public void Execute()
        {
            mario = Game1.Instance.mario;
            mario.ShootFireball();
        }
    }
}
