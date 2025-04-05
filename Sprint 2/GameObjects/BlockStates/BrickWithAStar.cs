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
    public class BrickWithAStar : BlockState
    {
        private IBlock block;
        public BrickWithAStar(IBlock block) : base(block)
        {
            this.block = block;
            sprite = UniversalSpriteFactory.Instance.GetBlock(NamesOfSprites.SpriteNames.BrownBrick.ToString());
        }

        public override void BeHit(IPlayer player)
        {
            Hit = true;
            IItem Star = new Star(block.Position, block.GetHitBox().Top);
            
            GameObjectManager.Instance.Updateables.Add(Star);
            GameObjectManager.Instance.BackDrawables.Add(Star);

            SoundManager.Instance.PlaySoundEffect("powerUpAppears");

            block.ChangeState(new UsedBlockState(block));

        }
    }
}
