using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoTest.GameObjects;

namespace MonoTest.Map.Tiles
{
    internal class Tile : IGameObject
    {
        public Rectangle BoundingBox { get; set; }
        public bool IsPassable { get; set; }
        public Color Color { get; set; }
        public Texture2D Texture { get; set; }
        public int Size { get; set; }
        public TileType Type { get; set; }

        public Rectangle SourceRectangle { get; set; }
        //public CollideWithEvent CollideWithEvent { get; set; }

        public Tile(Rectangle sourceRectangle, int x, int y, Texture2D texture, int size) //GraphicsDevice graphics)
        {
            Type = TileType.Default;
            Size = size;
            BoundingBox = new Rectangle(x * Size, y * Size, Size, Size);
            IsPassable = true;
            Color = new Color(255,255,255);
            Texture = texture;
            SourceRectangle = sourceRectangle;
        }
        public void Draw(SpriteBatch spriteBatch, GraphicsDevice graphics)
        {
            spriteBatch.Draw(Texture, BoundingBox, SourceRectangle, Color);
        }
        
        public void Update(GameTime gameTime)
        {
        }
    }
}

