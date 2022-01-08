using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;

namespace MonoTest.GameObjects
{
    public class Hero : Moveable
    {
        public int InitialHealth { get; set; }
        public int Health { get; set; }
        private readonly SoundEffect _hitSound;

        public Hero(Texture2D texture, SoundEffect hitSound)
        {
            InitialHealth = 20;
            Health = InitialHealth;
            Position = new Vector2(30, 200);

            Speed = 160f;
            Velocity = new Vector2(0, 0);
            Scale = 2;
            _texture = texture;
            _hitSound = hitSound;

            AddAnimation("walk", new HeroWalkAnimation(_texture));
            AddAnimation("idle", new HeroIdleAnimation(_texture));
            AddAnimation("roll", new HeroRollAnimation(_texture));
            AddAnimation("attack", new HeroAttackAnimation(_texture));
            AddAnimation("attackLow", new HeroAttackLowAnimation(_texture));
            AddAnimation("dead", new HeroDeadAnimation(_texture));

            MapAnimationToAction("walk", false, MoveableActionType.Running, MoveableActionDirection.Right);
            MapAnimationToAction("walk", true, MoveableActionType.Running, MoveableActionDirection.Left);
            MapAnimationToAction("idle", false, MoveableActionType.Idle, MoveableActionDirection.Right);
            MapAnimationToAction("idle", true, MoveableActionType.Idle, MoveableActionDirection.Left);
            MapAnimationToAction("idle", false, MoveableActionType.Idle, MoveableActionDirection.Static);
            MapAnimationToAction("roll", false, MoveableActionType.Rolling, MoveableActionDirection.Right);
            MapAnimationToAction("roll", true, MoveableActionType.Rolling, MoveableActionDirection.Left);
            MapAnimationToAction("attack", false, MoveableActionType.Attacking, MoveableActionDirection.Right);
            MapAnimationToAction("attack", true, MoveableActionType.Attacking, MoveableActionDirection.Left);
            MapAnimationToAction("attackLow", false, MoveableActionType.AttackingLow, MoveableActionDirection.Right);
            MapAnimationToAction("attackLow", true, MoveableActionType.AttackingLow, MoveableActionDirection.Left);
            MapAnimationToAction("dead", true, MoveableActionType.Dying, MoveableActionDirection.Left);
            MapAnimationToAction("dead", false, MoveableActionType.Dying, MoveableActionDirection.Right);
            MapAnimationToAction("dead", false, MoveableActionType.Dying, MoveableActionDirection.Static);
            
            BoundingBox = new RectangleF(28, 6, 10, 22);
            SetCurrentAnimation("idle");
        }


        public override void Draw(SpriteBatch spriteBatch, GraphicsDevice graphicsDevice)
        {
            base.Draw(spriteBatch, graphicsDevice);
#if DEBUG
            var sourceRectangle = CurrentAnimation.CurrentFrame.SourceRectangle;
            var rectangle = new RectangleF(Position.X, Position.Y, sourceRectangle.Width * Scale,
                sourceRectangle.Height * Scale);
            DebugService.DrawRectangle(spriteBatch, rectangle, 1, Color.Cyan, false);

            var rectangle2 = new RectangleF(Position.X + BoundingBox.X * Scale, Position.Y + BoundingBox.Y * Scale,
                BoundingBox.Width * Scale, BoundingBox.Height * Scale);
            DebugService.DrawRectangle(spriteBatch, rectangle2, 1, Color.Blue, IsIntersecting);

            if (CurrentAnimation.CurrentFrame.HitBoxes != null)
            {
                for (var i = 0; i < CurrentAnimation.CurrentFrame.HitBoxes.Count; i++)
                {
                    var hitboxX = CurrentAnimation.CurrentFrame.HitBoxes[i].X * Scale + Position.X;
                    var hitboxY = CurrentAnimation.CurrentFrame.HitBoxes[i].Y * Scale + Position.Y;
                    var debugR2 = new RectangleF(hitboxX, hitboxY,
                        CurrentAnimation.CurrentFrame.HitBoxes[i].Width * Scale,
                        CurrentAnimation.CurrentFrame.HitBoxes[i].Height * Scale);
                    DebugService.DrawRectangle(spriteBatch, debugR2, 1, Color.Green, false);
                }
            }

            if (CurrentAnimation.CurrentFrame.AttackBoxes != null)
            {
                for (var i = 0; i < CurrentAnimation.CurrentFrame.AttackBoxes.Count; i++)
                {
                    var hitboxX = CurrentAnimation.CurrentFrame.AttackBoxes[i].X * Scale + Position.X;
                    var hitboxY = CurrentAnimation.CurrentFrame.AttackBoxes[i].Y * Scale + Position.Y;
                    var debugR2 = new RectangleF(hitboxX, hitboxY,
                        CurrentAnimation.CurrentFrame.AttackBoxes[i].Width * Scale,
                        CurrentAnimation.CurrentFrame.AttackBoxes[i].Height * Scale);
                    DebugService.DrawRectangle(spriteBatch, debugR2, 1, Color.Yellow, false);
                }
            }

#endif
        }

        public override void GetDamage(int amount, float invulnerableTime)
        {
            
            if (InvulnerableTime <= 0)
            {
                IsInvulnerable = true;
                Health -= amount;
                InvulnerableTime = invulnerableTime;
                _hitSound.Play();
            }
            IsInvulnerable = false;

            if (Health <= 0 || Position.Y > 1000)
            {
                Health = 0;
                CurrentAction.Action = MoveableActionType.Dying;
                
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
    }
}