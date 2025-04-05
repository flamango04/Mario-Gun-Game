using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_2.Factories;
using Sprint_2.GameObjects.ItemSprites;
using Sprint_2.Sound;
using Sprint_2.Interfaces;
using Sprint_2.LevelManager;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Sprint_2.Constants;

namespace Sprint_2.GameObjects.BlockStates
{
    public class BrownBrickWithCoins : BlockState
    {
        private IBlock block;
        private int coins;

        public BrownBrickWithCoins(IBlock block, int coins) : base(block)
        {
            this.block = block;
            this.coins = coins;
            sprite = UniversalSpriteFactory.Instance.GetBlock(NamesOfSprites.SpriteNames.BrownBrick.ToString());
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
                block.ChangeState(new UsedBlockState(block));
            }
        }

    }
}
