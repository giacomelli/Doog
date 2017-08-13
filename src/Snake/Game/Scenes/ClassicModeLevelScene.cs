using System;
using Snake.Framework;
using Snake.Framework.Animations;

namespace Snake.Game.Scenes
{
	public class ClassicModeLevelScene : SceneBase
	{
		private const int MaxSnakes = 1;
		private Snake[] snakes;
		private bool gameOver;
        private float scoreX;

		public override void Initialize(IWorldContext worldContext)
		{
			worldContext.RemoveAllComponents();
			var bounds = worldContext.GraphicSystem.Bounds;

			// Create the walls.
			var wallSpawner = new WallSpawner();
			wallSpawner.Spawn(worldContext);

			// Create the snakes.
			snakes = new Snake[MaxSnakes];

			for (int i = 0; i < MaxSnakes; i++)
			{
				var snake = new Snake();
				snake.Initialize(0, 10 + i, 6, bounds, worldContext);
				snakes[i] = snake;

				worldContext.AddComponent(snake);

                var offset = worldContext.Bounds.Width * 0.45f;
                var duration = worldContext.Bounds.Width * 0.1f;
				scoreX = worldContext.Bounds.Left + offset;
				scoreX.Tween(
                    worldContext.Bounds.Right - offset,
                    duration,
                    Easing.InBack,
                    worldContext,
                    (v) =>
                    {
                        scoreX = v;
                    })
				 .PingPong();
            }

			// Create the food spawner.
			worldContext.AddComponent(new FoodSpawner(worldContext));

			gameOver = false;
		}

		public override void Update(IWorldContext context)
		{
			CheckGameOver();

			if (gameOver)
			{
				context.OpenScene(new GameOverScene());
			}
			else
			{
				context.TextSystem.DrawCenterX(1, "Doog's Snake", context.Bounds);
				context.TextSystem.Draw(scoreX, 7, "Score: " + snakes[0].FoodsEatenCount, "Default");

                if(Console.KeyAvailable && Console.ReadKey().Key == ConsoleKey.T)
                {
                    context.OpenScene(new TestScene());
                }
			}
		}

		private void CheckGameOver()
		{
			if (!gameOver)
			{
				for (int i = 0; i < MaxSnakes; i++)
				{
					var snake = snakes[i];

					if (snake.Dead)
					{
						gameOver = true;
						break;
					}
				}
			}
		}
	}
}
