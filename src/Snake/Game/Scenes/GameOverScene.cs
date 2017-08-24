using System.Linq;
using System;
using Snake.Framework;
using Snake.Framework.Graphics;
using Snake.Game.Scenes.Samples;

namespace Snake.Game.Scenes
{
    public class GameOverScene : SceneBase
    {
        private int foodEatenCount;

        public GameOverScene(IWorldContext context)
            : base(context)
        {

        }

        public override void Initialize()
        {
            var snakes = Context.Components.Get<Snake>();
            foodEatenCount = snakes.First().FoodsEatenCount;

            Context.RemoveComponentsWithoutTag("Wall");
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
                }
            }
        }

        public override void Draw(IDrawContext context)
        {
            Context.TextSystem
                   .DrawCenter("Game over")
			       .DrawCenter(0, 7, "Score: {0}".With(foodEatenCount), "Default");

		}
    }
}