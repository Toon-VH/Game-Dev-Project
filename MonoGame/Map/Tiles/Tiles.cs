using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoTest.Map.Tiles
{
    class DirtTile : Tile
    {
        public DirtTile(int x, int y, Texture2D texture, int size) : base(x, y, texture, size)
        {
            IsPassable = false;
            SourceRectangle = new Rectangle(107, 49, 16, 16);
        }
    }
    class GrassTile : Tile
    {
        public GrassTile(int x, int y, Texture2D texture, int size) : base(x, y, texture,size)
        {
            IsPassable = false;
            SourceRectangle = new Rectangle(107, 32, 16, 16);
        }
    }
    class PlantTile :Tile
    {
        public PlantTile(int x, int y, Texture2D texture, int size) : base(x, y, texture, size)
        {
            IsPassable = true;
            SourceRectangle = new Rectangle(107, 15, 16, 16);
        }
    }
    class TopRightCorner :Tile
    {
        public TopRightCorner(int x, int y, Texture2D texture, int size) : base(x, y, texture, size)
        {
            IsPassable = false;
            SourceRectangle = new Rectangle(73, 32, 16, 16);
        }
    }
    
    class Grass :Tile
    {
        public Grass(int x, int y, Texture2D texture, int size) : base(x, y, texture, size)
        {
            IsPassable = true;
            SourceRectangle = new Rectangle(90, 15, 16, 16);
        }
    }
    class LeftGrassTile :Tile
    {
        public LeftGrassTile(int x, int y, Texture2D texture, int size) : base(x, y, texture, size)
        {
            IsPassable = false;
            SourceRectangle = new Rectangle(73, 83, 16, 16);
        }
    }
    
    class BearTrap :Tile
    {
        public BearTrap(int x, int y, Texture2D texture, int size) : base(x, y, texture, size)
        {
            IsPassable = true;
            SourceRectangle = new Rectangle(114, 121, 16, 16);
        }
    }
}