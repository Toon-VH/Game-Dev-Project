using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using MonoTest.Animations;

namespace MonoTest.GameObjects
{
    public class Hero : Moveable
    {
        public int InitialHealth { get; set; }
        public int Health { get; set; }
        private readonly Texture2D _texture;
        private readonly Animation _walk;
        private readonly Animation _idle;
        private readonly Animation _rol;
        private readonly Animation _attack;
        private readonly int _scale;
        private SoundEffect _hitSound;

        public Hero(Texture2D texture, SoundEffect hitSound)
        {
            InitialHealth = 20;
            Health = InitialHealth;
            Position = new Vector2(30, 200);

            Speed = 160f;
            Velocity = new Vector2(0, 0);
            _scale = 2;
            _texture = texture;
            _hitSound = hitSound;

            _walk = new Animation();
            _idle = new Animation();
            _rol = new Animation();
            _attack = new Animation();

            _idle.GetFramesFromTextureProperties(texture.Width, texture.Height, 7, 8, 0, 0);
            _walk.GetFramesFromTextureProperties(texture.Width, texture.Height, 7, 8, 0, 1);
            _rol.GetFramesFromTextureProperties(texture.Width, texture.Height, 7, 8, 1, 2);
            _attack.GetFramesFromTextureProperties(texture.Width, texture.Height, 7, 8, 2, 3);

            BoundingBox = new RectangleF(25 * _scale, 6 * _scale, 16 * _scale, 22 * _scale);
            //CreateHitboxes();
            CurrentAnimation = _idle;
        }


        public override void Draw(SpriteBatch spriteBatch, GraphicsDevice graphicsDevice)
        {
#if DEBUG
            var rectangle = new RectangleF((int)Position.X + BoundingBox.X, (int)Position.Y + BoundingBox.Y,
                BoundingBox.Width, BoundingBox.Height);
            DebugService.DrawRectangle(spriteBatch, rectangle, 2, IsIntersecting);
#endif
            
            switch (CurrentAction.Action)
            {
                case MoveableActionType.Running:
                    if (CurrentAction.Direction == MoveableActionDirection.Left)DrawAnimation(spriteBatch, _walk, true);
                    if (CurrentAction.Direction == MoveableActionDirection.Right)DrawAnimation(spriteBatch, _walk);
                    break;
                case MoveableActionType.Idle:
                    DrawAnimation(spriteBatch, _idle);
                    break;
                case MoveableActionType.Attacking:
                    if (CurrentAction.Direction == MoveableActionDirection.Left)DrawAnimation(spriteBatch, _attack, true);
                    if (CurrentAction.Direction == MoveableActionDirection.Right)DrawAnimation(spriteBatch, _attack);
                    break;
                case MoveableActionType.Rolling:
                    if (CurrentAction.Direction == MoveableActionDirection.Left)DrawAnimation(spriteBatch, _rol, true);
                    if (CurrentAction.Direction == MoveableActionDirection.Right)DrawAnimation(spriteBatch, _rol);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }


        // public void Action(Actions action)
        // {
        //     _inAction = true;
        //     switch (action)
        //     {
        //         case Actions.Attack:
        //             CurrentAnimation = _attack;
        //             break;
        //         case Actions.Rol:
        //             CurrentAnimation = _rol;
        //             break;
        //         default:
        //             throw new ArgumentOutOfRangeException(nameof(action), action, null);
        //     }
        // }

        public override void GetDamage(int amount, float invulnerableTime)
        {
            if (InvulnerableTime <= 0)
            {
                Health -= amount;
                InvulnerableTime = invulnerableTime;
                _hitSound.Play();
            }

            Color = new Color(255, 120, 120);
        }

        public override void Update(GameTime gameTime)
        {
            if (InvulnerableTime <= 0)
            {
                Color = Color.White;
            }
            else InvulnerableTime -= (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (CurrentAnimation.AnimationDoneFlag)
            {
                CurrentAction.Action = MoveableActionType.Idle;
            }
            CurrentAnimation.Update(gameTime);
        }


        private void DrawAnimation(SpriteBatch spriteBatch, Animation animation, bool flip = false)
        {
            var sourceRectangle = animation.CurrentFrame.SourceRectangle;
            spriteBatch.Draw(_texture, new Vector2(Position.X, Position.Y), sourceRectangle, Color, 0f,
                Vector2.Zero, _scale, flip ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0f);
            CurrentAnimation = animation;

#if DEBUG
            var rectangle = new RectangleF((int)Position.X, (int)Position.Y, sourceRectangle.Width * _scale,
                sourceRectangle.Height * _scale);
            DebugService.DrawRectangle(spriteBatch, rectangle, 1, false);
#endif
        }
    }
}