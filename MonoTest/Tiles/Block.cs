using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonoTest.Tiles
{
    class Block : IGameObject
    {
        public Rectangle BoundingBox { get; set; }
        public bool Passable { get; set; }
        public Color Color { get; set; }
        public Texture2D Texture { get; set; }

        //public CollideWithEvent CollideWithEvent { get; set; }

        public Block(int x, int y, GraphicsDevice graphics)
        {
            BoundingBox = new Rectangle(x, y, 16, 16);
            Passable = false;
            Color = Color.Green;
            Texture = new Texture2D(graphics, 16, 16);
            //CollideWithEvent = new NoEvent();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, BoundingBox, Color);
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

