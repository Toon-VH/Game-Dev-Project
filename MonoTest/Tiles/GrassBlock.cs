using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonoTest.Tiles
{
    class GrassBlock : Block
    {
        public GrassBlock(int x, int y, Texture2D texture, int size) : base(x, y, texture,size)
        {
            IsPassable = false;
            SourceRectangle = new Rectangle(107, 32, 16, 16);
        }
    }
}
