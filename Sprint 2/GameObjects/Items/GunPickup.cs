using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprint_2.Constants;
using Sprint_2.Factories;
using Sprint_2.Interfaces;
using Sprint_2.LevelManager;
using Sprint_2.Sprites;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.GameObjects.Items
{
    public class GunPickup: IItem
    {
        private ISprite sprite;
        public float XPos { get; set; }
        public float YPos { get; set; }
        public bool OnSpawn { get; set; }
        public Vector2 Velocity { get; set; }

        public GunPickup(Vector2 location)
        {
            XPos = location.X;
            YPos = location.Y;
            sprite = UniversalSpriteFactory.Instance.GetGunSprite();
        }

        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, Color color)
        {
            sprite.Draw(spriteBatch, new Vector2(XPos, YPos), color);
        }

        public void DeleteItem()
        {
            GameObjectManager.Instance.Updateables.Remove(this);
            GameObjectManager.Instance.ForeDrawables.Remove(this);
            GameObjectManager.Instance.Static.Remove(this);
        }

        public Rectangle GetHitBox()
        {
            return sprite.GetHitBox(new Vector2(XPos, YPos));
        }

        public void ChangeDirection()
        {
            //Do nothing
        }

        public string GetCollisionType()
        {
            return nameof(GunPickup);
        }

        public int GetColumn()
        {
            return (int)(XPos / CollisionConstants.blockWidth);
        }
    }
}
