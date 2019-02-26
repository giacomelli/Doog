using System;
using System.Collections.Generic;
using System.Diagnostics;
using Doog;

namespace Breakout
{
    [DebuggerDisplay("{Transform.Position}")]
	public class TileSpawner : ComponentBase
	{
		public TileSpawner(IWorldContext context)
		    : base (context)
        {
		}

		public IEnumerable<Tile> SpawnLevel1()
		{
			var tiles = new List<Tile>();
			var margin = 2.0f;

			for (float y = Context.Bounds.Top + 1; y < 16; y += 4.0f)
			{
				for (float x = Context.Bounds.Left + margin; x < Context.Bounds.Right - margin; x += 1.0f)
				{
					tiles.Add(new Tile(new Point(x, y), 'X'.Blue(), Context));
				}

				margin += 1.0f;
			}

			return tiles;
		}
	}
}
