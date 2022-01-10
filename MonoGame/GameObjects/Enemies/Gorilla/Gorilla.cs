using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using MonoTest.AI;

namespace MonoTest.GameObjects.Enemies
{
    public class Gorilla : Enemy
    {
        private readonly SoundEffect _roar;
        private readonly SoundEffect _hitGorilla;
        


        public Gorilla(Texture2D texture, SoundEffect roar, SoundEffect hitSound, IBehavior behavior) : base(behavior)
        {
            Damage = 6;
            InitialHealth = 32;
            Health = InitialHealth;
            _texture = texture;
            _roar = roar;
            _hitGorilla = hitSound;
            Scale = 2;
            Speed = 200f;

            
            AddAnimation("walk", new GorillaWalkAnimation(_texture, 64));
            AddAnimation("idle", new GorillaIdleAnimation(_texture, 64));
            AddAnimation("angryWalk", new GorillaAngryWalkAnimation(_texture, 64));
            AddAnimation("chestPound", new GorillaChestPound(_texture, 64));
            AddAnimation("dying", new GorillaDeadAnimation(_texture, 64));

            MapAnimationToAction("walk", false, MoveableActionType.Running, MoveableActionDirection.Right);
            MapAnimationToAction("walk", true, MoveableActionType.Running, MoveableActionDirection.Left);
            MapAnimationToAction("idle", false, MoveableActionType.Idle, MoveableActionDirection.Right);
            MapAnimationToAction("idle", true, MoveableActionType.Idle, MoveableActionDirection.Left);
            MapAnimationToAction("idle", false, MoveableActionType.Idle, MoveableActionDirection.Static);
            MapAnimationToAction("dying", false, MoveableActionType.Dying, MoveableActionDirection.Right);
            MapAnimationToAction("dying", true, MoveableActionType.Dying, MoveableActionDirection.Left);
            MapAnimationToAction("dying", false, MoveableActionType.Dying, MoveableActionDirection.Static);
            MapAnimationToAction("angryWalk", false, MoveableActionType.AngryWalking, MoveableActionDirection.Right);
            MapAnimationToAction("angryWalk", true, MoveableActionType.AngryWalking, MoveableActionDirection.Left);
            MapAnimationToAction("chestPound", false, MoveableActionType.Taunting, MoveableActionDirection.Right);
            MapAnimationToAction("chestPound", true, MoveableActionType.Taunting, MoveableActionDirection.Left);
            MapAnimationToAction("chestPound", true, MoveableActionType.Taunting, MoveableActionDirection.Static);

            BoundingBox = new RectangleF(11, 27, 36, 36);
            CurrentAction = new MoveableAction(MoveableActionType.Idle, MoveableActionDirection.Static);
            SetCurrentAnimation("idle");
        }

        public override void Update(GameTime gameTime)
        {
            CurrentAnimation.Update(gameTime);
            _behavior.Brains(gameTime, this);
            if (InvulnerableTime <= 0)
            {
                Color = Color.White;
                IsAngry = false;
            }
            else InvulnerableTime -= (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (CurrentAction.Action == MoveableActionType.Dying && CurrentAnimation.AnimationDoneFlag)
            {
                RemoveFlag = true;
            }
        }

        public override void Draw(SpriteBatch spriteBatch, GraphicsDevice graphics)
        {
            base.Draw(spriteBatch, graphics);
#if DEBUG
            var sourceRectangle = CurrentAnimation.CurrentFrame.SourceRectangle;
            var rectangle = new RectangleF(Position.X, Position.Y, sourceRectangle.Width * Scale,
                sourceRectangle.Height * Scale);
            DebugService.DrawRectangle(spriteBatch, rectangle, 1, Color.Cyan, false);
            
            if (CurrentAnimation.CurrentFrame.HitBoxes != null)
            {
                for (var i = 0; i < CurrentAnimation.CurrentFrame.HitBoxes.Count; i++)
                {
                    var attackBoxX = CurrentAnimation.CurrentFrame.HitBoxes[i].X * Scale + Position.X;
                    var attackBoxY = CurrentAnimation.CurrentFrame.HitBoxes[i].Y * Scale + Position.Y;
                    var debugR2 = new RectangleF(attackBoxX, attackBoxY, CurrentAnimation.CurrentFrame.HitBoxes[i].Width * Scale, CurrentAnimation.CurrentFrame.HitBoxes[i].Height * Scale);
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
                IsAngry = true;
                IsInvulnerable = true;
                Health -= amount;
                InvulnerableTime = invulnerableTime;
                _hitGorilla.Play();
            }
            IsInvulnerable = false;

            if (Health <= 0 || Position.Y > 1000)
            {
                Health = 0;
                CurrentAction.Action = MoveableActionType.Dying;
            }

            Color = new Color(255, 120, 120);
        }

        public override void PlayScream()
        {
            _roar.Play();
        }
    }
}