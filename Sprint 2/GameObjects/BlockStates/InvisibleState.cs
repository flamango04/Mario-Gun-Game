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
    public class InvisibleState : BlockState
    {
        private IBlock block;
        public InvisibleState(IBlock block) : base(block) 
        {
            this.block = block;
            sprite = UniversalSpriteFactory.Instance.GetBlock(NamesOfSprites.SpriteNames.Invisible.ToString());
        }

        public override void BeHit(IPlayer player)
        {
            Hit = true;
            block.ChangeState(new UsedBlockState(block));
            IItem mushroom = new GreenMushroom(block.Position, block.GetHitBox().Top);

            
            GameObjectManager.Instance.Updateables.Add(mushroom);
            GameObjectManager.Instance.BackDrawables.Add(mushroom);
            GameObjectManager.Instance.Movers.Add(mushroom);
            SoundManager.Instance.PlaySoundEffect("powerUpAppears");
        }
    }
}
