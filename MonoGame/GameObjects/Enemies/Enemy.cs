using MonoTest.AI;

namespace MonoTest.GameObjects.Enemies
{
    public abstract class Enemy: Moveable
    {
        protected AIBehavior _behavior;
        public bool IsAngry { get; set; }
        public bool IsTaunting { get; set; }
        public virtual void PlayHitSound()
        {
            
        }

        public virtual void PlayScream()
        {
            
        }

        public Enemy(AIBehavior behavior)
        {
            _behavior = behavior;
        }
    }
}