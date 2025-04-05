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
    internal class ColoredBrickWithAStar : BlockState
    {
        private IBlock block;
        private string color;
        public ColoredBrickWithAStar(IBlock block, string color) : base(block)
        {
            this.block = block;
            this.color = color;
            sprite = UniversalSpriteFactory.Instance.GetBlock(color + "Brick");
        }

        public override void BeHit(IPlayer player)
        {
            Hit = true;
            IItem Star = new Star(block.Position, block.GetHitBox().Top);

            GameObjectManager.Instance.Updateables.Add(Star);
            GameObjectManager.Instance.BackDrawables.Add(Star);

            SoundManager.Instance.PlaySoundEffect("powerUpAppears");

            block.ChangeState(new UsedBlockState(block, color));

        }
    }
}
