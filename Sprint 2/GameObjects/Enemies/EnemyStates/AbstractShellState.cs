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
    public abstract class AbstractShellState : IShellState
    {
        private Shell shell;

        protected AbstractShellState(Shell shell)
        {
            this.shell = shell;
        }

        public abstract void Update(GameTime gameTime);

        public void UpdatePosition(GameTime gameTime)
        {
            /* Happens no matter what state */
            if (shell.Velocity.Y < EnemyConstants.maxFallVelocity)
            {
                shell.Velocity += EnemyConstants.fallVelocity;
            }
            shell.Velocity = new Vector2(shell.Velocity.X, shell.Velocity.Y * MarioPhysicsConstants.velocityDecay);

            shell.XPos += (float)(shell.Velocity.X * gameTime.ElapsedGameTime.TotalSeconds);
            shell.YPos += (float)(shell.Velocity.Y * gameTime.ElapsedGameTime.TotalSeconds);

            if (shell.YPos > MiscConstants.despawnHeight)
            {
                GameObjectManager.Instance.Movers.Remove(shell);
                GameObjectManager.Instance.Updateables.Remove(shell);
                GameObjectManager.Instance.BackDrawables.Remove(shell);
            }
        }
    }
}
