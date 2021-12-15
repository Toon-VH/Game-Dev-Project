using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace MonoTest.Controls
{
    class Button : Component
    {
        private MouseState _currentMouseState;
        private SpriteFont _font;
        private bool _isHovering;
        private MouseState _previousMouse;
        private Texture2D _texture;

        public event EventHandler Click;
        public bool Clicked { get; private set; }
        public Color PenColor { get; set; }
        public Vector2 Position { get; set; }

        public Rectangle Rectangle 
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, _texture.Width, _texture.Height);
            } 
            
        }

        public string Text { get; set; }


        public Button(Texture2D texture , SpriteFont spriteFont)
        {
            _texture = texture;
            _font = spriteFont;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            var color = Color.White;
            if (_isHovering)
                color = Color.Gray;

            spriteBatch.Draw(_texture, Rectangle, color);

            if (!string.IsNullOrEmpty(Text))
            {
                var x =(Rectangle.X +(Rectangle.Width/2))-(_font.MeasureString(Text).X/2);
                var y = (Rectangle.Y + (Rectangle.Height / 2)) - (_font.MeasureString(Text).Y / 2);
                spriteBatch.DrawString(_font, Text, new Vector2(x, y), PenColor);
            }
        }

        public override void Update(GameTime gameTime)
        {
            _previousMouse = _currentMouseState;
            _currentMouseState = Mouse.GetState();
            
            var postionMouse = new Vector2(_currentMouseState.X, _currentMouseState.Y);
            var scaledMousePosition = Vector2.Transform(postionMouse, Matrix.Invert(GameEngine._displayManager.CalculateMatrix()));
            var mouseRectangle = new Rectangle((int)scaledMousePosition.X, (int)scaledMousePosition.Y, 1, 1);
          
            _isHovering = false;
            if (mouseRectangle.Intersects(Rectangle))
            {
                _isHovering = true;

                if (_currentMouseState.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Released && _previousMouse.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
                {
                    Click?.Invoke(this, new EventArgs());


                }
            }
        }


    }
}
