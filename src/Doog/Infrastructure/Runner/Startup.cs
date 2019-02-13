using System;
using System.Reflection;

namespace Doog
{
    /// <summary>
    /// Game startup class.
    /// </summary>
    public static class Startup
    {
        /// <summary>
        /// Runs the specified game assembly using the args passed.
        /// </summary>
        /// <remarks>
        /// This method should be called inside in your Program.cs Main method.
        /// </remarks>
        /// <param name="gameAssembly">The game assembly.</param>
        /// <param name="args">The arguments.</param>
        public static void Run(Assembly gameAssembly, string[] args)
        {
            using (var game = GameActivator.CreateInstance(gameAssembly))
            {
                var gs = new GraphicSystem();

                // TODO: create a StartupConfig to pass arguments as defaultFontName.
                var ts = new MapTextSystem(game, "Slant");
                var inputSystem = new InputSystem();
                game.Initialize(
                    gs,
                    new PhysicSystem(),
                    ts,
                    inputSystem,
                    () => Environment.Exit(0));

                GameActivator.Config(game, args);

                var secondsPerFrame = 1f / 120;
                var previous = DateTime.Now;
                var lag = 0.0;

                game.Update(previous);

                while(true)
                {
                    var current = DateTime.Now;
                    var elapsed = current - previous;
                    previous = current;
                    lag += elapsed.TotalSeconds;

                    while (lag >= secondsPerFrame)
                    {
                        game.Update(current);
                        lag -= secondsPerFrame;
                    }

                    game.Draw();
                }
            }
        }
    }
}
