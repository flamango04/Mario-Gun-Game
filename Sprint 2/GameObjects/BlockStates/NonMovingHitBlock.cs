using Sprint_2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.GameObjects.BlockStates
{
    public class NonMovingHitBlock : UsedBlockState
    {
        private IBlock block;
        public NonMovingHitBlock(IBlock block, string color = null) : base(block, color) 
        {
            Hit = false;
        }
    }
}
