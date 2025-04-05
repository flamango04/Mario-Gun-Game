using Sprint_2.Constants;
using Sprint_2.Factories;
using Sprint_2.Interfaces;
using Sprint_2.LevelManager;
using Sprint_2.MarioStates;
using Sprint_2.Sound;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.GameObjects.BlockStates
{
    internal class BrickState : BlockState
    {
        private IBlock block;
        private IBlockState brokenState;
        private bool bumped = false;
        private bool destroyed = false;
        private float originalBlockY;

        public BrickState(IBlock block, string color) : base(block)
        {
            this.block = block;
            Debug.WriteLine("Color: " + color);
            sprite = UniversalSpriteFactory.Instance.GetBlock(color + "Brick");
            brokenState = new BrokenBlockState(block, color);
            originalBlockY = block.Position.Y;
        }

        public override void BeHit(IPlayer player)
        {

            /* Little mario hit the block */
            if (player.GetHealth().Equals(HealthState.HealthEnum.Mario.ToString()))
            {
                /* Make the block move up and then down */
                Hit = true;
                originalBlockY = (int)block.Position.Y;
                SoundManager.Instance.PlaySoundEffect("bump");
            }
            /* SuperMario/Fire Mario hit the block*/
            else
            {
                int column = (int)block.Position.X / CollisionConstants.blockWidth;

                /* Call remove object on gameobject manager to remove the block from being able to be drawn/updated */
                GameObjectManager.Instance.Blocks[column].Remove(block);

                block.ChangeState(brokenState);
                SoundManager.Instance.PlaySoundEffect("breakBlock");

            }
        }
    }
}
