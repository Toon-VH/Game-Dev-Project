using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoTest.Animations;

namespace MonoTest.GameObjects
{
    public class Hero : Moveable
    {
        private readonly Texture2D _texture;
        private readonly Animation _walkRight;
        private readonly Animation _walkLeft;
        private readonly Animation _idle;
        private readonly Animation _rol;
        private readonly int _scale;

        public Hero(Texture2D texture)
        {
            _scale = 2;
            Position = new Vector2(0, 0);
            Speed = 160f;
            Velocity = new Vector2(0, 0);
            _texture = texture;

            _walkRight = new Animation();
            _walkLeft = new Animation();
            _idle = new Animation();
            _rol = new Animation();

            _idle.GetFramesFromTextureProperties(texture.Width, texture.Height, 7, 8, 0, 0);
            _walkRight.GetFramesFromTextureProperties(texture.Width, texture.Height, 7, 8, 0, 1);
            _walkLeft.GetFramesFromTextureProperties(texture.Width, texture.Height, 7, 8, 0, 1);
            _rol.GetFramesFromTextureProperties(texture.Width, texture.Height, 7, 8, 1, 2);
            CreateHitboxes();
            CurrentAnimation = _idle;
        }

        private void CreateHitboxes()
        {
            var rectangle = new RectangleF(25 * _scale, 6 * _scale, 16* _scale, 22* _scale);

            var hitBoxesIdle = new List<RectangleF>()
            {
                rectangle, rectangle, rectangle,
                rectangle, rectangle, rectangle,
                rectangle, rectangle
            };

            // var hitBoxesWalkRight = new List<Rectangle>()
            // {
            //     new Rectangle(26, 6, 15, 22), new Rectangle(26, 5, 14, 20), new Rectangle(26, 3, 14, 20),
            //     new Rectangle(26, 4, 14, 21), new Rectangle(26, 6, 15, 22), new Rectangle(26, 5, 17, 20),
            //     new Rectangle(26, 3, 17, 21), new Rectangle(26, 4, 17, 21)
            // };
            //
            // var hitBoxesWalkLeft = new List<Rectangle>()
            // {
            //     new Rectangle(23, 6, 15, 22), new Rectangle(24, 5, 14, 20), new Rectangle(24, 3, 14, 20),
            //     new Rectangle(24, 4, 14, 21), new Rectangle(23, 6, 15, 22), new Rectangle(21, 5, 17, 20),
            //     new Rectangle(21, 3, 17, 21), new Rectangle(21, 4, 17, 21)
            // };
            
            var hitBoxesWalkRight = new List<RectangleF>()
            {
                rectangle, rectangle, rectangle,
                rectangle, rectangle, rectangle,
                rectangle, rectangle
            };

            var hitBoxesWalkLeft = new List<RectangleF>()
            {
                rectangle, rectangle, rectangle,
                rectangle, rectangle, rectangle,
                rectangle, rectangle
            };

            _idle.AddHitboxList(hitBoxesIdle);
            _walkRight.AddHitboxList(hitBoxesWalkRight);
            _walkLeft.AddHitboxList(hitBoxesWalkLeft);
        }

        public override void Draw(SpriteBatch spriteBatch, GraphicsDevice graphicsDevice)
        {
            var width = CurrentAnimation.CurrentHitbox.Width;
            var height = CurrentAnimation.CurrentHitbox.Height;

            var rectangle = new RectangleF(
                (int)Position.X + CurrentAnimation.CurrentHitbox.X,
                (int)Position.Y + CurrentAnimation.CurrentHitbox.Y, width,
                height);

            DrawRectangle(spriteBatch, rectangle, 2);
            
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

        public override void Update(GameTime gameTime) => CurrentAnimation.Update(gameTime);


        private void DrawAnimation(SpriteBatch spriteBatch, Animation animation, bool flip = false)
        {
            var sourceRectangle = animation.CurrentFrame.SourceRectangle;
            spriteBatch.Draw(_texture, new Vector2(Position.X, Position.Y), sourceRectangle , Color.White, 0f, Vector2.Zero, _scale, flip ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0f);
            
            // var rectangle = new Rectangle((int)Position.X, (int)Position.Y, sourceRectangle.Width * (int)Scale,
            //     sourceRectangle.Height * (int)Scale);
            // DrawRectangle(spriteBatch, rectangle, 1);
            
            CurrentAnimation = animation;
        }

        private void DrawRectangle(SpriteBatch spriteBatch, RectangleF rectangle, int lineWidth)
        {
            var color = IsIntersecting ? Color.Red : Color.Green;
            var pointTexture = new Texture2D(spriteBatch.GraphicsDevice, 1, 1);
            pointTexture.SetData(new[]
            {
                Color.White
            });
            
            
            
            spriteBatch.Draw(pointTexture, rectangle.Position, null , color, 0f, Vector2.Zero, new Vector2(rectangle.Width,lineWidth), SpriteEffects.None, 0f);
            spriteBatch.Draw(pointTexture, rectangle.Position, null , color, 0f, Vector2.Zero, new Vector2(lineWidth,rectangle.Height), SpriteEffects.None, 0f);
            spriteBatch.Draw(pointTexture, new Vector2(rectangle.X + rectangle.Width, rectangle.Y), null , color, 0f, Vector2.Zero, new Vector2(lineWidth,rectangle.Height), SpriteEffects.None, 0f);
            spriteBatch.Draw(pointTexture, new Vector2(rectangle.X ,rectangle.Y+ rectangle.Height), null , color, 0f, Vector2.Zero, new Vector2(rectangle.Width +lineWidth,lineWidth), SpriteEffects.None, 0f);

            // spriteBatch.Draw(pointTexture, new Rectangle(rectangle.X, rectangle.Y, lineWidth, rectangle.Height + lineWidth), color);
            // spriteBatch.Draw(pointTexture,
            //      new Rectangle(rectangle.X, rectangle.Y, rectangle.Width + lineWidth, lineWidth), color);
            //  spriteBatch.Draw(pointTexture,
            //      new Rectangle(rectangle.X + rectangle.Width, rectangle.Y, lineWidth, rectangle.Height + lineWidth),
            //      color);
            //  spriteBatch.Draw(pointTexture,
            //      new Rectangle(rectangle.X , rectangle.Y + rectangle.Height, rectangle.Width + lineWidth, lineWidth),
            //      color);
        }
    }
}