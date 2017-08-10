using Snake.Framework;

namespace Snake.Game.Scenes
{
	public class ClassicModeLevelScene : SceneBase
	{
		private const int MaxSnakes = 1;
		private Snake[] snakes;
		private bool gameOver;

		public override void Initialize(IWorld world)
		{
			world.RemoveAllComponents();
			var bounds = world.GraphicSystem.Bounds;

			// Create the walls.
			var wallSpawner = new WallSpawner();
			wallSpawner.Spawn(world);

			// Create the snakes.
			snakes = new Snake[MaxSnakes];

			for (int i = 0; i < MaxSnakes; i++)
			{
				var snake = new Snake();
				snake.Initialize(0, 10 + i, 6, bounds, world);
				snakes[i] = snake;

				world.AddComponent(snake);
			}

			// Create the food spawner.
			world.AddComponent(new FoodSpawner(bounds, world));

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
				context.TextSystem.DrawCenterX(7, "Score: " + snakes[0].FoodsEatenCount, context.Bounds, "Default");
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
