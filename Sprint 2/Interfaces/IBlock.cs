using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint_2.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint_2.Interfaces
{
    public interface IBlock : ICollideable, IUpdateable, IDrawable
    {
        Vector2 Position { get; set; }

        public void BeHit(IPlayer player);

        public void ChangeState(IBlockState blockState);

        public IBlockState GetBlockState();


    }
}
