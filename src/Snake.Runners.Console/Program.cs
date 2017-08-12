using System;
using System.Threading;
using Snake.Framework.Texts.Map;
using Snake.Game;

namespace Snake.Runners.Console
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			var fps = 10.0;
			var sleepTime = (int)Math.Round(1000.0 / fps);
			var gfx = new GraphicSystem();
			var fs = new MapTextSystem(gfx, "Slant");

			using (var game = new SnakeGame(gfx, fs))
			{
				game.Initialize();

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