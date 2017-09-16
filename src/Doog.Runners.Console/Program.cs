using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Doog.Framework;

namespace Doog.Runners.Console
{
    internal class Program
    {
        private static void Main(string[] args)
        { 
            using (var game = GameActivator.CreateInstance(args))
            {
                var gs = new GraphicSystem();
                var ts = new MapTextSystem(game, "Slant");
                var inputSystem = new InputSystem();
                game.Initialize(
                    gs,
                    new PhysicSystem(),
                    ts,
		            inputSystem,
                    () => Environment.Exit(0));

                if (args.Contains("file-log"))
                {
                    game.LogSystem = new FileLogSystem(
                        Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log.txt"),
                        game);
                }
                else if (args.Contains("console-log"))
                {
                    var b = game.Bounds;
                    game.LogSystem = new ConsoleLogSystem(
                        new Rectangle(b.Left + 1, b.Bottom * 0.8f, b.Width - 2, (b.Height * 0.2f) -1),
                        game);
                }

                var secondsPerFrame = 1f / 120;
                var previous = DateTime.Now;
                var lag = 0.0;

                game.Update(previous);

                for (;;)
                {
                    var current = DateTime.Now;
                    var elapsed = current - previous;
                    previous = current;
                    lag += elapsed.TotalSeconds;

                    // game.ProcessInput();

                    while(lag >= secondsPerFrame)
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
