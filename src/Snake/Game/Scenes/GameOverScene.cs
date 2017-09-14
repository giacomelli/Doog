using System.Linq;
using System;
using Snake.Framework;
using Snake.Framework.Graphics;
using Snake.Game.Scenes.Samples;
using Snake.Framework.Animations;
using Snake.Framework.Geometry;

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

            this.Iterate(Context.Bounds,false, 15, Easing.Linear, (x, y) => 
            {
                hilightWall.Transform.Position = new Point(x, y);        
            }).Loop();

			this.Toogle(false, 1f, Easing.Linear, v => showPressStart = v)
                .Loop();
        }

        public override void Update()
        {
            if (Console.KeyAvailable)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.Enter:
                        Context.OpenScene<ClassicModeLevelScene>();
                        break;

					case ConsoleKey.Q:
                        Context.Exit();
						break;

                    case ConsoleKey.D1:
                        Context.OpenScene<Sample1Scene>();
                        break;

					case ConsoleKey.D2:
						Context.OpenScene<Sample2Scene>();
						break;

					case ConsoleKey.D3:
						Context.OpenScene<Sample3Scene>();
						break;

					case ConsoleKey.D4:
						Context.OpenScene<Sample4Scene>();
						break;

					case ConsoleKey.D5:
						Context.OpenScene<Sample5Scene>();
						break;

					case ConsoleKey.D6:
						Context.OpenScene<Sample6Scene>();
						break;

					case ConsoleKey.D7:
						Context.OpenScene<Sample7Scene>();
						break;

					case ConsoleKey.D8:
						Context.OpenScene<Sample8Scene>();
						break;
                }
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