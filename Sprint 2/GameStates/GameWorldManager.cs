using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_2.Collision;
using Sprint_2.Controls;
using Sprint_2.Interfaces;
using Sprint_2.LevelManager;
using Sprint_2.ScreenCamera;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.GameStates
{
    public static class GameWorldManager
    {
        public static string CurrentGameWorld { get; set; } = "main-menu"; // Default to Main Menu, must align with xml file name
    }
}
