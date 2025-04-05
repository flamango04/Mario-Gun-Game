using Sprint_2.Constants;
using Sprint_2.Factories;
using Sprint_2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.GameObjects.BlockStates
{
    public class CastleBlock : BlockState
    {
        private IBlock block;

        public CastleBlock(IBlock block) : base(block)
        {
            sprite = UniversalSpriteFactory.Instance.GetBlock(NamesOfSprites.SpriteNames.CastleBrick.ToString());
        }

        public override void BeHit(IPlayer player)
        {
            //Do Nothing
        }
    }
}
