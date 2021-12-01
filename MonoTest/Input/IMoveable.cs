using Microsoft.Xna.Framework;

namespace MonoTest.Input
{
    public interface IMoveable
    {
        public Vector2 Position { get; set; }
        public Vector2 Speed { get; set; }
        public Vector2 Acceleration { get; set; }
        public IInputReader InputReader { get; set; }
        public Direction Direction { get; set;}
    }

    public enum Direction
    {
        Left,Right,Idle
    }
}
