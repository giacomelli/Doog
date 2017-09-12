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
            wallSpawner.Spawn();

            // Create the snakes.
            snakes = new Snake[MaxSnakes];

            for (int i = 0; i < MaxSnakes; i++)
            {
                var snake = new Snake(Context);
                snake.Initialize(center.X, center.Y + i, 5);
                snake.Died += delegate
                {
                    ChangeToGameOver();
                };
                snakes[i] = snake;
            }

            // Create the food spawner.
            FoodSpawner.Create(Context);

            bounds = Context.Bounds;

            // Score.
            // TODO: now it is prepared to only one snake.
            // We must decide if only one Score will show all snakes scores (as list)
            // or each Snake will have its own score instance.
            Score.Create(new Point(bounds.Right, bounds.Top), snakes[0], Context);

            // Portals.
            var offsetFromLeftX = 2;
            var offsetFromRightX = -4;
            var offsetY = 2;

            PortalBridge.Create(
                bounds.TopCenterPoint() + new Point(offsetFromRightX, offsetY),
                bounds.LeftBottomPoint() + new Point(offsetFromLeftX, -offsetY),
                '1',
                Context);

            PortalBridge.Create(
				bounds.TopCenterPoint() + new Point(offsetFromLeftX, offsetY),
				bounds.RightBottomPoint() + new Point(offsetFromRightX, -offsetY),
                '2',
				Context);

            PortalBridge.Create(
                bounds.LeftCenterPoint() + new Point(offsetFromLeftX, offsetY),
                bounds.RightCenterPoint() + new Point(offsetFromRightX, -offsetY),
                '3',
                Context);

            PortalBridge.Create(
                bounds.LeftCenterPoint() + new Point(offsetFromLeftX, -offsetY),
                bounds.RightCenterPoint() + new Point(offsetFromRightX, offsetY),
                '4',
                Context);
        }

        public void ChangeToGameOver()
        {
            Context.OpenScene<GameOverScene>();
        }

        public override void Draw(IDrawContext drawContext)
        {
            drawContext.TextSystem
                       .Draw(Context.Bounds.Left, 3, "Doog's Snake");
        }
    }
}
