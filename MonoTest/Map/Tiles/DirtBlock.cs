using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoTest.Map.Tiles
{
    class DirtBlock : Block
    {
        public DirtBlock(int x, int y, Texture2D texture, int size) : base(x, y, texture, size)
        {
            IsPassable = false;
            SourceRectangle = new Rectangle(107, 49, 16, 16);
        }
    }
}
