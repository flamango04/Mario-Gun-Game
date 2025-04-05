using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_2.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Sprint_2
{
    public class HUD
    {
        private static HUD hud = new HUD();
        public static HUD Instance {get {return hud;} }

        private SpriteFont font;
        private int score;
        private int coins;
        private string world;
        private float time;
        private int lives;
        private int level = 1;
        private List<ScorePopup> scorePopups;

        public HUD()
        {
            font = Game1.Instance.Content.Load<SpriteFont>("HUDFont");
            score = 0;
            coins = 0;
            world = "1-" + level;
            time = MiscConstants.defaultLevelTime;
            lives = MarioPhysicsConstants.startingLives;
            scorePopups = new List<ScorePopup>();
        }
        
        public void AddScorePopUp(int points, Vector2 position)
        {
            score += points;
            scorePopups.Add(new ScorePopup(points, position));
        }

        public void AddScoreFromCoin(int points)
        {
            coins++;
            score += points;
        }

        public void AddScore(int points)
        {
            score += points;
        }

        public void Update(GameTime gameTime)
        {
            if (time < 0)
            {
                time = 0;
                Game1.Instance.mario.Die();
            }
            else if (time > 0)
            {
                time -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            for (int i = scorePopups.Count - 1; i >= 0; i--)
            {
                scorePopups[i].Update(gameTime);
                if (scorePopups[i].IsExpired)
                {
                    scorePopups.RemoveAt(i);
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // define position and space
            int spacing = MiscConstants.hudSpacingBetweenElements;
            Vector2 startPosition = Game1.Instance.camera.GetLeftScreenBound() + new Vector2(MiscConstants.hudSpacingForScreen, 0);
            lives = Game1.Instance.mario.RemainingLives;

            // draw
            spriteBatch.DrawString(font, $"Score: {score}", startPosition, Color.White);
            spriteBatch.DrawString(font, $"Coins: {coins}", startPosition + new Vector2(spacing, 0), Color.Yellow);
            spriteBatch.DrawString(font, $"World: {world}", startPosition + new Vector2(2 * spacing, 0), Color.White);
            spriteBatch.DrawString(font, $"Time: {(int)time}", startPosition + new Vector2(3 * spacing, 0), Color.White);
            spriteBatch.DrawString(font, $"Lives: {lives}", startPosition + new Vector2(4 * spacing, 0), Color.White);

            // draw the score on the screen
            foreach (var popup in scorePopups)
            {
                popup.Draw(spriteBatch, font);
            }
        }

        public void ResetTime()
        {
            time = MiscConstants.defaultLevelTime;
        }

        public void CompleteReset()
        {
            coins = 0;
            score = 0;
            time = MiscConstants.defaultLevelTime;
            level = 1;
            world = "1-" + level;
        }

        public int GetScore()
        {
            return score;
        }
        public void IncrementLevel()
        {
            world = "1-" + ++level;
        }
    }

    
}
