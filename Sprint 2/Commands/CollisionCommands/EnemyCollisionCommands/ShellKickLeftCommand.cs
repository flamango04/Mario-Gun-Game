using Microsoft.Xna.Framework;
using Sprint_2.Constants;
using Sprint_2.GameObjects.Enemies.EnemySprites;
using Sprint_2.GameObjects.Enemies.EnemyStates;
using Sprint_2.Interfaces;
using Sprint_2.Sound;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.Commands.CollisionCommands.EnemyCollisionCommands
{
    public class ShellKickLeftCommand : ICommands
    {
        private Shell shell;
        private IPlayer player;
        private Rectangle collisionIntersection;

        public ShellKickLeftCommand(Shell shell, IPlayer player, Rectangle collisionIntersection)
        {
            this.shell = shell;
            this.player = player;
            this.collisionIntersection = collisionIntersection;
        }
        public void Execute() 
        {
            if (shell.Velocity.X == 0)
            {
                shell.Velocity = new Vector2(-EnemyConstants.shellMoveSpeed, shell.Velocity.Y);
                player.XPos += collisionIntersection.Width;
                shell.ShellState = new MovingShellState(shell);

                HUD.Instance.AddScorePopUp(EnemyConstants.kickShellPoints, new Vector2(shell.XPos, shell.YPos));
                SoundManager.Instance.PlaySoundEffect("stomp");
            }
        }
    }
}
