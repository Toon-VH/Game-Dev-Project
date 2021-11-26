using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoTest.Interaces;
using MonoTest.Managers;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace MonoTest
{
    class Hero : IGameObject, IMoveable
    {

        private Texture2D texture;

        private Animation Walk;
        private Animation Idle;
        private Animation Rol;

        public Vector2 Position { get; set; }
        public Vector2 Speed { get; set; }
        public Vector2 Acceleration { get; set; }
        public IInputReader InputReader { get; set; }
        public Direction Direction { get; set; }

        private MovementManager movementManager;
        

        public Hero(Texture2D texture, IInputReader inputReader)
        {
            Position = new Vector2(1, 1);
            Speed = new Vector2(1, 1);
            Acceleration = new Vector2(0.1f, 0.1f);
            this.texture = texture;
            this.InputReader = inputReader;
            this.movementManager = new MovementManager();
            this.Walk = new Animation();
            this.Idle = new Animation();
            this.Rol = new Animation();

            /*this.WalkLeft.GetFramesFromTextureProperties(718, texture.Width, 70, 15, 3);
            this.WalkRight.GetFramesFromTextureProperties(77, texture.Width, 70, 15, 3);
            this.Idle.GetFramesFromTextureProperties(10, texture.Width, 70, 15, 0);*/

            this.Idle.GetFramesFromTextureProperties(texture.Width, texture.Height, 7, 8, 0, 0);
            this.Walk.GetFramesFromTextureProperties(texture.Width, texture.Height, 7, 8, 0, 1);
            this.Rol.GetFramesFromTextureProperties(texture.Width, texture.Height, 7, 8, 1, 2);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            switch (Direction)
            {
                case Direction.Left:
                    spriteBatch.Draw(texture, Position, Walk.CurrentFrame.SourceRectangle, Color.White, 0f, Vector2.Zero, 0.8f, SpriteEffects.FlipHorizontally, 0f);
                    break;
                case Direction.Right:
                    spriteBatch.Draw(texture, Position, Rol.CurrentFrame.SourceRectangle, Color.White, 0f, Vector2.Zero, 0.8f, SpriteEffects.None, 0f);
                    break;
                case Direction.Idle:
                    spriteBatch.Draw(texture, Position, Idle.CurrentFrame.SourceRectangle, Color.White, 0f, Vector2.Zero, 0.8f, SpriteEffects.None, 0f);
                    break;
            }
        }

        public void Update(GameTime gameTime)
        {
            Move();
            switch (Direction)
            {
                case Direction.Left:
                    Walk.Update(gameTime);
                    break;
                case Direction.Right:
                    Rol.Update(gameTime);
                    break;
                case Direction.Idle:
                    Idle.Update(gameTime);
                    break;
            }
        }

        private void Move()
        {
            movementManager.Move(this);
        }

        private Vector2 Limit(Vector2 v, float max)
        {
            if (v.Length() > max)
            {
                var ratio = max / v.Length();
                v.X *= ratio;
                v.Y *= ratio;
            }
            return v;
        }

        public void ChangeInput(IInputReader inputReader)
        {
            this.InputReader = inputReader;
        }

    }
}
