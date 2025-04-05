using Microsoft.Xna.Framework;
using Sprint_2.GameObjects.Enemies.BowserClasses;
using Sprint_2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.Commands.CollisionCommands.EnemyCollisionCommands
{
    public class BowserHurtCommand : ICommands
    {
        private Bowser bowser;
        private ICollideable collideable;
        private Rectangle collisionRect;

        public BowserHurtCommand(Bowser bowser, ICollideable collideable, Rectangle collisionRect)
        {
            this.bowser = bowser;
            this.collideable = collideable;
            this.collisionRect = collisionRect;
        }

        public void Execute()
        {
            bowser.TakeFireballDamage();
        }
    }
}
