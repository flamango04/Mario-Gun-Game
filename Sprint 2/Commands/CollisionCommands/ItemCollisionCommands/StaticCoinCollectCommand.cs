using Microsoft.Xna.Framework;
using Sprint_2.Constants;
using Sprint_2.GameObjects.Items;
using Sprint_2.GameObjects.ItemSprites;
using Sprint_2.Interfaces;
using Sprint_2.Sound;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.Commands.CollisionCommands.ItemCollisionCommands
{
    public class StaticCoinCollectCommand : ICommands
    {
        private IPlayer player;
        private StaticCoin coin;
        private Rectangle collisionRect;

        public StaticCoinCollectCommand(IPlayer player, StaticCoin coin, Rectangle collisionRect)
        {
            this.player = player;
            this.coin = coin;
            this.collisionRect = collisionRect;
        }

        public void Execute()
        {
            // sfx.stop() 
            SoundManager.Instance.PlaySoundEffect("coin");
            HUD.Instance.AddScoreFromCoin(MiscConstants.coinPoints);
        }
    }
}
