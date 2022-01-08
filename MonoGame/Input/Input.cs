using Microsoft.Xna.Framework;

namespace MonoTest.Input
{
    public class Input
    {
        public Vector2 MovementDirection { get; set; }
        public bool Attack { get; set; }
        public bool AttackLow { get; set; }
        public bool Jump { get; set; }
        public bool Rol { get; set; }
        public bool Walking { get; set; }
    }
}