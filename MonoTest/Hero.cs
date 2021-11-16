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
        private Animation WalkLeft;
        private Animation WalkRight;
        private Animation Idle;

        public Vector2 Position { get; set; }
        public Vector2 Speed { get; set; }
        public Vector2 Acceleration { get; set; }
        public IInputReader InputReader { get; set; }
        public Direction Direction { get; set; }

        private MovementManager movementManager;
        

        public Hero(Texture2D texture, IInputReader inputReader)
        {
            Position = new Vector2(1, 1);
            Speed = new Vector2(2, 2);
            Acceleration = new Vector2(0.1f, 0.1f);
            this.texture = texture;
            this.InputReader = inputReader;
            this.movementManager = new MovementManager();
            this.WalkLeft = new Animation();
            this.WalkRight = new Animation();
            this.Idle = new Animation();

            /*this.WalkLeft.GetFramesFromTextureProperties(718, texture.Width, 70, 15, 3);
            this.WalkRight.GetFramesFromTextureProperties(77, texture.Width, 70, 15, 3);
            this.Idle.GetFramesFromTextureProperties(10, texture.Width, 70, 15, 0);*/

            this.Idle.GetFramesFromTextureProperties(0, texture.Width, 36, 8, 0);
            this.WalkLeft.GetFramesFromTextureProperties(36, texture.Width, 36, 8, 0);
            this.WalkRight.GetFramesFromTextureProperties(36, texture.Width, 36, 8, 0);


        }

        public void Draw(SpriteBatch spriteBatch)
        {
            switch (Direction)
            {
                case Direction.Left:
                    spriteBatch.Draw(texture, Position, WalkLeft.CurrentFrame.SourceRectangle, Color.White, 0f, Vector2.Zero, 1.8f, SpriteEffects.None, 0f);
                    Debug.WriteLine("Left");
                    break;
                case Direction.Right:
                    spriteBatch.Draw(texture, Position, WalkRight.CurrentFrame.SourceRectangle, Color.White, 0f, Vector2.Zero, 1.8f, SpriteEffects.None, 0f);

                    Debug.WriteLine("Right");
                    break;
                case Direction.Idle:
                    spriteBatch.Draw(texture, Position, Idle.CurrentFrame.SourceRectangle, Color.White, 0f, Vector2.Zero, 1.8f, SpriteEffects.None, 0f);

                    Debug.WriteLine("Idle");
                    break;
            }
        }

        public void Update(GameTime gameTime)
        {
            Move();
            switch (Direction)
            {
                case Direction.Left:
                    WalkLeft.Update(gameTime);
                    break;
                case Direction.Right:
                    WalkRight.Update(gameTime);
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
