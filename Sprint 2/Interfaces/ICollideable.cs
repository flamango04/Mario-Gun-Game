using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.Interfaces
{
    public interface ICollideable
    {
        public string GetCollisionType();

        public Rectangle GetHitBox();

        public int GetColumn();
    }
}
