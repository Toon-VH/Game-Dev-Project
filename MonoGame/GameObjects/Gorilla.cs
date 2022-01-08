using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using MonoTest.Animations;

namespace MonoTest.GameObjects
{
    public partial class Gorilla : Moveable
    {
        private readonly Animation _walk;
        private readonly Animation _angryWalk;
        private readonly Animation _chestPound;
        private readonly Animation _idle;
        private readonly Texture2D _texture;
        private readonly SoundEffect _roar;

        private const int Scale = 2;
        private int _health = 10;
        private bool _isAngry = false;
        private bool _poundingChest = false;
        
        public Gorilla(Texture2D texture, SoundEffect roar)
        {
            _texture = texture;
            _roar = roar;
            _walk = new Animation(64);
            _idle = new Animation(64);
            _angryWalk = new Animation(64);
            _chestPound = new Animation(64);

            _idle.GetFramesFromTextureProperties(texture.Width, texture.Height, 10, 12, 12 - 4, 0);
            _walk.GetFramesFromTextureProperties(texture.Width, texture.Height, 10, 12, 12 - 6, 1);
            _angryWalk.GetFramesFromTextureProperties(texture.Width, texture.Height, 10, 12, 12 - 6, 3);
            _chestPound.GetFramesFromTextureProperties(texture.Width, texture.Height, 10, 12, 12 - 4, 6);

            BoundingBox = new RectangleF(11 * Scale, 27 * Scale, 36 * Scale, 36 * Scale);

            SetCurrentAnimation("idle");
        }

        public override void Update(GameTime gameTime)
        {
            CurrentAnimation.Update(gameTime);
            Brains(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch, GraphicsDevice graphics)
        {
            switch (CurrentAction.Action)
            {
                case MoveableActionType.Running:
                    if (CurrentAction.Direction == MoveableActionDirection.Left)DrawAnimation(spriteBatch, _isAngry ? _angryWalk : _walk, true);
                    if (CurrentAction.Direction == MoveableActionDirection.Right)DrawAnimation(spriteBatch, _isAngry ? _angryWalk : _walk);
                    break;
                case MoveableActionType.Idle:
                    DrawAnimation(spriteBatch, _poundingChest ? _chestPound : _idle);
                    break;
                case MoveableActionType.Attacking:
                case MoveableActionType.Rolling:
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public override void GetDamage(int amount, float invulnerableTime)
        {
            throw new NotImplementedException();
        }

        private void DrawAnimation(SpriteBatch spriteBatch, Animation animation, bool flip = false)
        {
            var sourceRectangle = animation.CurrentFrame.SourceRectangle;
            spriteBatch.Draw(_texture, new Vector2(Position.X, Position.Y), sourceRectangle, Color.White, 0f, Vector2.Zero, Scale, flip ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0f);
            //TODO: FIX
            // CurrentAnimation = animation;
#if DEBUG

            var rectangle = new RectangleF(Position.X, Position.Y, sourceRectangle.Width * Scale,
                sourceRectangle.Height * Scale);
            DebugService.DrawRectangle(spriteBatch, rectangle, 1,Color.Cyan, false);
#endif
        }
    }
}