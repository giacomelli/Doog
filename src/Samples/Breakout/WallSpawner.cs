using System.Collections.Generic;
using Doog;

namespace Breakout
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
            walls.Add(Wall.Create(left, top - 1, width + 1, 1, Context, "TopWall"));
			walls.Add(Wall.Create(right - 0.5f, top, 1, height, Context, "RightWall"));
			walls.Add(Wall.Create(left, bottom , width, 1, Context, "BottomWall"));
			walls.Add(Wall.Create(left, top, 1, height, Context, "LeftWall"));

            return walls;
		}
	}
}
