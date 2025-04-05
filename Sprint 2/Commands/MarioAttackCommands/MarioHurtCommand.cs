using Microsoft.Xna.Framework.Graphics;
using Sprint_2.Sprites;
using Sprint_2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Diagnostics;
using Microsoft.Xna.Framework;

namespace Sprint_2.Commands.MarioAttackCommands
{
    public class MarioHurtCommand : ICommands
    {
        private IPlayer mario;

        public MarioHurtCommand(IPlayer mario, ICollideable enemy, Rectangle collisionRect)
        {
            this.mario = mario;
        }

        public void Execute()
        {
            /* If statement only added so StarMario can not take damage when forcibly making mario take damage */
            mario = Game1.Instance.mario;
            if (!mario.GetCollisionType().Equals(typeof(StarMario).Name))
            {
                mario.Damage();
            }
            
        }
    }
}
