using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoTest.Input;
using MonoTest.Animations;
using SharpDX.Direct2D1.Effects;

namespace MonoTest.GameObjects
{
    public class Hero : Moveable
    {
        private readonly Texture2D _texture;
        private readonly Animation _walkRight;
        private readonly Animation _walkLeft;
        private readonly Animation _idle;
        private readonly Animation _rol;
        private Animation _currentAnimation;
        private float Scale;

        public Hero(Texture2D texture, IInputReader inputReader)
        {
            Scale = 1f;
            Position = new Vector2(200, 176);
            Speed = new Vector2(1, 1);
            Acceleration = new Vector2(0.1f, 0.1f);
            _texture = texture;
            InputReader = inputReader;

            _walkRight = new Animation();
            _walkLeft = new Animation();
            _idle = new Animation();
            _rol = new Animation();

            _idle.GetFramesFromTextureProperties(texture.Width, texture.Height, 7, 8, 0, 0);
            _walkRight.GetFramesFromTextureProperties(texture.Width, texture.Height, 7, 8, 0, 1);
            _walkLeft.GetFramesFromTextureProperties(texture.Width, texture.Height, 7, 8, 0, 1);
            _rol.GetFramesFromTextureProperties(texture.Width, texture.Height, 7, 8, 1, 2);
            CreateHitboxes();
            _currentAnimation = _idle;
        }

        private void CreateHitboxes()
        {
            var rectangle = new Rectangle(25, 6, 16, 22);

            var hitBoxesIdle = new List<Rectangle>()
            {
                rectangle, rectangle, rectangle,
                rectangle, rectangle, rectangle,
                rectangle, rectangle
            };

            var hitBoxesWalkRight = new List<Rectangle>()
            {
                new Rectangle(26, 6, 15, 22), new Rectangle(26, 5, 14, 20), new Rectangle(26, 3, 14, 20),
                new Rectangle(26, 4, 14, 21), new Rectangle(26, 6, 15, 22), new Rectangle(26, 5, 17, 20),
                new Rectangle(26, 3, 17, 21), new Rectangle(26, 4, 17, 21)
            };

            var hitBoxesWalkLeft = new List<Rectangle>()
            {
                new Rectangle(23, 6, 15, 22), new Rectangle(24, 5, 14, 20), new Rectangle(24, 3, 14, 20),
                new Rectangle(24, 4, 14, 21), new Rectangle(23, 6, 15, 22), new Rectangle(21, 5, 17, 20),
                new Rectangle(21, 3, 17, 21), new Rectangle(21, 4, 17, 21)
            };

            _idle.AddHitboxList(hitBoxesIdle);
            _walkRight.AddHitboxList(hitBoxesWalkRight);
            _walkLeft.AddHitboxList(hitBoxesWalkLeft);
        }

        public override void Draw(SpriteBatch spriteBatch, GraphicsDevice graphicsDevice)
        {
            var width = _currentAnimation.CurrentHitbox.Width;
            var height = _currentAnimation.CurrentHitbox.Height;

            var rectangle = new Rectangle(
                (int)Position.X + (int)Math.Ceiling(_currentAnimation.CurrentHitbox.X * Scale),
                (int)Position.Y + (int)(_currentAnimation.CurrentHitbox.Y * Scale), (int)Math.Ceiling(width * Scale),
                (int)Math.Ceiling(height * Scale));

            DrawRectangle(spriteBatch, Color.Red, rectangle, 1);
            switch (AbsoluteDirection)
            {
                case AbsoluteDirection.Left:
                    DrawAnimation(spriteBatch, _walkLeft, true);
                    break;
                case AbsoluteDirection.Right:
                    DrawAnimation(spriteBatch, _walkRight);
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
            var sourceRectangle = animation.CurrentFrame.SourceRectangle;
            spriteBatch.Draw(_texture, new Vector2(Position.X, Position.Y), sourceRectangle, Color.White, 0f,
                Vector2.Zero,
                Scale, flip ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0f);

            var rectangle = new Rectangle((int)Position.X, (int)Position.Y, sourceRectangle.Width,
                sourceRectangle.Height);
            DrawRectangle(spriteBatch, Color.Honeydew, rectangle, 1);
            
            _currentAnimation = animation;
        }


        private void DrawRectangle(SpriteBatch spriteBatch, Color color, Rectangle rectangle, int lineWidth)
        {
            var pointTexture = new Texture2D(spriteBatch.GraphicsDevice, 1, 1);
            pointTexture.SetData(new[]
            {
                Color.White
            });
            
            spriteBatch.Draw(pointTexture,
                new Rectangle(rectangle.X-1, rectangle.Y, lineWidth, rectangle.Height + lineWidth), color);
            spriteBatch.Draw(pointTexture,
                new Rectangle(rectangle.X-1, rectangle.Y-1, rectangle.Width + lineWidth, lineWidth), color);
            spriteBatch.Draw(pointTexture,
                new Rectangle(rectangle.X + rectangle.Width, rectangle.Y-1, lineWidth, rectangle.Height + lineWidth),
                color);
            spriteBatch.Draw(pointTexture,
                new Rectangle(rectangle.X , rectangle.Y + rectangle.Height, rectangle.Width + lineWidth, lineWidth),
                color);
        }
    }
}