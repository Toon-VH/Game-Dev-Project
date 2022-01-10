using Microsoft.Xna.Framework;
using MonoTest.AI;

namespace MonoTest.Map.ObjectConfig
{
    public class SpiderConfig : GameObjectConfig
    {
        public AIBehavior Behavior { get; set; }
        public SpiderConfig(Vector2 position, int attackSpeed, AIBehavior behavior) : base(position, attackSpeed)
        {
            Behavior = behavior;
        }
    }
}