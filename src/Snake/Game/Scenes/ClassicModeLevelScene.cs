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

        public ClassicModeLevelScene(IWorldContext context)
            : base(context)
        {

        }

        public override void Initialize()
        {
            Context.RemoveAllComponents();
            var bounds = Context.GraphicSystem.Bounds;

            // Create the walls.
            var wallSpawner = new WallSpawner(Context);
            wallSpawner.Spawn();

            // Create the snakes.
            snakes = new Snake[MaxSnakes];

            for (int i = 0; i < MaxSnakes; i++)
            {
                var snake = new Snake(Context);
                snake.Initialize(0, 10 + i, 6);
                snakes[i] = snake;

				Context.AddComponent(snake);

                var offset = Context.Bounds.Width * 0.45f;
                var duration = Context.Bounds.Width * 0.1f;
				scoreX = Context.Bounds.Left + offset;
				scoreX.Tween(
                    Context.Bounds.Right - offset,
                    duration,
                    Easing.InBack,
                    Context,
                    (v) =>
                    {
                        scoreX = v;
                    })
				 .PingPong();
            }

			// Create the food spawner.
			Context.AddComponent(new FoodSpawner(Context));

            gameOver = false;
        }

        public override void Update()
        {
            CheckGameOver();

			if (gameOver)
			{
				Context.OpenScene(new GameOverScene(Context));
			}
			else
			{
				Context.TextSystem.DrawCenterX(1, "Doog's Snake", Context.Bounds);
				Context.TextSystem.Draw(scoreX, 7, "Score: " + snakes[0].FoodsEatenCount, "Default");

                if(Console.KeyAvailable && Console.ReadKey().Key == ConsoleKey.T)
                {
                    Context.OpenScene(new TestScene(Context));
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
