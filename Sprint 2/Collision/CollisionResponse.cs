using Microsoft.Xna.Framework;
using Sprint_2.Commands.MarioCollisionCommands;
using Sprint_2.Interfaces;
using Sprint_2.LevelManager;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Xml;

namespace Sprint_2.Collision
{
    public class CollisionResponse
    {
        private Dictionary<string, (Type, Type)> collisionDict = new Dictionary<string, (Type, Type)>();

        public CollisionResponse()
        {
            LoadCommandDictionary();
        }


        private void LoadCommandDictionary()
        {
            string collisionTableFile = @"LevelManager\XMLFiles\CollisionTable.xml";
            string directory = AppDomain.CurrentDomain.BaseDirectory;
            int index = directory.IndexOf(@"\bin");
            directory = directory.Substring(0, index + 1);
            directory = directory + collisionTableFile;

            XmlReader collisionReader = XmlReader.Create(directory);
            collisionReader.MoveToContent();
            while (collisionReader.Read())
            {
                string sourceType;
                string receiverType;
                string collisionSide;
                string sourceCommand;
                string receiverCommand;
                if ((collisionReader.NodeType == XmlNodeType.Element) && (collisionReader.Name == "Entry"))
                {
                    collisionReader.ReadToDescendant("SourceType");
                    sourceType = collisionReader.ReadElementContentAsString();

                    collisionReader.Read();
                    receiverType = collisionReader.ReadElementContentAsString();

                    collisionReader.Read();
                    collisionSide = collisionReader.ReadElementContentAsString();

                    collisionReader.Read();
                    sourceCommand = collisionReader.ReadElementContentAsString();
                    
                    collisionReader.Read();
                    receiverCommand = collisionReader.ReadElementContentAsString();

                    string key = sourceType + receiverType + collisionSide;
                    Type command1 = Type.GetType(sourceCommand);
                    Type command2 = Type.GetType(receiverCommand);

                    collisionDict.Add(key, (command1, command2));
                }
            }
        }
        public void ResolveCollision(ICollideable source, ICollideable receiver, string side, Rectangle collisionIntersection)
        {
            //Item1 is sourceCommand, Item2 is receiverCommand
            (Type, Type) commands;
            
            collisionDict.TryGetValue(source.GetCollisionType() + receiver.GetCollisionType() + side, out commands);
            
            if (commands.Item2 != null)
            {
                Type[] constructorTypes = new Type[] { Type.GetType(receiver.ToString()), Type.GetType(source.ToString()), typeof(Rectangle) };
                ConstructorInfo constructorInfo = commands.Item2.GetConstructor(constructorTypes);

                object[] constructorParameters = new object[] { receiver, source, collisionIntersection };
                ICommands command = (ICommands)constructorInfo.Invoke(constructorParameters);
                command.Execute();
            }
            if (commands.Item1 != null)  
            {
                Type[] constructorTypes = new Type[] { Type.GetType(source.ToString()), Type.GetType(receiver.ToString()), typeof(Rectangle) };
                ConstructorInfo constructorInfo = commands.Item1.GetConstructor(constructorTypes);
                object[] constructorParameters = new object[] {source, receiver, collisionIntersection};
                ICommands command = (ICommands) constructorInfo.Invoke(constructorParameters);
                command.Execute();
            }
            
                
        }
    }
}
