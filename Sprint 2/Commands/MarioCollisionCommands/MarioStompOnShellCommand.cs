using Microsoft.Xna.Framework;
using Sprint_2.GameObjects.Enemies.EnemySprites;
using Sprint_2.GameObjects.Enemies.EnemyStates;
using Sprint_2.Interfaces;
using Sprint_2.Sound;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.Commands.MarioCollisionCommands
{
    public class MarioStompOnShellCommand : ICommands
    {
        private IPlayer player;
        private Shell shell;
        private Rectangle collisionRect;

        public MarioStompOnShellCommand(Shell shell, IPlayer player, Rectangle collisionRect)
        {
            this.player = player;
            this.shell = shell;
            this.collisionRect = collisionRect;
        }
        public void Execute()
        {
            if (shell.Velocity.X != 0)
            {
                shell.ShellState = new ShellStateIdle(shell);
                shell.Velocity = Vector2.Zero;
                shell.ResetIndex();

                SoundManager.Instance.PlaySoundEffect("stomp");
            }
        }
    }
}
