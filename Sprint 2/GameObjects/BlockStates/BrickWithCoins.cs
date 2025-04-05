using Microsoft.Xna.Framework;
using Sprint_2.Constants;
using Sprint_2.Factories;
using Sprint_2.GameObjects.ItemSprites;
using Sprint_2.Interfaces;
using Sprint_2.LevelManager;
using Sprint_2.Sound;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.GameObjects.BlockStates
{
    internal class BrickWithCoins : BlockState
    {
        private IBlock block;
        private int coins;
        private string color;
        //private const float rightShift

        public BrickWithCoins(IBlock block, int coins, string color) : base(block)
        {
            this.block = block;
            this.coins = coins;
            this.color = color;
            string key = NamesOfSprites.SpriteNames.BrownBrick.ToString();
            if (color != null)
            {
                Debug.WriteLine("Color: " + color);
                key = color + "Brick";
            }
            sprite = UniversalSpriteFactory.Instance.GetBlock(key);
        }


        public override void BeHit(IPlayer player)
        {
            Hit = true;
            /* Game Object manager add coin */
            IItem Coin = new Coin(new Vector2(block.Position.X + CollisionConstants.blockWidth / MiscConstants.coinCenteringFactor,
                block.Position.Y - CollisionConstants.blockWidth), true);
            HUD.Instance.AddScoreFromCoin(MiscConstants.coinPoints);

            GameObjectManager.Instance.Updateables.Add(Coin);
            GameObjectManager.Instance.BackDrawables.Add(Coin);

            SoundManager.Instance.PlaySoundEffect("coin");

            if (--coins == 0)
            {
                block.ChangeState(new UsedBlockState(block, color));
            }
        }
    }
}
