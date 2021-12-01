using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoTest.Input;
using MonoTest.Managers;

namespace MonoTest.GameObjects
{
    class Hero : IMoveable
    {

        private readonly Texture2D _texture;

        private readonly Animation _walk;
        private readonly Animation _idle;
        private readonly Animation _rol;

        public Vector2 Position { get; set; }
        public Vector2 Speed { get; set; }
        public Vector2 Acceleration { get; set; }
        public IInputReader InputReader { get; set; }
        public Direction Direction { get; set; }

        private readonly MovementManager _movementManager;
        

        public Hero(Texture2D texture, IInputReader inputReader)
        {
            Position = new Vector2(500, 182);
            Speed = new Vector2(1, 1);
            Acceleration = new Vector2(0.1f, 0.1f);
            this._texture = texture;
            InputReader = inputReader;
            _movementManager = new MovementManager();
            _walk = new Animation();
            _idle = new Animation();
            _rol = new Animation();

            _idle.GetFramesFromTextureProperties(texture.Width, texture.Height, 7, 8, 0, 0);
            _walk.GetFramesFromTextureProperties(texture.Width, texture.Height, 7, 8, 0, 1);
            _rol.GetFramesFromTextureProperties(texture.Width, texture.Height, 7, 8, 1, 2);
        }

        public void Draw(SpriteBatch spriteBatch, GraphicsDevice graphicsDevice)
        {
            switch (Direction)
            {
                case Direction.Left:
                    spriteBatch.Draw(_texture, Position, _walk.CurrentFrame.SourceRectangle, Color.White, 0f, Vector2.Zero, 0.8f, SpriteEffects.FlipHorizontally, 0f);
                    break;
                case Direction.Right:
                    spriteBatch.Draw(_texture, Position, _walk.CurrentFrame.SourceRectangle, Color.White, 0f, Vector2.Zero, 0.8f, SpriteEffects.None, 0f);
                    break;
                case Direction.Idle:
                    spriteBatch.Draw(_texture, Position, _idle.CurrentFrame.SourceRectangle, Color.White, 0f, Vector2.Zero, 0.8f, SpriteEffects.None, 0f);
                    break;
            }
        }

        public void Update(GameTime gameTime)
        {
            switch (Direction)
            {
                case Direction.Left:
                    _walk.Update(gameTime);
                    break;
                case Direction.Right:
                    _walk.Update(gameTime);
                    break;
                case Direction.Idle:
                    _idle.Update(gameTime);
                    break;
            }
        }

        // private Vector2 Limit(Vector2 v, float max)
        // {
        //     if (v.Length() > max)
        //     {
        //         var ratio = max / v.Length();
        //         v.X *= ratio;
        //         v.Y *= ratio;
        //     }
        //     return v;
        // }

        // public void ChangeInput(IInputReader inputReader)
        // {
        //     this.InputReader = inputReader;
        // }

    }
}
