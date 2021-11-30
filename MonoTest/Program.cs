using System;

namespace MonoTest
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new GameEngine())
                game.Run();
        }
    }
}
