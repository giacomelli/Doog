using System.Collections.Generic;
using Snake.Framework;
using Snake.Framework.Geometry;

namespace Snake.Game
{
	public class WallSpawner : ComponentBase
	{
        public WallSpawner(IWorldContext context)
            : base(context)
        {
            
        }

		public IEnumerable<Wall> Spawn()
		{
            var walls = new List<Wall>();
            var bounds = Context.Bounds;

            bounds.Iterate((x, y) =>
            {
				if (bounds.IsBorder(x, y))
				{
                    walls.Add(Wall.Create(x, y, Context));
				}
            });

            var center = bounds.GetCenter();
            var x2 = center.X;
            float y2;

            for (y2 = bounds.Top + 1; y2 < bounds.Bottom; y2++)
            {
                walls.Add(Wall.Create(x2, y2, Context));
            }

            y2 = center.Y;

			for (x2 = bounds.Left + 1; x2 < bounds.Right; x2++)
			{
				walls.Add(Wall.Create(x2, y2, Context));
			}

            return walls;
		}
	}
}
