using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_2.Factories;
using Sprint_2.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Sprint_2.Sound;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Sprint_2.Constants;

namespace Sprint_2.GameObjects.BlockStates
{
    public class UsedBlockState : BlockState
    {
        private IBlock block;
        public UsedBlockState(IBlock block, string color = null) : base(block)
        {

            this.block = block;
            AssignSprite(color);
            Hit = true;
            if (color == NamesOfSprites.SpriteNames.CastleBrick.ToString())
            {
                Hit = false;
            }
            
        }

        public override void BeHit(IPlayer player)
        {
            // Do nothing
        }

        private void AssignSprite(string color)
        {
            if (color == null)
            {
                sprite = UniversalSpriteFactory.Instance.GetBlock(NamesOfSprites.SpriteNames.Hit.ToString());
            }
            else if (color.Equals(System.Drawing.KnownColor.Blue.ToString()))
            {
                sprite = UniversalSpriteFactory.Instance.GetBlock(NamesOfSprites.SpriteNames.BlueHit.ToString());
            }
            else if (color.Equals(System.Drawing.KnownColor.Green.ToString())){
                sprite = UniversalSpriteFactory.Instance.GetBlock(NamesOfSprites.SpriteNames.GreenHit.ToString());
            }
            else if (color.Equals(System.Drawing.KnownColor.Gray.ToString()) || color.Equals(System.Drawing.KnownColor.DarkGray.ToString()))
            {
                sprite = UniversalSpriteFactory.Instance.GetBlock(NamesOfSprites.SpriteNames.GrayHit.ToString());
            }
            else if (color.Equals(NamesOfSprites.SpriteNames.CastleBrick.ToString()))
            {
                sprite = UniversalSpriteFactory.Instance.GetBlock(color);
            }
            else
            {
                sprite = UniversalSpriteFactory.Instance.GetBlock(NamesOfSprites.SpriteNames.Hit.ToString());
            }
        }

    }
}
