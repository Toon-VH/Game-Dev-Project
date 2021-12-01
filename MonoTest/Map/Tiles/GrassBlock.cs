using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoTest.Map.Tiles
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
