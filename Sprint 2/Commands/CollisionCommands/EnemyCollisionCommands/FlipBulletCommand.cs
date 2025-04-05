using Microsoft.Xna.Framework;
using Sprint_2.Constants;
using Sprint_2.GameObjects;
using Sprint_2.GameObjects.Enemies.EnemySprites;
using Sprint_2.Interfaces;
using Sprint_2.Sound;
using Sprint_2.Sprites;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Sprint_2.Commands.CollisionCommands.EnemyCollisionCommands
{
    public class FlipBulletCommand : ICommands
    {
        private BulletBill bullet;
        private ICollideable collider;
        private Rectangle collisionRect;

        public FlipBulletCommand(BulletBill bullet, ICollideable collider, Rectangle collisionRect)
        {
            this.bullet = bullet;
            this.collider = collider;
            this.collisionRect = collisionRect;
        }
        public void Execute()
        {
            if (collider is StarMario)
            {
                HUD.Instance.AddScorePopUp(EnemyConstants.pointsFromStarMario, new Vector2(bullet.XPos, bullet.YPos));
                SoundManager.Instance.PlaySoundEffect("stomp");
            }
            bullet.TakeStompDamage();
        }
    }
}
