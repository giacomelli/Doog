﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Doog;

namespace Breakout
{
	public class Ball : RectangleComponent, IDrawable, ICollidable, IUpdatable
	{
		public static readonly Point DefaultScale = Point.Zero;

		public event EventHandler Fall;

		private Point direction;

		private float speed;

		private IList<CollisionInfo> collisionInfos = new List<CollisionInfo>();


		public Ball(IWorldContext context)
				: base(new Rectangle(0, 0, 2, 2),context)
		{
			direction = new Point(1, 1);
			Pixel = 'o'.Yellow();
			Transform.Scale = DefaultScale;
			speed = 20.0f;
		}

		public void OnCollision(Collision collision)
		{
			var otherTag = collision.Other.Tag;

			Debugger.Log(1, "Collision", otherTag);
			if (collisionInfos.Any(c => c.Name == otherTag))
			{
				return;
			}

			if (otherTag == "Paddle")
			{
				direction = new Point(direction.X, direction.Y * -1f);
			}
			else if (otherTag == "TopWall")
			{
				direction = new Point(direction.X, direction.Y * -1f);
			}
			else if (otherTag == "LeftWall")
			{
				direction = new Point(direction.X * -1f, direction.Y);
			}
			else if (otherTag == "RightWall")
			{
				direction = new Point(direction.X * -1f, direction.Y);
			}
			else if (otherTag == "BottomWall")
			{
				Fall?.Invoke(this, EventArgs.Empty);
			}
			else if (otherTag == "Tile")
			{
				direction = new Point(direction.X, direction.Y * -1f);
				collision.Other.Remove();
			}

			collisionInfos.Add(new CollisionInfo
			{
				MaxElapsed = 0.2f,
				Name = otherTag
			});
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
			var toRemove = new List<CollisionInfo>();
			foreach(var info in collisionInfos)
			{
				info.Elapsed = info.Elapsed + Context.Time.SinceLastFrame;
				if (info.Elapsed >= info.MaxElapsed)
				{
					toRemove.Add(info);
				}
			}

			foreach(var info in toRemove)
			{
				collisionInfos.Remove(info);
			}

			Transform.Position += direction * speed * Context.Time.SinceLastFrame;
		}
	}
}
