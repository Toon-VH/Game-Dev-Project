using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonoTest
{
    public interface IGameObject
    {
       
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch, GraphicsDevice graphics);

    }
}
