using System;
using System.Diagnostics;
using Doog;

namespace Breakout
{
    [DebuggerDisplay("{Transform.Position}")]
	public class Tile : RectangleComponent, ICollidable, IDrawable
	{
        public static readonly Pixel HeadPixel = '@'.Red();
        public static readonly Pixel BodyPixel = 'o'.Green();
   		private Action onCollisionFood;
		private Action onCollisionTile;
		private Action onCollisionWall;

		public Tile(float x, float y, IWorldContext context, Action onCollisionFood, Action onCollisionTile, Action onCollisionWall)
		    : base (x, y, context)
        {
			this.onCollisionFood = onCollisionFood;
			this.onCollisionTile = onCollisionTile;
            this.onCollisionWall = onCollisionWall;

            Pixel = BodyPixel;
		}

		public Tile Next { get; set; }

		public void OnCollision(Collision collision)
		{
			switch (collision.Other.Tag)
			{
				case "BreakoutTile":
					onCollisionTile();
					break;

				case "Wall":
					onCollisionWall();
					break;

				case "Food":
					onCollisionFood();
					break;
			}
		}
	}
}
