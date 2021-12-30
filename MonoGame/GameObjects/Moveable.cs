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
        public MoveableAction CurrentAction { get; set; }

        public Moveable()
        {
            CurrentAction = new MoveableAction(MoveableActionType.Idle, MoveableActionDirection.Static);
        }

        public abstract void Update(GameTime gameTime);

        public abstract void Draw(SpriteBatch spriteBatch, GraphicsDevice graphics);

        public abstract void GetDamage(int amount, float invulnerableTime);
    }
}