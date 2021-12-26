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
        public Animation Animation { get; set; }
        public  Vector2 Position { get; set; }
        public bool IsIntersecting { get; set; }
        public bool Attack { get; set; }
        public int Damage { get; set; } = 5;
        private readonly Texture2D _texture;
        private readonly double _timeBetweenAttacks;
        private double _time;


        public Plant(int x, int y, Texture2D texture, int typePlant, double timeBetweenAttacks)
        {
            Position = new Vector2(x, y);
            _texture = texture;
            _timeBetweenAttacks = timeBetweenAttacks;
            Animation = CreateAnimation(typePlant);
            _time = 0;
            IsIntersecting = false;
        }


        public void Update(GameTime gameTime)
        {
            if (_time > _timeBetweenAttacks)
            {
                Attack = true;
                if (Animation.AnimationDoneFlag)
                {
                    _time = 0;
                    Attack = false;
                }

                Animation.Update(gameTime);
            }
            

            Debug.WriteLine($"Counter: {Animation.Counter}, Count: {Animation.Frames.Count}, {_time}");
            var elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
            _time += elapsed;
        }

        public void Draw(SpriteBatch spriteBatch, GraphicsDevice graphics)
        {
            var sourceRectangle = Animation.CurrentFrame.SourceRectangle;
            var position = Position - new Vector2(sourceRectangle.Width / 2, sourceRectangle.Height / 2);
            spriteBatch.Draw(_texture, position, sourceRectangle, Color.White, 0f, Vector2.Zero, 1f,
                SpriteEffects.None, 0f);


#if DEBUG
                  var drawRectangleX = Position.X - sourceRectangle.Width / 2;
                  var drawRectangleY = Position.Y - sourceRectangle.Height / 2;
                  var debugR1 = new RectangleF((int)drawRectangleX, (int)drawRectangleY,
                      Animation.CurrentFrame.SourceRectangle.Width, Animation.CurrentFrame.SourceRectangle.Height);
                  DebugService.DrawRectangle(spriteBatch, debugR1, 1, false);

                  var hitboxX = Animation.CurrentHitbox.X + Position.X - sourceRectangle.Width / 2;
                  var hitboxY = Animation.CurrentHitbox.Y + Position.Y - sourceRectangle.Height / 2;
                  var debugR2 = new RectangleF(hitboxX, hitboxY, Animation.CurrentHitbox.Width,
                      Animation.CurrentHitbox.Height);
                  DebugService.DrawRectangle(spriteBatch, debugR2, 1, IsIntersecting);      
#endif
            
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