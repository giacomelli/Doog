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
                    ts);

                if (args.Contains("file-log"))
                {
                    game.LogSystem = new FileLogSystem(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log.txt"));
                }
                else if (args.Contains("console-log"))
                {
                    game.LogSystem = new ConsoleLogSystem(
                        new Rectangle(1, gs.Bounds.Bottom * 0.8f, gs.Bounds.Right - 1, gs.Bounds.Bottom - 1),
                        game);
                }

                var fpsPosition = game.Bounds.RightTopPoint() + new Point(-15, 1);
                var secondsPerFrame = 1f / 30f;
             
                for (;;)
                {
                    var startTime = DateTime.Now;
                    game.Update(startTime);
                    game.Draw();

                    // TODO: this should be moved to game loop inside the World class.
                    // There are samples how to implement it on chapter GAME LOOP.
                    // Thread.Sleep(sleepTime);
                    var wait = startTime.AddSeconds(secondsPerFrame) - DateTime.Now;

                    if (wait.TotalMilliseconds > 0)
                        Thread.Sleep(wait);
                }
            }
        }
    }
}