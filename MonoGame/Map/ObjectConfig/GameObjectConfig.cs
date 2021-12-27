using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace MonoTest.Map.ObjectConfig
{
    public class GameObjectConfig
    {
        public Vector2 Position { get; }
        public float AttackSpeed { get; }

        public GameObjectConfig(Vector2 position, float attackSpeed)
        {
            Position = position;
            AttackSpeed = attackSpeed;
        }
    }
}