using System;
using System.IO;
using System.Linq;
using System.Threading;
using Snake.Framework.Geometry;
using Snake.Framework.Physics;
using Snake.Framework.Texts.Map;
using Snake.Game;

namespace Snake.Runners.Console
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            using (var game = new SnakeGame())
            {
                var gs = new GraphicSystem();
                var ts = new MapTextSystem(game, "Slant");

                game.Initialize(
                    gs,
                    new PhysicSystem(),
                    ts,
                    () => Environment.Exit(0));

                if (args.Contains("file-log"))
                {
                    game.LogSystem = new FileLogSystem(
                        Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log.txt"),
                        game);
                }
                else if (args.Contains("console-log"))
                {
                    game.LogSystem = new ConsoleLogSystem(
                        new Rectangle(game.Bounds.Left, game.Bounds.Bottom * 0.8f, game.Bounds.Right - 1, game.Bounds.Bottom - 1),
                        game);
                }

                // TODO: this should be moved to game loop inside the World class.
                // There are samples how to implement it on chapter GAME LOOP.
                // The game loop bellow is the "Fixed update time step, variable rendering.
                var secondsPerFrame = 1f / 30f;
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
                        game.Update(DateTime.Now);
                        lag -= secondsPerFrame;
                    }

                    game.Draw();
                }
            }
        }
    }
}