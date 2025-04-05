using Microsoft.Xna.Framework;
using Sprint_2.Constants;
using Sprint_2.GameObjects.Enemies.EnemySprites;
using Sprint_2.Interfaces;
using Sprint_2.LevelManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.GameObjects.Enemies.EnemyStates
{
    public class ShellFlippedState : AbstractShellState
    {
        private Shell shell;

        public ShellFlippedState(Shell shell) : base(shell)
        {
            this.shell = shell;
        }

        public override void Update(GameTime gameTime)
        {
            if (shell.YPos > MiscConstants.despawnHeight)
            {
                GameObjectManager.Instance.Movers.Remove(shell);
                GameObjectManager.Instance.Updateables.Remove(shell);
                GameObjectManager.Instance.BackDrawables.Remove(shell);
            }
            UpdatePosition(gameTime);
        }

    }
}
