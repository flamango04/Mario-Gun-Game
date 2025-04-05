using Microsoft.VisualBasic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_2;
using Sprint_2.Collision;
using Sprint_2.Factories;
using Sprint_2.GameObjects;
using Sprint_2.GameObjects.Enemies.EnemySprites;
using Sprint_2.GameObjects.ItemSprites;
using Sprint_2.Interfaces;
using Sprint_2.Sprites;
using Sprint_2.Sprites.EnemySprites;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.InteropServices.ObjectiveC;
using System.Text.Json.Serialization;

namespace Sprint_2.LevelManager
{
    public class GameObjectManager
    {
        private static GameObjectManager instance;
        public static GameObjectManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameObjectManager();
                }
                return instance;
            }
        }


        public List<ICollideable>[] Blocks = new List<ICollideable>[225];
        public List<Interfaces.IUpdateable> Updateables { get; set; } = new List<Interfaces.IUpdateable>();
        public List<Interfaces.IDrawable> ForeDrawables { get; set; } = new List<Interfaces.IDrawable>();
        public List<Interfaces.IDrawable> BackDrawables { get; set; } = new List<Interfaces.IDrawable>();

        public List<ICollideable> Movers { get; set; } = new List<ICollideable>();
        public List<ICollideable> Static { get; set; } = new List<ICollideable>();

        private GameObjectManager()
        {   
            for (int i = 0; i < Blocks.Length; i++)
            {
                Blocks[i] = new List<ICollideable>();
            }
        }
        
        public List<ICollideable> GetNearbyBlocks(int column)
        {
            List<ICollideable> nearbyBlocks;
            if (column < 0 || column >= Blocks.Length)
            {
                nearbyBlocks = new List<ICollideable>();
            }
            else if (column != 0 && column < Blocks.Length - 1)
            {
                nearbyBlocks = Blocks[column].Concat(Blocks[column - 1].Concat(Blocks[column + 1])).ToList();
            }
            else if (column == Blocks.Length - 1)
            {
                nearbyBlocks = Blocks[column].Concat(Blocks[column - 1]).ToList();
            }
            else
            {
                nearbyBlocks = Blocks[column].Concat(Blocks[column + 1]).ToList();
            }
            foreach(ICollideable block in nearbyBlocks)
            {
                Static.Add(block);
            }
            return nearbyBlocks;
        }

        public void RemoveBlocksFromStatic(List<ICollideable> list)
        {
            foreach(ICollideable block in list)
            {
                Static.Remove(block);
            }
        }

        public void Reset()
        {
            Static.Clear();
            Movers.Clear();
            Updateables.Clear();
            ForeDrawables.Clear();
            BackDrawables.Clear();
            foreach (List<ICollideable> list in Blocks)
            {
                list.Clear();
            }
        }

        public void AddMover(object mover)
        {
            Updateables.Add((Interfaces.IUpdateable)mover);
            ForeDrawables.Add((Interfaces.IDrawable)mover);
            Movers.Add((ICollideable)mover);
        }
        public void AddStatic(object obj)
        {
            Updateables.Add((Interfaces.IUpdateable)obj);
            ForeDrawables.Add((Interfaces.IDrawable)obj);
            Static.Add((ICollideable)obj);
        }
        public void AddNonCollideable(object obj)
        {
            Updateables.Add((Interfaces.IUpdateable)obj);
            ForeDrawables.Add((Interfaces.IDrawable)obj);
        }

        public void RemoveStatic(object obj)
        {
            Updateables.Remove((Interfaces.IUpdateable)obj);
            ForeDrawables.Remove((Interfaces.IDrawable)obj);
            Static.Remove((ICollideable)obj);
        }
        public void RemoveMover(object obj)
        {
            Updateables.Remove((Interfaces.IUpdateable)obj);
            ForeDrawables.Remove((Interfaces.IDrawable)obj);
            Movers.Remove((ICollideable)obj);
        }

        public void RemoveNonUpdatingStatic(object obj)
        {
            ForeDrawables.Remove((Interfaces.IDrawable)obj);
            Static.Remove((ICollideable)obj);
        }
    }
}