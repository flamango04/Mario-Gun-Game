using Microsoft.Xna.Framework;
using Sprint_2.Constants;
using Sprint_2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.Commands.CollisionCommands.Fireball
{
    public class FireballBounceCommand : ICommands
    {
        private IProjectile fireball;
        private ICollideable block;
        private Rectangle collisionRectangle;

        public FireballBounceCommand(IProjectile fireball, ICollideable block, Rectangle collisionRectangle)
        {
            this.fireball = fireball;
            this.block = block;
            this.collisionRectangle = collisionRectangle;
        }

        public void Execute() 
        {
            fireball.YPos -= collisionRectangle.Height;
            fireball.Speed = new Vector2(fireball.Speed.X, FireBallConstants.bounceSpeed);
        }
    }
}
