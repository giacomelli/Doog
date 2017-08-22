using System.Linq;
using System;
using Snake.Framework;
using Snake.Framework.Diagnostics;

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
            var ts = Context.TextSystem;
         
            ts.DrawCenter("Game over")
              .DrawCenter(0, 7, "Score: {0}".With(foodEatenCount), "Default");

            if (Console.KeyAvailable)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.Enter:
                        Context.OpenScene<ClassicModeLevelScene>();
                        break;

                    case ConsoleKey.D1:
                        Context.OpenScene<Test1Scene>();
                        break;

					case ConsoleKey.D2:
						Context.OpenScene<Test2Scene>();
						break;
                }
            }
        }
    }
}