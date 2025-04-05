using Microsoft.Xna.Framework;
using Sprint_2.Factories;
using Sprint_2.GameObjects.ItemSprites;
using Sprint_2.Interfaces;
using Sprint_2.Sound;
using Sprint_2.LevelManager;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Sprint_2.Constants;
using Sprint_2.MarioStates;

namespace Sprint_2.GameObjects.BlockStates
{
    public class ItemBlockWithPowerUp : BlockState
    {
        private IBlock block;
        private string color;

        public ItemBlockWithPowerUp(IBlock block) : base(block)
        {
            this.block = block;

            sprite = UniversalSpriteFactory.Instance.GetBlock(NamesOfSprites.SpriteNames.Question.ToString());
        }

        public override void BeHit(IPlayer player)
        {
            Hit = true;
            string health = player.GetHealth();
            if (health.Equals(HealthState.HealthEnum.Mario.ToString()))
            {
                IItem mushroom = new RedMushroom(block.Position, block.GetHitBox().Top);
                GameObjectManager.Instance.Updateables.Add(mushroom);
                GameObjectManager.Instance.BackDrawables.Add(mushroom);
            }
            else
            {
                IItem flower = new Flower(block.Position, block.GetHitBox().Top);
                GameObjectManager.Instance.Updateables.Add(flower);
                GameObjectManager.Instance.BackDrawables.Add(flower);
                GameObjectManager.Instance.Static.Add(flower);
            }
            SoundManager.Instance.PlaySoundEffect("powerUpAppears");
            block.ChangeState(new UsedBlockState(block, ""));

        }
    }
}
