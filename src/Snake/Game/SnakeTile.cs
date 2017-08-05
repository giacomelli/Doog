using System;
using Snake.Framework;
using Snake.Framework.Geometry;
using Snake.Framework.Graphics;
using Snake.Framework.Physics;

namespace Snake.Game
{
	public class SnakeTile : ComponentBase, ICollidable, IDrawable
	{
		private Action onCollisionFood;
		private Action onCollisionTile;

		public SnakeTile(int x, int y, Action onCollisionFood, Action onCollisionTile)
		{
			this.onCollisionFood = onCollisionFood;
			this.onCollisionTile = onCollisionTile;

			Transform = new TransformComponent
			{
				Position = new IntPoint(x, y)
			};
		}

		public SnakeTile Next { get; set; }

		public TransformComponent Transform { get; private set; }

		public void CopyPosition(SnakeTile other)
		{
			Transform.Position = other.Transform.Position;
		}

		public void Draw(IDrawContext context)
		{
			context.Canvas.Draw(Transform, '@');
		}

		public void OnCollision(Collision collision)
		{
			switch (collision.Other.Tag)
			{
				case "SnakeTile":
					onCollisionTile();
					break;

				case "Food":
					onCollisionFood();
					break;
			}
		}
	}
}