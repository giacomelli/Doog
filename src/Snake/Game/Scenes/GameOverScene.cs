using System.Linq;
using System;
using Snake.Framework;
using Snake.Framework.Graphics;
using Snake.Game.Scenes.Samples;
using Snake.Framework.Animations;

namespace Snake.Game.Scenes
{
    public class GameOverScene : SceneBase
    {
        public GameOverScene(IWorldContext context)
            : base(context)
        {
        }

        public override void Initialize()
        {
            Context.RemoveComponentsWithoutTag("Wall", "Score");
            var toPoint = Context.Bounds.GetCenter();
            var walls = Context.Components.Get<Wall>().ToList();

            foreach(var wall in walls)
            {
                wall.Transform
                    .MoveTo(toPoint, 10f, Easing.InOutElastic)
                    .PingPong();

				wall.Transform
				   .ScaleTo(10, 1f, Easing.InOutElastic)
				   .PingPong();
            }
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
                }
            }
        }

        public override void Draw(IDrawContext context)
        {
            Context.TextSystem
                   .Draw(Context.Bounds.Left, 3, "Doog's Snake")
                   .DrawCenter("Game over");

		}
    }
}