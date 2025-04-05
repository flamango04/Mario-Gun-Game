using Microsoft.Xna.Framework;
using Sprint_2.Factories;
using Sprint_2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.Commands.CollisionCommands.Fireball
{
    public class FireballExplodeCommand : ICommands
    {
        private IProjectile fireball;
        private ICollideable collider;
        private Rectangle collisionRect;

        public FireballExplodeCommand(IProjectile fireball, ICollideable collider, Rectangle collisionRect)
        {
            this.fireball = fireball;
            this.collider = collider;
            this.collisionRect = collisionRect;
        }

        public void Execute() 
        {
            fireball.ChangeSprite(UniversalSpriteFactory.Instance.MarioFireballExplosion());
            fireball.EnteredExplosionState = true;
        }
    }
}
