using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace MonoTest
{
    public struct RectangleF
    {
        public float X;
        public float Y;
        public float Width;
        public float Height;

        public RectangleF(float x, float y, float width, float height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public float Top => Y;

        public float Bottom => Y + Height;

        public float Left => X;

        public float Right => X + Width;

        public Vector2 Position => new Vector2(X, Y);

        public bool Intersects(RectangleF value)
        {
            return value.Left < Right && Left < value.Right && value.Top < Bottom && Top < value.Bottom;
        }

        public bool Intersects(Rectangle value)
        {
            return value.Left < Right && Left < value.Right && value.Top < Bottom && Top < value.Bottom;
        }

        public RectangleF Mirror(int localWidth)
        {
            return new RectangleF(localWidth - X - Width, Y, Width, Height);
        }
    }
}