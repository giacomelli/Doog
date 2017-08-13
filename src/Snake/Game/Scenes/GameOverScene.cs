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
			var bounds = Context.GraphicSystem.Bounds;

			ts.DrawCenter("Game over", bounds);
			ts.DrawCenter(0, 7, "Score: {0}".With(foodEatenCount), bounds, "Default");

			if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Enter)
			{
				Context.OpenScene(new ClassicModeLevelScene(Context));
			}
		}
	}
}