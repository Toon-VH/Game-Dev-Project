using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoTest.GameObjects;

namespace MonoTest.Map.Tiles
{
   abstract class Block : IGameObject
    {
        public Rectangle BoundingBox { get; set; }
        public bool IsPassable { get; set; }
        public Color Color { get; set; }
        public Texture2D Texture { get; set; }
        public Vector2 Position { get; set; }
        public float Size { get; set; }

        public Rectangle SourceRectangle { get; set; }
        //public CollideWithEvent CollideWithEvent { get; set; }

        public Block(int x, int y, Texture2D texture, int size) //GraphicsDevice graphics)
        {
            BoundingBox = new Rectangle(x * size, y * size, size, size);
            //Debug.WriteLine($"x: {x * size}, y: {y * size}, width: {size}, height: {size}");
            IsPassable = false;
            Color = Color.White;
            Texture = texture;
            //CollideWithEvent = new NoEvent();
        }
        public void Draw(SpriteBatch spriteBatch, GraphicsDevice graphics)
        {
            spriteBatch.Draw(Texture, BoundingBox, SourceRectangle, Color);
        }
        
        public void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}

