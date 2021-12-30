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
            var rol = false;
            var attack = false;
            var walking = false;
            
            foreach (var key in keys)
            {
                switch (key)
                {
                    case Keys.W:
                        direction.Y--;
                        break;

                    case Keys.D:
                        direction.X++;
                        walking = true;
                        break;

                    case Keys.S:
                        direction.Y++;
                        break;

                    case Keys.A:
                        direction.X--;
                        walking = true;
                        break;
                    
                    case Keys.Space:
                        jump = true;
                        break;
                    case Keys.LeftControl:
                        rol = true;
                        break;
                    case Keys.K:
                        attack = true;
                        break;
                    default:
                        break;
                }
            }

            
            return new Input
            {
                MovementDirection = direction,
                Attack = attack,
                Jump = jump,
                Rol = rol,
                Walking = walking,
            };
        }
    }
}
