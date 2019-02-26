using System;
using System.Diagnostics;
using Doog;

namespace Breakout
{
    [DebuggerDisplay("{Transform.Position}")]
	public class Tile : RectangleComponent, ICollidable, IDrawable
	{
		public Tile(Point position, Pixel pixel, IWorldContext context)
		    : base (position, context)
        {
            Pixel = pixel;
			Transform.CentralizePivot();
			// Transform.Scale += 0.5f;
		}

		public void OnCollision(Collision collision)
		{
		}
	}
}
