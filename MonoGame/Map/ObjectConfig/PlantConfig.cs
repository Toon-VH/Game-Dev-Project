using Microsoft.Xna.Framework;

namespace MonoTest.Map.ObjectConfig
{
    public class PlantConfig: ObjectConfig.GameObjectConfig
    {
        public int PlantType { get; }

        public PlantConfig(Vector2 position, float attackSpeed, int plantType) : base(position, attackSpeed)
        {
            PlantType = plantType;
        }
    }
}