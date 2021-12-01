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
    class GrassBlock : Block
    {
        public GrassBlock(int x, int y, Texture2D texture, int size) : base(x, y, texture,size)
        {
            IsPassable = false;
            SourceRectangle = new Rectangle(107, 32, 16, 16);
        }
    }
    class PlantBlock :Block
    {
        public PlantBlock(int x, int y, Texture2D texture, int size) : base(x, y, texture, size)
        {
            IsPassable = true;
            SourceRectangle = new Rectangle(107, 15, 16, 16);
        }
    }
    class TopRightCorner :Block
    {
        public TopRightCorner(int x, int y, Texture2D texture, int size) : base(x, y, texture, size)
        {
            IsPassable = true;
            SourceRectangle = new Rectangle(73, 32, 16, 16);
        }
    }
    
    class Grass :Block
    {
        public Grass(int x, int y, Texture2D texture, int size) : base(x, y, texture, size)
        {
            IsPassable = true;
            SourceRectangle = new Rectangle(90, 15, 16, 16);
        }
    }
    class LeftGrassBlock :Block
    {
        public LeftGrassBlock(int x, int y, Texture2D texture, int size) : base(x, y, texture, size)
        {
            IsPassable = true;
            SourceRectangle = new Rectangle(73, 83, 16, 16);
        }
    }
}