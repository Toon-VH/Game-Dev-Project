using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoTest.Input;
using MonoTest.Animations;

namespace MonoTest.GameObjects
{
    public class Hero : Moveable
    {
        private readonly Texture2D _texture;
        private readonly Animation _walk;
        private readonly Animation _idle;
        private readonly Animation _rol;
        private Animation _currentAnimation;

        public Hero(Texture2D texture, IInputReader inputReader)
        {
            Position = new Vector2(500, 182);
            Speed = new Vector2(1, 1);
            Acceleration = new Vector2(0.1f, 0.1f);
            _texture = texture;
            InputReader = inputReader;
            _walk = new Animation();
            _idle = new Animation();
            _rol = new Animation();

            _idle.GetFramesFromTextureProperties(texture.Width, texture.Height, 7, 8, 0, 0);
            _walk.GetFramesFromTextureProperties(texture.Width, texture.Height, 7, 8, 0, 1);
            _rol.GetFramesFromTextureProperties(texture.Width, texture.Height, 7, 8, 1, 2);

            _currentAnimation = _idle;
        }

        public override void Draw(SpriteBatch spriteBatch, GraphicsDevice graphicsDevice)
        {
            DrawRectangle(spriteBatch,Color.Red, 1);
            switch (AbsoluteDirection)
            {
                case AbsoluteDirection.Left:
                    DrawAnimation(spriteBatch, _walk, true);
                    break;
                case AbsoluteDirection.Right:
                    DrawAnimation(spriteBatch, _walk);
                    break;
                case AbsoluteDirection.Up:
                case AbsoluteDirection.Down:
                case AbsoluteDirection.Idle:
                    DrawAnimation(spriteBatch, _idle);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public override void Update(GameTime gameTime) => _currentAnimation.Update(gameTime);


        private void DrawAnimation(SpriteBatch spriteBatch, Animation animation, bool flip = false)
        {
            spriteBatch.Draw(_texture, Position, animation.CurrentFrame.SourceRectangle, Color.White, 0f, Vector2.Zero,
                0.8f, flip ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0f);

            _currentAnimation = animation;
        }


        private void DrawRectangle(SpriteBatch spriteBatch, Color color, int lineWidth)
        {
            
            var width = _currentAnimation.CurrentFrame.SourceRectangle.Width;
            var height = _currentAnimation.CurrentFrame.SourceRectangle.Height;

            var rectangle = new Rectangle((int)Position.X, (int)Position.Y, width, height);
            
            var pointTexture = new Texture2D(spriteBatch.GraphicsDevice, 1, 1);
            pointTexture.SetData<Color>(new Color[] { Color.White });


            spriteBatch.Draw(pointTexture,
                new Rectangle(rectangle.X, rectangle.Y, lineWidth, rectangle.Height + lineWidth), color);
            spriteBatch.Draw(pointTexture,
                new Rectangle(rectangle.X, rectangle.Y, rectangle.Width + lineWidth, lineWidth), color);
            spriteBatch.Draw(pointTexture,
                new Rectangle(rectangle.X + rectangle.Width, rectangle.Y, lineWidth, rectangle.Height + lineWidth),
                color);
            spriteBatch.Draw(pointTexture,
                new Rectangle(rectangle.X, rectangle.Y + rectangle.Height, rectangle.Width + lineWidth, lineWidth),
                color);
        }
    }
}