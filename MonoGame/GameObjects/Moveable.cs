using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoTest.Animations;

namespace MonoTest.GameObjects
{
    public abstract class Moveable : IGameObject
    {
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }
        public float Speed { get; protected set; }
        public bool IsTouchingGround { get; set; }
        public Animation CurrentAnimation { get; set; }
        public RectangleF BoundingBox { get; protected set; }
        public bool IsIntersecting { get; set; }
        protected Color Color { get; set; }
        protected float InvulnerableTime { get; set; }


        protected AbsoluteDirection AbsoluteDirection
        {
            get
            { 
                if (Velocity.X > 0) return AbsoluteDirection.Right;
                if (Velocity.X < 0) return AbsoluteDirection.Left;
                return AbsoluteDirection.Idle;
            }
        }

        public abstract void Update(GameTime gameTime);

        public abstract void Draw(SpriteBatch spriteBatch, GraphicsDevice graphics);

        public abstract void GetDamage(int amount, float invulnerableTime);
    }
}