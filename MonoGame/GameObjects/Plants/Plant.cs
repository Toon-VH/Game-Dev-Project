using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoTest.Animations;

namespace MonoTest.GameObjects.Plants
{
    public class Plant : GameObject
    {
        public Animation Animation { get; set; }
        public Vector2 Position { get; set; }
        public bool IsIntersecting { get; set; }
        public bool IsAttacking { get; set; }
        
        public float Scale { get; set; }
        private readonly Texture2D _texture;
        private readonly double _timeBetweenAttacks;
        private double _time;

        public Plant(float x, float y, Texture2D texture, int typePlant, double timeBetweenAttacks)
        {
            Damage = 3;
            Scale = 1f;
            _texture = texture;
            Position = new Vector2(x - ((_texture.Width*Scale / 14) / 2), y - ((_texture.Height*Scale / 5) / 2));
            _timeBetweenAttacks = timeBetweenAttacks;
            Animation = CreateAnimation(typePlant);
            _time = 0;
            IsIntersecting = false;
        }


        public override void Update(GameTime gameTime)
        {
            if (_time > _timeBetweenAttacks)
            {
                IsAttacking = true;
                if (Animation.AnimationDoneFlag)
                {
                    _time = 0;
                    IsAttacking = false;
                }

                Animation.Update(gameTime);
            }


            //Debug.WriteLine($"Counter: {Animation.FrameCounter}, Count: {Animation.Frames.Count}, {_time}");
            var elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
            _time += elapsed;
        }

        public override void Draw(SpriteBatch spriteBatch, GraphicsDevice graphics)
        {
            var sourceRectangle = Animation.CurrentFrame.SourceRectangle;
            spriteBatch.Draw(_texture, Position, sourceRectangle, Color.White, 0f, Vector2.Zero, Scale, SpriteEffects.None, 0f);


#if DEBUG
            // var debugR1 = new RectangleF(Position.X, Position.Y, Animation.CurrentFrame.SourceRectangle.Width, Animation.CurrentFrame.SourceRectangle.Height);
            // DebugService.DrawRectangle(spriteBatch, debugR1, 1, Color.Cyan, false);

            for (var i = 0; i < Animation.CurrentFrame.HitBoxes.Count; i++)
            {
                var hitboxX = Animation.CurrentFrame.HitBoxes[i].X + Position.X;
                var hitboxY = Animation.CurrentFrame.HitBoxes[i].Y + Position.Y;
                var debugR2 = new RectangleF(hitboxX, hitboxY, Animation.CurrentFrame.HitBoxes[i].Width, Animation.CurrentFrame.HitBoxes[i].Height);
                DebugService.DrawRectangle(spriteBatch, debugR2, 1, Color.DarkGreen, IsIntersecting);
            }
#endif
        }

        private Animation CreateAnimation(int typePlant)
        {
            var animation = new Animation(_texture.Width / 14);
            animation.GetFramesFromTextureProperties(_texture.Width, _texture.Height, 5, 14, 3, typePlant);
            CreateHitboxes(animation);
            return animation;
        }

        private void CreateHitboxes(Animation animation)
        {
            // var hitboxes = new List<RectangleF>()
            // {
            //     new RectangleF(32, 28, 22, 20), new RectangleF(22, 26, 32, 22),
            //     new RectangleF(27, 7, 28, 41), new RectangleF(34, 1, 20, 47),
            //     new RectangleF(6, 12, 43, 36), new RectangleF(16, 57, 38, 29),
            //     new RectangleF(55, 7, 28, 41), new RectangleF(34, 0, 44, 48),
            //     new RectangleF(34, 1, 20, 47), new RectangleF(27, 7, 28, 41),
            //     new RectangleF(22, 26, 32, 22),
            // };

            animation.Frames[0].HitBoxes = new List<RectangleF>() { new(32, 29, 22, 19) };
            animation.Frames[1].HitBoxes = new List<RectangleF>() { new(22, 26, 31, 9), new(44,35,10,13)};
            animation.Frames[2].HitBoxes = new List<RectangleF>() { new(27, 7, 6, 13), new(33, 15, 9, 14), new(42, 22, 6, 13), new(45, 35, 10, 13)};
            animation.Frames[3].HitBoxes = new List<RectangleF>() { new(34, 1, 7, 15), new(38,15,14,12), new(44,26,10,22) };

            animation.Frames[4].HitBoxes = new List<RectangleF>() { new(6, 12, 24, 36), new(30,25,15,23) };
            animation.Frames[5].HitBoxes = new List<RectangleF>() { new(16, 56, 38, 30) };
            animation.Frames[6].HitBoxes = new List<RectangleF>() { new(55, 41, 14, 21), new (69,44,13,35), new(82,35,10,36) };
            animation.Frames[7].HitBoxes = new List<RectangleF>() { new(35, 0, 43, 21), new(46,24,18,23) };

            animation.Frames[8].HitBoxes = new List<RectangleF>() { new(34, 1, 7, 15), new(38,15,14,12), new(44,26,10,22) };
            animation.Frames[9].HitBoxes = new List<RectangleF>() { new(27, 7, 6, 13), new(33, 15, 9, 14), new(42, 22, 6, 13), new(45, 35, 10, 13) };
            animation.Frames[10].HitBoxes = new List<RectangleF>() { new(22, 26, 31, 9), new(44,35,10,13) };
        }
    }
}