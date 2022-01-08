using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoTest.GameObjects;

namespace MonoTest.Map.Tiles
{
    internal class Tile : GameObject
    {
        public RectangleF BoundingBox { get; set; }
        public bool IsPassable { get; set; }
        public Color Color { get; set; }
        public Texture2D Texture { get; set; }
        public float Size { get; set; }
        public TileType Type { get; set; }
        private Vector2 _position;
        public Rectangle SourceRectangle { get; set; }
        public float Scale { get; set; }

        public Tile(Rectangle sourceRectangle, float x, float y, Texture2D texture, int size) //GraphicsDevice graphics)
        {
            Type = TileType.Default;
            Size = size;
            _position = new Vector2(x * size, y * size);
            BoundingBox = new RectangleF(x * Size, y * Size, Size, Size);
            IsPassable = false;
            Color = new Color(255, 255, 255);
            Texture = texture;
            SourceRectangle = sourceRectangle;
        }

        public override void Draw(SpriteBatch spriteBatch, GraphicsDevice graphics)
        {
            spriteBatch.Draw(Texture, _position, SourceRectangle, Color, 0f, Vector2.Zero, Size / 16,
                SpriteEffects.None, 0f);
            
        }


        public override void Update(GameTime gameTime)
        {
        }
    }
}