using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoTest.GameObjects;

namespace MonoTest.Input
{
    public abstract class Moveable: IGameObject
    {
        public Vector2 Position { get; set; }
        public Vector2 Speed { get; set; }
        public Vector2 Acceleration { get; set; }
        public IInputReader InputReader { get; set; }
        public Vector2 Direction { get; set;}
        
        public AbsoluteDirection AbsoluteDirection {
            get
            {
                if (Direction.Y > 0) return AbsoluteDirection.Up;
                if (Direction.Y < 0) return AbsoluteDirection.Down;
                if (Direction.X > 0) return AbsoluteDirection.Right;
                if (Direction.X < 0) return AbsoluteDirection.Left;
                return AbsoluteDirection.Idle;
            }
        }

        public abstract void Update(GameTime gameTime);

        public abstract void Draw(SpriteBatch spriteBatch, GraphicsDevice graphics);
    }

    public enum AbsoluteDirection
    {
        Left,Right,Idle, Up, Down
    }
}
