using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonoTest.Tiles
{
    class GrassBlock : Block
    {
        public GrassBlock(int x, int y, GraphicsDevice graphics) : base(x, y, graphics)
        {
            BoundingBox = new Rectangle(x, y, 10, 10);
            Passable = true;
            //Color = Color.GreenYellow;
            Texture = new Texture2D(graphics, 16, 16);
            //CollideWithEvent = new SlowEvent();
        }
    }
}
