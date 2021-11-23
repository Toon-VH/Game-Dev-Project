﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonoTest
{
    class Background
    {
        private Texture2D _backGroundTexture;
        private Texture2D _middleGroundTexture;

        public Background(Texture2D background, Texture2D middleground)
        {
            this._backGroundTexture = background;
            this._middleGroundTexture = middleground;
        }

        public void Draw(SpriteBatch spriteBatch )
        {
            spriteBatch.Draw(_backGroundTexture, new Vector2(0, 0), null, Color.White, 0f, Vector2.Zero, 3f, SpriteEffects.None, 0f);
            spriteBatch.Draw(_middleGroundTexture, new Vector2(0, 0), null, Color.White, 0f, Vector2.Zero, 3f, SpriteEffects.None, 0f);
        }
           
    }
}
