using System;

namespace Doog.Runners.MonoGameDesktop
{
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            using (var game = new Runner(args))
                game.Run();
        }
    }
}
