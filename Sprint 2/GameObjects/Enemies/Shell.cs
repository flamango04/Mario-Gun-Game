using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_2.Constants;
using Sprint_2.Factories;
using Sprint_2.GameObjects.Enemies.EnemyStates;
using Sprint_2.Interfaces;
using Sprint_2.LevelManager;
using Sprint_2.Sprites;
using System.Diagnostics;

namespace Sprint_2.GameObjects.Enemies.EnemySprites
{
    public class Shell : IEnemy
    {
        public float XPos { get; set; }
        public float YPos { get; set; }
        public bool Flipped { get; set; }
        public bool Kicked { get; set; }
        public Vector2 Velocity { get; set; }
        private string type;
        private ISprite sprite;

        private float timeUntilShellBecomesAlive = EnemyConstants.timeUntilShellBecomesAlive;
        public IShellState ShellState { get; set; }

        private int[] score = EnemyConstants.shellScoreValues;
        private int index = 0;
        public Shell(Vector2 initialPosition, string Enemytype)
        {
            XPos = initialPosition.X;
            YPos = initialPosition.Y;
            type = Enemytype;
            if (type.Equals("Koopa")) {
                sprite = UniversalSpriteFactory.Instance.CreateEnemy(NamesOfSprites.SpriteNames.KoopaShell.ToString());
            }
            else {
                sprite = UniversalSpriteFactory.Instance.CreateEnemy(NamesOfSprites.SpriteNames.BuzzyShell.ToString());
            }
            ShellState = new ShellStateIdle(this);
            Velocity = new Vector2(0, EnemyConstants.fallVelocity.Y);
        }


        public void Update(GameTime gameTime)
        {
            ShellState.Update(gameTime);
            sprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, Color color)
        {
            sprite.Draw(spriteBatch, new Vector2(XPos, YPos), color);
        }

        public Rectangle GetHitBox()
        {
            return sprite.GetHitBox(new Vector2(XPos, YPos));
        }

        public string GetEnemyType()
        {
            return type;
        }

        public void TakeFireballDamage()
        {
            if (sprite.Equals("Koopa")){
                sprite = UniversalSpriteFactory.Instance.CreateEnemy(NamesOfSprites.SpriteNames.FlippedKoopaShell.ToString());
            } 
            Flipped = true;
            Velocity = EnemyConstants.flippedVelocity;
            ShellState = new ShellFlippedState(this);
            GameObjectManager.Instance.Movers.Remove(this);
        }

        public void TakeStompDamage()
        {

        }

        public void ChangeDirection()
        {
            Velocity = new Vector2(Velocity.X * -1, Velocity.Y);
        }

        public string GetCollisionType()
        {
            if (Velocity.X != 0)
            {
                return "MovingShell";
            }
            if (Flipped)
            {
                return "flip";
            }
            return typeof(Shell).Name;
        }

        public int GetColumn()
        {
            return (int)(XPos / CollisionConstants.blockWidth);
        }

        public int GetScore()
        {
            return score[index++];
        }

        public void ResetIndex()
        {
            index = 0;
        }
    }
}
