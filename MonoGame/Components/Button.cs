using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoTest.Components
{
    public class Button : IComponent
    {
        private MouseState _currentMouseState;
        private MouseState _previousMouse;
        private readonly SpriteFont _font;
        private readonly Texture2D _texture;
        private bool _isHovering;
        private RectangleF _rectangleMouse;

        public Color PenColor { get; set; }
        public Vector2 Position { get; set; }
        public string Text { get; set; }

        public event EventHandler Click;

        public Button(Texture2D texture, SpriteFont spriteFont)
        {
            _texture = texture;
            _font = spriteFont;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            var rectangle = GetRectangle();
            var color = Color.White;
            if (_isHovering) color = Color.Gray;

            spriteBatch.Draw(_texture, GetRectangle(), color);

            if (string.IsNullOrEmpty(Text)) return;
            var x = (rectangle.X + (rectangle.Width / 2)) - (_font.MeasureString(Text).X / 2);
            var y = (rectangle.Y + (rectangle.Height / 2)) - (_font.MeasureString(Text).Y / 2);
            spriteBatch.DrawString(_font, Text, new Vector2(x, y), PenColor);
            
            DebugService.DrawRectangle(spriteBatch,_rectangleMouse,1,Color.Cyan, false);
            
        }

        public void Update(GameTime gameTime, Matrix matrix)
        {
            _previousMouse = _currentMouseState;
            _currentMouseState = Mouse.GetState();
            

            var positionMouse = new Vector2(_currentMouseState.X, _currentMouseState.Y);
            //Debug.WriteLine($"{positionMouse.X}{positionMouse.Y}");
            var (x, y) = Vector2.Transform(positionMouse, Matrix.Invert(matrix));
            _rectangleMouse = new RectangleF((int)x, (int)y, 1, 1);
                


            _isHovering = false;
            if (!_rectangleMouse.Intersects(GetRectangle())) return;
            _isHovering = true;

            if (_currentMouseState.LeftButton == ButtonState.Released &&
                _previousMouse.LeftButton == ButtonState.Pressed)
            {
                Click?.Invoke(this, EventArgs.Empty);
            }
        }

        private Rectangle GetRectangle() =>
            new Rectangle((int)Position.X, (int)Position.Y, _texture.Width, _texture.Height);
    }
}