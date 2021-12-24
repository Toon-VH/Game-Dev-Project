using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoTest.Animations;
using MonoTest.GameObjects;

namespace MonoTest.Map.Plants
{
    public class Plant : IGameObject
    {
        private readonly Vector2 _position;
        private readonly Animation _animation;
        private readonly Texture2D _texture;
        private readonly double _timeBetweenAttacks;
        private double _time;
        private bool _attack;
        private readonly bool _isIntersecting;


        public Plant(int x, int y, Texture2D texture, int typePlant, double timeBetweenAttacks)
        {
            _position = new Vector2(x, y);
            _texture = texture;
            _timeBetweenAttacks = timeBetweenAttacks;
            _animation = CreateAnimation(typePlant);
            _time = 0;
            _isIntersecting = false;
        }


        public void Update(GameTime gameTime)
        {
            var t = false;
            if (_time > _timeBetweenAttacks)
            {
                t = true;
                if (_animation.AnimationDoneFlag)
                {
                    _time = 0;
                }

                _animation.Update(gameTime);
            }

            Debug.WriteLine($"Counter: {_animation.Counter}, Count: {_animation.Frames.Count}, {_time},{t}");
            var elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
            _time += elapsed;
        }

        public void Draw(SpriteBatch spriteBatch, GraphicsDevice graphics)
        {
            var sourceRectangle = _animation.CurrentFrame.SourceRectangle;
            var position = _position - new Vector2(sourceRectangle.Width / 2, sourceRectangle.Height / 2);
            spriteBatch.Draw(_texture, position, sourceRectangle, Color.White, 0f, Vector2.Zero, 1f,
                SpriteEffects.None, 0f);


            //Debug
            var drawRectangleX = _position.X - sourceRectangle.Width / 2;
            var drawRectangleY = _position.Y - sourceRectangle.Height / 2;

            var debugR1 = new RectangleF((int)drawRectangleX, (int)drawRectangleY,
                _animation.CurrentFrame.SourceRectangle.Width, _animation.CurrentFrame.SourceRectangle.Height);
            //DebugService.DrawRectangle(spriteBatch, debugR1, 1, false);


            var hitboxX = _animation.CurrentHitbox.X + _position.X - sourceRectangle.Width / 2;
            var hitboxY = _animation.CurrentHitbox.Y + _position.Y - sourceRectangle.Height / 2;

            var debugR2 = new RectangleF(hitboxX, hitboxY, _animation.CurrentHitbox.Width,
                _animation.CurrentHitbox.Height);
            DebugService.DrawRectangle(spriteBatch, debugR2, 1, _isIntersecting);
            //End
        }

        private Animation CreateAnimation(int typePlant)
        {
            var animation = new Animation();
            animation.GetFramesFromTextureProperties(_texture.Width, _texture.Height, 5, 14, 3, typePlant);
            CreateHitboxes(animation);
            return animation;
        }

        private void CreateHitboxes(Animation animation)
        {
            var hitboxes = new List<RectangleF>()
            {
                new RectangleF(32, 28, 22, 20), new RectangleF(22, 26, 32, 22),
                new RectangleF(27, 7, 28, 41), new RectangleF(34, 1, 20, 47),
                new RectangleF(6, 12, 43, 36), new RectangleF(16, 57, 38, 29),
                new RectangleF(55, 7, 28, 41), new RectangleF(34, 0, 44, 48),
                new RectangleF(34, 1, 20, 47), new RectangleF(27, 7, 28, 41),
                new RectangleF(22, 26, 32, 22),
            };
            animation.AddHitboxList(hitboxes);
        }
    }
}