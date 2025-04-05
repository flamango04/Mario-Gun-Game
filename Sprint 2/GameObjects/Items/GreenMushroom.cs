using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_2.Interfaces;
using Sprint_2.Factories;
using Sprint_2.LevelManager;
using System.Linq.Expressions;
using Sprint_2.Constants;

namespace Sprint_2.GameObjects.ItemSprites
{
    public class GreenMushroom : IItem
    {
        public bool OnSpawn { get; set; }
        public float XPos { get; set; }
        public float YPos { get; set; }
        public Vector2 Velocity { get; set; }

        private ISprite sprite;

        private float spawnedYPosition;
        private IBlock sourceBlock;

        private float speed = ItemPhysicsConstants.defaultMoveSpeed;
        private int topOfSourceBlock;
        public GreenMushroom(Vector2 initialPosition, int topOfSourceBlock)
        {
            XPos = initialPosition.X;
            YPos = initialPosition.Y;
            Velocity = new Vector2(speed, 0); // Starts moving right

            sprite = UniversalSpriteFactory.Instance.GetItemSprite(nameof(GreenMushroom));

            OnSpawn = true;
            spawnedYPosition = initialPosition.Y;

            this.topOfSourceBlock = topOfSourceBlock;
        }


        public void Update(GameTime gameTime)
        {
            if (OnSpawn)
            {
                YPos--;
                if (GetHitBox().Bottom < topOfSourceBlock)
                {
                    OnSpawn = false;
                }
            }
            else
            {
                /* Apply Gravity */
                if (Velocity.Y < ItemPhysicsConstants.maxFallVelocity)
                {
                    Velocity += ItemPhysicsConstants.fallVelocity;
                }

                YPos += (float)(Velocity.Y * gameTime.ElapsedGameTime.TotalSeconds);
                Velocity *= MarioPhysicsConstants.velocityDecay;

                XPos += speed;
            }

            if (YPos > EnemyConstants.despawnHeight)
            {
                DeleteItem();
            }

            sprite.Update(gameTime);
        }


        public void Draw(SpriteBatch spriteBatch, Color color)
        {
            sprite.Draw(spriteBatch, new Vector2(XPos, YPos), color);
        }

        public void DeleteItem() 
        {
            GameObjectManager.Instance.Movers.Remove(this);
            GameObjectManager.Instance.Updateables.Remove(this);
            GameObjectManager.Instance.BackDrawables.Remove(this);
        }

        public Rectangle GetHitBox()
        {
            return sprite.GetHitBox(new Vector2(XPos, YPos));
        }

        public void ChangeDirection() 
        {
            speed *= -1;
        }
        public string GetCollisionType()
        {
            return typeof(GreenMushroom).Name;
        }
        public int GetColumn()
        {
            if (OnSpawn)
            {
                return -1;
            }
            return (int)(XPos / CollisionConstants.blockWidth);
        }


    }
}

