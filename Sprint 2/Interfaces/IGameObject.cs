using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Sprint_2.Interfaces
{
    public interface IGameObject
    {
        //


        // The position 
        Vector2 Position { get; set; }

        // 
        void Update(GameTime gameTime);

        // 
        void Draw(SpriteBatch spriteBatch);

        //TODO: collision
    }
}
