using System.Linq;
using System;
using Snake.Framework;
using Snake.Framework.Diagnostics;

namespace Snake.Game.Scenes
{
	public class GameOverScene : SceneBase
	{
		private int foodEatenCount;

		public override void Initialize(IWorld world)
		{
			var snakes = world.Components.Get<Snake>();
			foodEatenCount = snakes.First().FoodsEatenCount;

			world.RemoveComponentsWithoutTag("Wall");
		}

		public override void Update(IWorldContext context)
		{
			var ts = context.TextSystem;
			var bounds = context.GraphicSystem.Bounds;

			ts.DrawCenter("Game over", bounds);
			ts.DrawCenter(0, 7, "Score: {0}".With(foodEatenCount), bounds, "Default");

			if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Enter)
			{
				context.OpenScene(new ClassicModeLevelScene());
			}
		}
	}
}