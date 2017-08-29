using System;
using System.Diagnostics;
using Snake.Framework;
using Snake.Framework.Geometry;
using Snake.Framework.Graphics;
using Snake.Framework.Physics;

namespace Snake.Game
{
    [DebuggerDisplay("{Transform.Position}")]
	public class SnakeTile : RectangleComponent, ICollidable, IDrawable
	{
   		private Action onCollisionFood;
		private Action onCollisionTile;
		private Action onCollisionWall;

		public SnakeTile(float x, float y, IWorldContext context, Action onCollisionFood, Action onCollisionTile, Action onCollisionWall)
		    : base (x, y, context)
        {
			this.onCollisionFood = onCollisionFood;
			this.onCollisionTile = onCollisionTile;
            this.onCollisionWall = onCollisionWall;

            Sprite = '@';
		}

		public SnakeTile Next { get; set; }

		public void OnCollision(Collision collision)
		{
			switch (collision.Other.Tag)
			{
				case "SnakeTile":
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
