using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace MonoTest.Map.Plants
{
    public class PlantConfig
    {
        public Vector2 Position { get; }
        public float AttackSpeed { get; }
        public int PlantType { get; }

        public PlantConfig(Vector2 position, float attackSpeed, int plantType)
        {
            Position = position;
            AttackSpeed = attackSpeed;
            PlantType = plantType;
        }
    }
}