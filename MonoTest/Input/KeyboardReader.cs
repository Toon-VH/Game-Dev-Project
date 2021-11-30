using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonoTest.Interaces;
using System;
using System.Collections.Generic;
using System.Text;


namespace MonoTest.Input
{
    class KeyboardReader : IInputReader
    {
        public bool IsDestinationInput => false;

        public Vector2 ReadInput()
        {
            var keyboardState = Keyboard.GetState();
            var direction = Vector2.Zero;

            var keys = keyboardState.GetPressedKeys();

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

                    default:
                        break;
                }
            }

        
            return direction;
        }
    }
}
