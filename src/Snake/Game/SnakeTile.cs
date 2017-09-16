using System;
using System.Diagnostics;
using Doog.Framework;

namespace Snake.Game
{
    [DebuggerDisplay("{Transform.Position}")]
	public class SnakeTile : RectangleComponent, ICollidable, IDrawable
	{
        public const char HeadSprite = '@';
		public const char BodySprite = 'o';
   		private Action onCollisionFood;
		private Action onCollisionTile;
		private Action onCollisionWall;

		public SnakeTile(float x, float y, IWorldContext context, Action onCollisionFood, Action onCollisionTile, Action onCollisionWall)
		    : base (x, y, context)
        {
			this.onCollisionFood = onCollisionFood;
			this.onCollisionTile = onCollisionTile;
            this.onCollisionWall = onCollisionWall;

            Sprite = BodySprite;
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
