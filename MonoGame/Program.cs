using System;

namespace MonoTest
{
    public static class Program
    {
        [STAThread]
        private static void Main()
        {
            using var game = new GameEngine();
            game.Run();
        }
    }
}