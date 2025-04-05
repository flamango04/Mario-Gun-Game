using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint_2.Constants;

namespace Sprint_2
{
    public class ScorePopup
    {
        private int points;
        private Vector2 position;
        private float timer;
        private Color color;
        private float initialTimerValue;

        public bool IsExpired => timer <= 0;

        public ScorePopup(int points, Vector2 position)
        {
            this.points = points;
            this.position = position;
            timer = MiscConstants.lifetimeOfPoints;
            initialTimerValue = timer;
            color = Color.White;
        }

        public void Update(GameTime gameTime)
        {
            timer -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            position.Y -= MiscConstants.heightChangeForPopupPoints * (float)gameTime.ElapsedGameTime.TotalSeconds;
            color = Color.White * MathHelper.Clamp(timer / initialTimerValue, 0, 1);
        }

        public void Draw(SpriteBatch spriteBatch, SpriteFont font)
        {
            spriteBatch.DrawString(font, points.ToString(), position, color);
        }
    }
}
