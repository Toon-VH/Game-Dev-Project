using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MonoTest.Input
{
    class KeyboardReader : IInputReader
    {
        public bool IsDestinationInput => false;

        public Input ReadInput()
        {
            var keyboardState = Keyboard.GetState();
            var direction = Vector2.Zero;

            var keys = keyboardState.GetPressedKeys();

            var jump = false;
            
            foreach (var key in keys)
            {
                switch (key)
                {
                    case Keys.W:
                        direction.Y--;
                        break;

                    case Keys.D:
                        direction.X++;
                        break;

                    case Keys.S:
                        direction.Y++;
                        break;

                    case Keys.A:
                        direction.X--;
                        break;
                    
                    case Keys.Space:
                        jump = true;
                        break;

                    default:
                        break;
                }
            }

            return new Input
            {
                Movement = direction,
                Attack = false,
                Jump = jump
            };
        }
    }
}
