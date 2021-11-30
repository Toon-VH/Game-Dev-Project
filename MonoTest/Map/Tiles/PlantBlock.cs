using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonoTest.Tiles
{
    class PlantBlock :Block
    {
        public PlantBlock(int x, int y, Texture2D texture, int size) : base(x, y, texture, size)
        {
            IsPassable = true;
            SourceRectangle = new Rectangle(107, 15, 16, 16);
        }
    }
}
