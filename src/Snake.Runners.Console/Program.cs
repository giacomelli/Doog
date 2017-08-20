using System;
using System.IO;
using System.Linq;
using System.Threading;
using Snake.Framework.Geometry;
using Snake.Framework.Logging;
using Snake.Framework.Physics;
using Snake.Framework.Texts.Map;
using Snake.Game;
using Snake.Runners.Console.Input;

namespace Snake.Runners.Console
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var fps = 60f;
            var sleepTime = (int)Math.Round(1000f / fps);

            using (var game = new SnakeGame())
            {
                var gs = new GraphicSystem();
                var ts = new MapTextSystem(game, "Slant");
                var inputSystem = new InputSystem();
                game.Initialize(
                    gs,
                    new PhysicSystem(),
                    ts,
                    inputSystem);

                if (args.Contains("file-log"))
                {
                    game.LogSystem = new FileLogSystem(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log.txt"));
                }
				else if (args.Contains("console-log"))
				{
					game.LogSystem = new ConsoleLogSystem(
					    new Rectangle(1, gs.Bounds.Bottom * 0.8f, gs.Bounds.Right -1, gs.Bounds.Bottom -1), 
				    	game);
				}

                for (;;)
                {
                    game.Update(DateTime.Now);
                    game.Draw();

                    // TODO: this should be moved to game loop inside the World class.
                    // There are samples how to implement it on chapter GAME LOOP.
                    Thread.Sleep(sleepTime);
                }
            }
        }
    }
}