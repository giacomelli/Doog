﻿using Doog;
namespace Snake.Scenes
{
    public class GameOverScene : SceneBase
    {
        private bool showPressStart;

        public GameOverScene(IWorldContext context)
            : base(context)
        {
        }

        public override void Initialize()
        {
            Context.RemoveComponentsWithoutTag("Score", "Wall");
            var toPoint = Context.Bounds.GetCenter();

            var hilightWall = new RectangleComponent(Point.Zero, Context)
            {
                Sprite = ' '
            };

            this.Iterate(Context.Bounds, false, 15, Easing.Linear, (x, y) =>
             {
                 hilightWall.Transform.Position = new Point(x, y);
             }).Loop();

            this.Toogle(false, 1f, Easing.Linear, v => showPressStart = v)
                .Loop();
        }

        public override void Update()
        {
            var input = Context.InputSystem;

            if (input.IsKeyDown(Keys.Enter))
            {
                Context.OpenScene<ClassicModeLevelScene>();
            }
            else if (input.IsKeyDown(Keys.Q))
            {
                Context.Exit();
            }
        }

        public override void Draw(IDrawContext drawContext)
        {
            drawContext.TextSystem
                   .Draw(Context.Bounds.Left, 3, "Doog's Snake")
                   .DrawCenter("Game over");

            if (showPressStart)
            {
                drawContext.TextSystem.DrawCenter(0, 5, "Press ENTER to try again or Q to quit", "Default");
            }
        }
    }
}
