using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonoTest.Tiles
{
   abstract class Block : IGameObject
    {
        public Rectangle BoundingBox { get; set; }
        public bool Passable { get; set; }
        public Color Color { get; set; }
        public Texture2D Texture { get; set; }
        public Vector2 Position { get; set; }
        public float Size { get; set; }

        public Rectangle SourceRectangle { get; set; }
        //public CollideWithEvent CollideWithEvent { get; set; }

        public Block(int x, int y, Texture2D texture, int size) //GraphicsDevice graphics)
        {
            BoundingBox = new Rectangle(x * (size-1), y * (size-1), size, size);
            Passable = false;
            Color = Color.White;
            Texture = texture;
            //CollideWithEvent = new NoEvent();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, BoundingBox, SourceRectangle, Color);
            
        }
        //public virtual void IsCollidedWithEvent
        //(Character collider)
        //{
        //    CollideWithEvent.Execute();
        //}

        public void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}

