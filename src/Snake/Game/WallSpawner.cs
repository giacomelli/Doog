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
            var left = bounds.Left;
            var top = bounds.Top;
            var right = bounds.Right;
            var bottom = bounds.Bottom - 1;
            var width = bounds.Width;
            var height = bounds.Height;

            // Borders
            walls.Add(Wall.Create(left, top, width, 1, Context));
			walls.Add(Wall.Create(right, top, 1, height, Context));
			walls.Add(Wall.Create(left, bottom , width, 1, Context));
			walls.Add(Wall.Create(left, top, 1, height, Context));

			// Center
            var center = bounds.GetCenter();
			walls.Add(Wall.Create(center.X, top, 1, height, Context));
            walls.Add(Wall.Create(left, center.Y, width, 1, Context));

            return walls;
		}
	}
}
