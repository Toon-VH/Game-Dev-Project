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

        public Rectangle SourceRectangle { get; set; }
        //public CollideWithEvent CollideWithEvent { get; set; }

        public Block(int x, int y, Texture2D texture) //GraphicsDevice graphics)
        {
            SourceRectangle = new Rectangle(90,49,16,16);//uit tileset halen
            BoundingBox = new Rectangle(x, y, 50, 50);
            Passable = false;
            Color = Color.White;
            Texture = texture;
            //CollideWithEvent = new NoEvent();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
           
            spriteBatch.Draw(Texture, BoundingBox,SourceRectangle, Color);
            
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

