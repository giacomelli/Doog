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

            return walls;
		}
	}
}
