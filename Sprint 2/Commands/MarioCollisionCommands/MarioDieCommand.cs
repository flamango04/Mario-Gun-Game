using Microsoft.Xna.Framework;
using Sprint_2.Constants;
using Sprint_2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.Commands.MarioCollisionCommands
{
    public class MarioDieCommand : ICommands
    {
        private IPlayer mario;
        private ICollideable collideable;
        private Rectangle collisionRect;

        public MarioDieCommand(IPlayer mario, ICollideable collideable, Rectangle collisionRect)
        {
            this.mario = mario;
            this.collideable = collideable;
            this.collisionRect = collisionRect;
        }
        public void Execute()
        {
            
            mario.Die();
            mario.PlayerVelocity = new Vector2(0, MarioPhysicsConstants.bounceVelocity);
        }
    }
}
