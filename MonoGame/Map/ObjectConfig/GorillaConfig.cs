using Microsoft.Xna.Framework;
using MonoTest.AI;

namespace MonoTest.Map.ObjectConfig
{
    public class GorillaConfig: GameObjectConfig
    {
        public IBehavior Behavior { get; set; }
        public GorillaConfig(Vector2 position, int attackSpeed, IBehavior behavior) : base(position, attackSpeed)
        {
            Behavior = behavior;
        }
    }
}