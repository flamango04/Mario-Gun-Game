using Sprint_2.Constants;
using Sprint_2.Factories;
using Sprint_2.Interfaces;
using Sprint_2.Sound;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.GameObjects.BlockStates
{
    public class ChiseledBlockState : BlockState
    {
        public ChiseledBlockState(IBlock block) : base(block) 
        {
            sprite = UniversalSpriteFactory.Instance.GetBlock(NamesOfSprites.SpriteNames.Chiseled.ToString());
        }

        public override void BeHit(IPlayer player)
        {
            //Do nothing
        }
    }
}
