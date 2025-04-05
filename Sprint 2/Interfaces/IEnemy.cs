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
    public interface IEnemy : ICollideable, IUpdateable, IDrawable
    {
        public float XPos { get; set; }
        public float YPos { get; set; }
        Vector2 Velocity { get; set; }
        //void Move();
        public void TakeFireballDamage();
        public void TakeStompDamage();

        public void ChangeDirection();

        public bool Flipped { get; set; }
    }

}
