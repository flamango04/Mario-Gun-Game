using Microsoft.Xna.Framework;
using Sprint_2.Constants;
using Sprint_2.Factories;
using Sprint_2.GameObjects.ItemSprites;
using Sprint_2.Interfaces;
using Sprint_2.LevelManager;
using Sprint_2.Sound;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.GameObjects.BlockStates
{
    public class InvisibleBlockWithCoin : BlockState
    {
        private IBlock block;
        private string color;
        public InvisibleBlockWithCoin(IBlock block, string color = null) : base(block)
        {
            this.block = block;
            this.color = color;
            sprite = UniversalSpriteFactory.Instance.GetBlock(NamesOfSprites.SpriteNames.Invisible.ToString());
        }

        public override void BeHit(IPlayer player)
        {
            Hit = true;
            block.ChangeState(new UsedBlockState(block, color));
            IItem coin = new Coin(new Vector2(block.Position.X + CollisionConstants.blockWidth / MiscConstants.coinCenteringFactor,
                block.Position.Y - CollisionConstants.blockWidth), true);


            GameObjectManager.Instance.Updateables.Add(coin);
            GameObjectManager.Instance.BackDrawables.Add(coin);
            GameObjectManager.Instance.Movers.Add(coin);
            SoundManager.Instance.PlaySoundEffect("coin");
        }
    }
}
