using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_2.Constants;
using Sprint_2.Sound;
using Sprint_2.Factories;
using Sprint_2.GameObjects.BlockStates;
using Sprint_2.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Sprint_2.GameObjects
{
    public class Block : IBlock
    {
        public Vector2 Position { get; set; }

        private IBlockState blockState;

        public Block(string name, Vector2 position, string color = null)
        {
            Position = position;
            blockState = GetBlockState(name, color);
        }


        public void Draw(SpriteBatch spriteBatch, Color color)
        {
            blockState.Draw(spriteBatch, Position, color);
        }

        public void Update(GameTime gameTime)
        {
            blockState.Update(gameTime);
        }

        public void ChangeState(IBlockState newBlockState)
        {
            blockState = newBlockState;
        }

        public Rectangle GetHitBox()
        {
            return blockState.GetHitBox(Position);
        }

        public void BeHit(IPlayer player)
        {
            blockState.BeHit(player);
            
        }

        private IBlockState GetBlockState(string name, string color)
        {
            Dictionary<string, IBlockState> blockStates = new Dictionary<string, IBlockState>()
            {
                {"BrownBrick", new BrownBrickState(this) },
                {"BrownBrickWithCoins", new BrownBrickWithCoins(this, MiscConstants.defaultNumberOfCoins) },
                {"ItemWithCoin", new ItemBlockWithCoin(this) },
                {"ItemWithPowerUp", new ItemBlockWithPowerUp(this) },
                {"Chiseled", new ChiseledBlockState(this) },
                {"BlueGround", new BlueGroundState(this) },
                {"BlueBrick", new BlueBrickState(this) },
                {"BrownGround", new BrownGroundState(this) },
                {"BrownBrickWithStar", new BrickWithAStar(this) },
                {"Invisible", new InvisibleState(this) },
                {"BulletBlock", new BulletBlockState(this) },
                {"Hit", new UsedBlockState(this, color) },
                {"NonMovingHitBlock", new NonMovingHitBlock(this, color) },
                {"InvisibleWithCoin", new InvisibleBlockWithCoin(this, color) },
                {"CastleBlock", new CastleBlock(this) }

            };
            /* if a brick with a different color than brown is needed 
             Kept as separate methods to ensure that the block states used to build level 1-1 will still function properly*/
            if (color != null && color != NamesOfSprites.SpriteNames.CastleBrick.ToString())
            {
                blockStates.Add("Brick", new BrickState(this, color));
                blockStates.Add("BrickWithCoins", new BrickWithCoins(this, MiscConstants.defaultNumberOfCoins, color));
                blockStates.Add("BrickWithAStar", new ColoredBrickWithAStar(this, color));
            }


            blockStates.TryGetValue(name, out IBlockState blockState);

            return blockState;
        }

        public IBlockState GetBlockState()
        {
            return blockState;
        }

        public string GetCollisionType()
        {
            if (blockState.GetType() == typeof(InvisibleState) || blockState.GetType() == typeof(InvisibleBlockWithCoin))
            {
                return typeof(InvisibleState).Name;
            }
            return typeof(IBlock).Name;
        }

        public int GetColumn()
        {
            return (int)(Position.X / CollisionConstants.blockWidth);
        }
    }
}
