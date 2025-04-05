using Microsoft.Xna.Framework;
using Sprint_2.Constants;
using Sprint_2.GameObjects;
using Sprint_2.GameObjects.Enemies.EnemySprites;
using Sprint_2.Interfaces;
using Sprint_2.Sound;
using Sprint_2.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Sprint_2.Commands.CollisionCommands.EnemyCollisionCommands
{
    public class FlipEnemyCommand : ICommands
    {
        private IEnemy enemy;
        private ICollideable collider;
        private Rectangle collisionRect;

        public FlipEnemyCommand(IEnemy enemy, ICollideable collider, Rectangle collisionRect)
        {
            this.enemy = enemy;
            this.collider = collider;
            this.collisionRect = collisionRect;
        }
        public void Execute()
        {
            if (enemy is not Buzzy && !(enemy is Shell && ((Shell)enemy).GetEnemyType() == "Buzzy"))
            {
                if (collider is StarMario)
                {
                    HUD.Instance.AddScorePopUp(EnemyConstants.pointsFromStarMario, new Vector2(enemy.XPos, enemy.YPos));
                    SoundManager.Instance.PlaySoundEffect("stomp");
                }
                else if (collider is FireBall)
                {
                    if (enemy is Buzzy || (enemy is Shell && ((Shell)enemy).GetEnemyType() == "Buzzy"))
                    {
                        return;
                    }
                    HUD.Instance.AddScorePopUp(EnemyConstants.pointsFromFireball, new Vector2(enemy.XPos, enemy.YPos));
                }
                else if (collider is Shell)
                {
                    // Collider is a moving shell
                    Shell shell = (Shell)collider;
                    if (shell.GetEnemyType() is "Koopa")
                    {
                        HUD.Instance.AddScorePopUp(shell.GetScore(), new Vector2(enemy.XPos, enemy.YPos));
                    }

                }
                enemy.TakeFireballDamage();
            }
        }
    }
}
