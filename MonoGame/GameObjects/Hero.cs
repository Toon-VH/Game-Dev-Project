using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoTest.Animations;

namespace MonoTest.GameObjects
{
    public class Hero : Moveable
    {
        private readonly int _health;
        private readonly Texture2D _texture;
        private readonly Animation _walkRight;
        private readonly Animation _walkLeft;
        private readonly Animation _idle;
        private readonly Animation _rol;
        private readonly int _scale;

        public Hero(Texture2D texture)
        {
            _health = 5;
            Position = new Vector2(0, 0);
            Speed = 160f;
            Velocity = new Vector2(0, 0);
            _scale = 2;
            _texture = texture;

            _walkRight = new Animation();
            _walkLeft = new Animation();
            _idle = new Animation();
            _rol = new Animation();

            _idle.GetFramesFromTextureProperties(texture.Width, texture.Height, 7, 8, 0, 0);
            _walkRight.GetFramesFromTextureProperties(texture.Width, texture.Height, 7, 8, 0, 1);
            _walkLeft.GetFramesFromTextureProperties(texture.Width, texture.Height, 7, 8, 0, 1);
            _rol.GetFramesFromTextureProperties(texture.Width, texture.Height, 7, 8, 1, 2);

            BoundingBox = new RectangleF(25 * _scale, 6 * _scale, 16 * _scale, 22 * _scale);
            //CreateHitboxes();
            CurrentAnimation = _idle;
        }

        // private void CreateHitboxes()
        // {
        //     var rectangle = new RectangleF(25 * _scale, 6 * _scale, 16* _scale, 22* _scale);
        //
        //     var hitBoxesIdle = new List<RectangleF>()
        //     {
        //         rectangle, rectangle, rectangle,
        //         rectangle, rectangle, rectangle,
        //         rectangle, rectangle
        //     };
        //
        //     var hitBoxesWalkRight = new List<RectangleF>()
        //     {
        //         rectangle, rectangle, rectangle,
        //         rectangle, rectangle, rectangle,
        //         rectangle, rectangle
        //     };
        //
        //     var hitBoxesWalkLeft = new List<RectangleF>()
        //     {
        //         rectangle, rectangle, rectangle,
        //         rectangle, rectangle, rectangle,
        //         rectangle, rectangle
        //     };
        //
        //     _idle.AddHitboxList(hitBoxesIdle);
        //     _walkRight.AddHitboxList(hitBoxesWalkRight);
        //     _walkLeft.AddHitboxList(hitBoxesWalkLeft);
        // }

        public override void Draw(SpriteBatch spriteBatch, GraphicsDevice graphicsDevice)
        {
            //Debug 
            var rectangle = new RectangleF((int)Position.X + BoundingBox.X, (int)Position.Y + BoundingBox.Y,
                BoundingBox.Width, BoundingBox.Height);
            DebugService.DrawRectangle(spriteBatch, rectangle, 2, IsIntersecting);
            //End

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
            spriteBatch.Draw(_texture, new Vector2(Position.X, Position.Y), sourceRectangle, Color.White, 0f,
                Vector2.Zero, _scale, flip ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0f);

            CurrentAnimation = animation;

            //Debug
            // var rectangle = new RectangleF((int)Position.X, (int)Position.Y, sourceRectangle.Width * _scale,
            //     sourceRectangle.Height * _scale);
            // DebugService.DrawRectangle(spriteBatch, rectangle, 1, false);
            //End
        }
    }
}