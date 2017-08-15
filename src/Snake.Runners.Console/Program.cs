using System;
using System.Threading;
using Snake.Framework.Physics;
using Snake.Framework.Texts.Map;
using Snake.Game;

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
				game.Initialize(
                    new GraphicSystem(), 
                    new PhysicSystem(), 
                    new MapTextSystem(game, "Slant"));

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