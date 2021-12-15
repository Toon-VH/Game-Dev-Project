using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonoTest.Screens
{
    public interface IScreen
    {
        void Update(GameTime delta);

        void Draw(SpriteBatch spriteBatch);
    }
}
