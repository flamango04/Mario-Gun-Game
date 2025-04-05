using Microsoft.Xna.Framework;
using Sprint_2.GameObjects.Misc;
using Sprint_2.Interfaces;
using Sprint_2.LevelManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.Commands.CollisionCommands.Misc
{
    public class DeleteAxeCommand : ICommands
    {
        private Axe axe;
        private ICollideable collideable;
        private Rectangle collisionRect;

        public DeleteAxeCommand(Axe axe, ICollideable collideable, Rectangle collisionRect)
        {
            this.axe = axe;
            this.collideable = collideable;
            this.collisionRect = collisionRect;
        }

        public void Execute()
        {
            GameObjectManager.Instance.RemoveStatic(axe);
        }
    }
}
