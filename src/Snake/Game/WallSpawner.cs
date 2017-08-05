using Snake.Framework;

namespace Snake.Game
{
	public class WallSpawner : ComponentBase
	{
		public void Spawn(IWorldContext context)
		{
			var bounds = context.Bounds;

			for (int x = bounds.Left; x < bounds.Right; x++)
			{
				for (int y = bounds.Top; y < bounds.Bottom; y++)
				{
					if (x == bounds.Left||
					   x == bounds.Right -1 ||
					   y == bounds.Top ||
					   y == bounds.Bottom -1)
					{
						context.AddComponent(new Wall(x, y));
					}
				}
			}
		}
	}
}