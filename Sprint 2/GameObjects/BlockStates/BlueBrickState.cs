using Sprint_2.Factories;
using Sprint_2.Interfaces;
using Sprint_2.Sound;
using Sprint_2.LevelManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint_2.Constants;
using Sprint_2.MarioStates;

namespace Sprint_2.GameObjects.BlockStates
{
    public class BlueBrickState : BlockState
    {
        private IBlock block;
        private int originalBlockY;
        public BlueBrickState(IBlock block) : base(block) 
        {
            this.block = block;
            sprite = UniversalSpriteFactory.Instance.GetBlock(NamesOfSprites.SpriteNames.BlueBrick.ToString());

            originalBlockY = (int)block.Position.Y;
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
                SoundManager.Instance.PlaySoundEffect("breakBlock");
                GameObjectManager.Instance.Blocks[column].Remove(block);

            }
        }
    }
}
