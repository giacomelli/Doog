﻿using System.Diagnostics;
using Doog;

namespace Breakout
{
	public class Ball : RectangleComponent, IDrawable, ICollidable, IUpdatable
	{
		public static readonly Point DefaultScale = Point.Zero;

		private Point direction;
		private float collisionElapsed;
		private string lastCollision;

		public Ball(IWorldContext context)
				: base(new Rectangle(0, 0, 2, 2),context)
		{
			direction = new Point(1, 1);
			Pixel = 'o'.Yellow();
			Transform.Scale = DefaultScale;
		}

		public void OnCollision(Collision collision)
		{
			var otherTag = collision.Other.Tag;

			Debugger.Log(1, "Collision", otherTag);
			if (lastCollision == null && (otherTag == "Paddle" || otherTag == "Wall"))
			{
				lastCollision = otherTag;
				collisionElapsed = 0;
				direction *= -1f;
			}
		}

		protected override void OnEnabled()
		{
			base.OnEnabled();
			Transform.Enabled = true;
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			Transform.Enabled = false;
		}

		public void Update()
		{
			if (lastCollision != null)
			{
				collisionElapsed += Context.Time.SinceLastFrame;
				if (collisionElapsed >= 0.2f)
				{
					lastCollision = null;
					collisionElapsed = 0;
				}
			}

			Transform.Position += direction * Context.Time.SinceLastFrame;
		}
	}
}
