﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoTest.Tiles
{
    class DirtBlock : Block
    {
        public DirtBlock(int x, int y, Texture2D texture, int size) : base(x, y, texture, size)
        {
            SourceRectangle = new Rectangle(107, 49, 16, 16);
        }
    }
}
