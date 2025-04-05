using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_2.Constants;
using Sprint_2.Factories;
using Sprint_2.Interfaces;
using Sprint_2.LevelManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.GameObjects.Misc
{
    public class Flag : Interfaces.IDrawable, Interfaces.IUpdateable
    {
        private ISprite flagSprite;
        private float XPos;
        private float YPos;
        private bool reachedBottom = false;

        public Flag(Vector2 location)
        {
            XPos = location.X;
            YPos = location.Y;
            flagSprite = UniversalSpriteFactory.Instance.GetFlagSprite();
        }
        public void Update(GameTime gameTime)
        {
            if (YPos < MiscConstants.bottomOfFlagPole)
            {
                YPos++;
            }
            else
            {
                reachedBottom = true;
            }
        }
        public void Draw(SpriteBatch spriteBatch, Color color)
        {
            flagSprite.Draw(spriteBatch, new Vector2(XPos, YPos), color);
        }

        public bool ReachedBottom()
        {
            return reachedBottom;
        }

    }
}
