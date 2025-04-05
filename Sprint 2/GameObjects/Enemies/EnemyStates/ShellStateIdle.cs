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
    public class ShellStateIdle : AbstractShellState
    {
        private Shell shell;
        private float timeUntilShellBecomesAlive;
        public ShellStateIdle(Shell shell) : base(shell)
        {
            timeUntilShellBecomesAlive = EnemyConstants.timeUntilShellBecomesAlive;
            this.shell = shell;
        }
        public override void Update(GameTime gameTime)
        {
            timeUntilShellBecomesAlive -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (timeUntilShellBecomesAlive < 0)
            { 
                GameObjectManager.Instance.Movers.Remove(shell);
                GameObjectManager.Instance.Updateables.Remove(shell);
                GameObjectManager.Instance.BackDrawables.Remove(shell);

                if (shell.GetEnemyType().Equals("Koopa"))
                {
                    Koopa koopa = new Koopa(new Vector2(shell.XPos, shell.YPos - shell.GetHitBox().Height));
                    GameObjectManager.Instance.Movers.Add(koopa);
                    GameObjectManager.Instance.Updateables.Add(koopa);
                    GameObjectManager.Instance.BackDrawables.Add(koopa);
                } else
                {
                    Buzzy buzzy = new Buzzy(new Vector2(shell.XPos, shell.YPos - shell.GetHitBox().Height));
                    GameObjectManager.Instance.Movers.Add(buzzy);
                    GameObjectManager.Instance.Updateables.Add(buzzy);
                    GameObjectManager.Instance.BackDrawables.Add(buzzy);
                }
            }
            UpdatePosition(gameTime);
        }
    }
}
