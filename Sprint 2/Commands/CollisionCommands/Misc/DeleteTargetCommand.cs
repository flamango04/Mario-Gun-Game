using Microsoft.Xna.Framework;
using Sprint_2.GameObjects;
using Sprint_2.GameObjects.Misc;
using Sprint_2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.Commands.CollisionCommands.Misc
{
    public class DeleteTargetCommand : ICommands
    {
        private Target target;
        private Bullet bullet;
        private Rectangle collisionRect;
        private IPlayer mario;

        public DeleteTargetCommand(Target target, Bullet bullet, Rectangle collisionRect)
        {
            this.target = target;
            this.bullet = bullet;
            this.collisionRect = collisionRect;

            mario = Game1.Instance.mario;
        }

        public void Execute()
        {
            target.DeleteTarget();
            HUD.Instance.AddScorePopUp(200, target.GetLocation());
            mario.isJumping = false;
            mario.isFalling = false;
            
        }
    }
}
