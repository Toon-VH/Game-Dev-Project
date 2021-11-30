using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonoTest.Interaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace MonoTest.Input
{
    class MouseReader : IInputReader
    {
        public bool IsDestinationInput => true;

        public Vector2 ReadInput()
        {
            var mouseState = Mouse.GetState();
            var postionMouse = new Vector2(mouseState.X, mouseState.Y);
            
            return postionMouse;

        }
    }
}
