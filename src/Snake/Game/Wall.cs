using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Snake.Framework;
using Snake.Framework.Behaviors;
using Snake.Framework.Geometry;
using Snake.Framework.Graphics;
using Snake.Framework.Physics;

namespace Snake.Game
{
	public class Wall : ComponentBase, IDrawable, ICollidable
	{
		public Wall(float x, float y)
		{
			Transform = new TransformComponent(x, y);
		}

		public TransformComponent Transform { get; private set; }

		public void Draw(IDrawContext context)
		{
			context.Canvas.Draw(Transform, '#');
		}

		public void OnCollision(Collision collision)
		{
		}
	}
}