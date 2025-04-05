using Microsoft.Xna.Framework;
using Sprint_2.Constants;
using Sprint_2.GameObjects.Enemies.EnemySprites;
using Sprint_2.Interfaces;
using Sprint_2.MarioPhysicsStates;
using Sprint_2.Sound;
using Sprint_2.Sprites;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.Commands.MarioCollisionCommands
{
    public class MarioBounceOnBullet : ICommands
    {
        private IPlayer player;
        private BulletBill enemy;
        private Rectangle collisionRect;

        public MarioBounceOnBullet(IPlayer player, BulletBill enemy, Rectangle collisionRect)
        {
            this.player = player;
            this.enemy = enemy;
            this.collisionRect = collisionRect;
        }

        public void Execute()
        {
            
            if (player.isFalling)
            {
                player.PlayerVelocity = new Vector2(player.PlayerVelocity.X, MarioPhysicsConstants.bounceVelocity);
                SoundManager.Instance.PlaySoundEffect("stomp");
                player.YPos -= collisionRect.Height;
                player.isFalling = false;
                player.Bounce();
            }
        }
    }
}
