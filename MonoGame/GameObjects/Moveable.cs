using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoTest.GameObjects
{
    public abstract class Moveable : GameObject
    {
        public MoveableAction CurrentAction { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }
        public RectangleF BoundingBox { get; set; }
        public bool IsTouchingGround { get; set; }
        public bool IsIntersecting { get; set; }
        public bool IsInvulnerable { get; set; }
        public float Scale { get; protected set; }
        public float Speed { get; protected set; }
        public int InitialHealth { get; set; }
        public int Health { get; set; }

        private readonly IDictionary<(MoveableActionType actionType, MoveableActionDirection direction), (string animationKey, bool invert)> _actionAnimationMap;

        protected float InvulnerableTime { get; set; }
        protected Color Color { get; set; }

        protected Moveable()
        {
            Color = Color.White;
            CurrentAction = new MoveableAction(MoveableActionType.Idle, MoveableActionDirection.Static);
            _actionAnimationMap =
                new Dictionary<(MoveableActionType actionType, MoveableActionDirection direction), (string animationKey,
                    bool invert)>();
        }

        public abstract void GetDamage(int amount, float invulnerableTime);

        public override void Draw(SpriteBatch spriteBatch, GraphicsDevice graphics)
        {
            
            
            var (animationKey, invert)= _actionAnimationMap[(CurrentAction.Action, CurrentAction.Direction)];
            var animation = Animations[animationKey];
            animation.SetFlip(invert);
            var sourceRectangle = animation.CurrentFrame.SourceRectangle;
            spriteBatch.Draw(_texture, new Vector2(Position.X, Position.Y), sourceRectangle, Color, 0f, Vector2.Zero, Scale, invert ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0f);
            SetCurrentAnimation(animationKey);
        }

        protected void MapAnimationToAction(string animationKey, bool invert, MoveableActionType actionType,  MoveableActionDirection direction)
        {
            _actionAnimationMap.Add((actionType, direction), (animationKey, invert));
        }
    }
}