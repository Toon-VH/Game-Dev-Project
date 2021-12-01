using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MonoTest.Input
{
    class MouseReader : IInputReader
    {
        public bool IsDestinationInput => true;

        public Input ReadInput()
        {
            var mouseState = Mouse.GetState();
            var postionMouse = new Vector2(mouseState.X, mouseState.Y);
            
            return new Input
            {
                Movement = postionMouse,
                Attack = false
            };

        }
    }
}
