using System;
using Snake.Framework;
using Snake.Framework.Animations;
using Snake.Framework.Geometry;
using Snake.Framework.Graphics;

namespace Snake.Game.Scenes
{
    public class ClassicModeLevelScene : SceneBase
    {
        private const int MaxSnakes = 1;
        private Snake[] snakes;

        public ClassicModeLevelScene(IWorldContext context)
            : base(context)
        {

        }

        public override void Initialize()
        {
            Context.RemoveAllComponents();
            var bounds = Context.GraphicSystem.Bounds;
            var center = bounds.GetCenter();

            // Create the walls.
            var wallSpawner = new WallSpawner(Context);
            var walls = wallSpawner.Spawn();

            // Create the snakes.
            snakes = new Snake[MaxSnakes];

            for (int i = 0; i < MaxSnakes; i++)
            {
                var snake = new Snake(Context);
                snake.Initialize(center.X, center.Y + i, 6);
                snake.Died += delegate
                {
                    ChangeToGameOver();
                };
                snakes[i] = snake;
            }

            // Create the food spawner.
            FoodSpawner.Create(Context);

            // Score.
            // TODO: now it is prepared to only one snake.
            // We must decide if only one Score will show all snakes scores (as list)
            // or each Snake will have its own score instance.
            Score.Create(new Point(Context.Bounds.Right, Context.Bounds.Top), snakes[0], Context);
        }

        public void ChangeToGameOver()
        {
            Context.OpenScene<GameOverScene>();
        }

        public override void Draw(IDrawContext context)
        {
            Context.TextSystem.Draw(Context.Bounds.Left, 3, "Doog's Snake");
        }
    }
}
