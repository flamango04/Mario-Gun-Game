using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_2.Collision;
using Sprint_2.Controls;
using Sprint_2.Interfaces;
using Sprint_2.Constants;
using Sprint_2.LevelManager;
using Sprint_2.ScreenCamera;
using Sprint_2.GameStates;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint_2.Interfaces;
using Sprint_2.Sound;
using System;
using System.Diagnostics;

namespace Sprint_2.LevelManager
{
    public class Spawner
    {
        private static Spawner instance;
        private Vector2 spawnLocation;
        private float holdTime;
        private float elapsedTime;
        private bool isHolding;

        public static Spawner Instance => instance ??= new Spawner();

        private Spawner()
        {
            spawnLocation = Vector2.Zero; // Default location, will be set to a proper one after read the xml
            holdTime = 0;
            elapsedTime = 0;
            isHolding = false;
        }

        public void SetSpawnLocation(Vector2 location)
        {
            spawnLocation = location;
        }

        public void TeleportToLevel(string newWorld, Vector2 spawnLocation, string bgm)
        {
            /* I think this game state change fixes that weird crashing bug. It just prevents objects from being updated/drawn
             when the lists are being modified. ~Aidan */
            Game1.Instance.gameState = new TransitionGameState();
            GameWorldManager.CurrentGameWorld = newWorld;

            LevelLoader levelLoader = new LevelLoader();
            GameObjectManager.Instance.Reset();
            levelLoader.LoadLevel($"LevelManager\\{newWorld}.xml");

            SoundManager.Instance.StopBackgroundMusic();
            SoundManager.Instance.PlayBackgroundMusic(bgm);

            Game1.Instance.gameState = new PlayableState(Game1.Instance.GetKeyboardControl());
        }


        // Teleport Mario via specific (x,y) location
        public void Teleport(IPlayer player, Vector2 newPosition)
        {
            player.XPos = (int)newPosition.X;
            player.YPos = (int)newPosition.Y;
        }
    }
}
