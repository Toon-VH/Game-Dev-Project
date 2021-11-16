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
                    case Keys.Left:
                        direction.X--;
                        break;

                    case Keys.Right:
                        direction.X++;
                        break;

                    case Keys.Down:
                        direction.Y++;
                        break;

                    case Keys.Up:
                        direction.Y--;
                        break;

                    default:
                        break;
                }
            }

        
            return direction;
        }
    }
}
