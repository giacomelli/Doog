using Snake.Framework;

namespace Snake.Game
{
	public class WallSpawner : ComponentBase
	{
        public WallSpawner(IWorldContext context)
            : base(context)
        {
            
        }

		public void Spawn()
		{
			var bounds = Context.Bounds;

			for (var x = bounds.Left; x < bounds.Right; x++)
			{
				for (var y = bounds.Top; y < bounds.Bottom; y++)
				{
					if (x == bounds.Left||
					   x == bounds.Right -1 ||
					   y == bounds.Top ||
					   y == bounds.Bottom -1)
					{
						Wall.Create(x, y, Context);
					}
				}
			}
		}
	}
}
