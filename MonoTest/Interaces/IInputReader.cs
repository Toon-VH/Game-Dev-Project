using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonoTest.Interaces
{
   internal interface IInputReader
    {
        public Vector2 ReadInput();
        public bool IsDestinationInput { get; }
    }
}
