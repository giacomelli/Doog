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
			}

      		// Create the food spawner.
			FoodSpawner.Create(Context);

            gameOver = false;
        }

        public override void Update()
        {
            CheckGameOver();

			if (gameOver)
			{
                Context.Components.DisableAll();
				Context.OpenScene<GameOverScene>();
			}
			else
			{
				Context.TextSystem.DrawCenterX(1, "Doog's Snake");
				Context.TextSystem.DrawCenterX(7, "Score: " + snakes[0].FoodsEatenCount, "Default");
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
