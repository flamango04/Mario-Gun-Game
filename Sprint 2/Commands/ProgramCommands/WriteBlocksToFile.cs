using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Sprint_2.Constants;
using Sprint_2.GameObjects;
using Sprint_2.GameObjects.Items;
using Sprint_2.Interfaces;
using Sprint_2.LevelManager;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Sprint_2.Commands.ProgramCommands
{
    public class WriteBlocksToFile : ICommands
    {
        XDocument xmlDoc;
        private string directory;
        public WriteBlocksToFile()
        {
            directory = AppDomain.CurrentDomain.BaseDirectory;
            int index = directory.IndexOf(@"\bin");
            directory = directory.Substring(0, index + 1);
            //directory = directory + @"LevelManager\XMLFiles\boss-level.xml";
            directory = directory + @"LevelManager\XMLFiles\extraLevel.xml";
            xmlDoc = XDocument.Load(directory);

            //Debug.WriteLine(xmlDoc.ToString());
        }
        /* Used to write block data to an xml file based on mouse location. This was only used to create our levels so "magic strings" are prevalent
         in this code. Only used as a toold to create our levels*/

        public void Execute()
        {
            Point mousePos = Game1.Instance.mouseController.GetCurrentMousePos();
            Matrix inverseTransform = Matrix.Invert(Game1.Instance.camera.Transform);
            Vector2 mouseInWorldSpace = Vector2.Transform(new Vector2(mousePos.X, mousePos.Y), inverseTransform);
            int mouseXPos = (int)(Math.Ceiling((decimal)(mouseInWorldSpace.X / CollisionConstants.blockWidth)) * CollisionConstants.blockWidth);
            int mouseYPos = (int)(Math.Ceiling((decimal)(mouseInWorldSpace.Y / CollisionConstants.blockWidth)) * CollisionConstants.blockWidth);
            mouseXPos -= CollisionConstants.blockWidth;
            mouseYPos -= CollisionConstants.blockWidth;
            Debug.WriteLine("Mouse Pos: " + new Vector2(mouseXPos, mouseYPos));
            XNode rootElement = xmlDoc.Root.Element("Asset");
            xmlDoc.Save(directory);
            return;


            //XElement parentElement = new XElement("NonStandardItem");
            //XElement objTypeElement = new XElement("ObjectType", "Sprint_2.GameObjects.Block");
            //XElement objCollisionElement = new XElement("CollisionType", "Static");
            //XElement objParamsElement = new XElement("NumberOfParams", "2");
            //XElement objSprite = new XElement("Sprite", "CastleBlock");
            //XElement locElement = new XElement("Location", mouseXPos + " " + mouseYPos);
            //XElement colorElement = new XElement("Color", null);
            //XElement objBalls = new XElement("Color", "6");

            XElement parentElement = new XElement("Item");
            XElement objTypeElement = new XElement("ObjectType", "Block");
            XElement objNameElement = new XElement("ObjectName", "BrownGround");
            XElement locElement = new XElement("Location", mouseXPos + " " + mouseYPos);

            parentElement.Add(objTypeElement);
            parentElement.Add(objNameElement);
            //parentElement.Add(objCollisionElement);
            //parentElement.Add(objParamsElement);
            //parentElement.Add(objSprite);
            parentElement.Add(locElement);
            //parentElement.Add(colorElement);
            //parentElement.Add(objBalls);

            rootElement.AddBeforeSelf(parentElement);
            //StaticCoin block = new StaticCoin(new Vector2(mouseXPos, mouseYPos));
            Block block = new Block("Hit", new Vector2(mouseXPos, mouseYPos), "Green");
            GameObjectManager.Instance.AddStatic(block);

            xmlDoc.Save(directory);

        }
    }
}
