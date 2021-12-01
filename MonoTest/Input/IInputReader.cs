using Microsoft.Xna.Framework;

namespace MonoTest.Input
{
   public interface IInputReader
    {
        public Input ReadInput();
        public bool IsDestinationInput { get; }
    }
}
