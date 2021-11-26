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
            KeyboardState keyboardState = Keyboard.GetState();
            Vector2 direction = Vector2.Zero;

            Keys[] keys = keyboardState.GetPressedKeys();

            foreach (Keys key in keys)
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
