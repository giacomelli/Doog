using Snake.Framework;
using Snake.Framework.Graphics;
using Snake.Game.Scenes.Samples;
using Snake.Framework.Animations;
using Snake.Framework.Geometry;
using Snake.Framework.Input;

namespace Snake.Game.Scenes
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
            if (Context.InputSystem.IsKeyDown(Keys.Q))
            {
                Context.Exit();
            }

            Context
                .OpenScene<ClassicModeLevelScene>(Keys.Enter)
                .OpenScene<Sample1Scene>(Keys.D1)
                .OpenScene<Sample2Scene>(Keys.D2)
                .OpenScene<Sample3Scene>(Keys.D3)
                .OpenScene<Sample4Scene>(Keys.D4)
                .OpenScene<Sample5Scene>(Keys.D5)
                .OpenScene<Sample6Scene>(Keys.D6)
                .OpenScene<Sample7Scene>(Keys.D7)
                .OpenScene<Sample8Scene>(Keys.D8);
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
