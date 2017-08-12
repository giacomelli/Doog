using System.Diagnostics;

namespace Snake.Framework.Geometry
{
	/// <summary>
	/// Component used to manipulate the position and size.
	/// <remarks>
	/// In the future we can add rotation and scale to it.
	/// </remarks>
	/// </summary>
	[DebuggerDisplay("{BoundingBox}")]
	public class TransformComponent : ComponentBase
	{
		private Point position;
		private Point size;
		private Rectangle boundingBox;

		public TransformComponent()
		{
			Size = Point.Zero;
		}

		public TransformComponent(float x, float y)
			: this()
		{
			Position = new Point(x, y);
		}

		public Point Position
		{
			get
			{
				return position;
			}

			set
			{
				position = value;
				RebuildBoundingBox();
			}
		}

		public Point Size
		{
			get
			{
				return size;
			}

			set
			{
				size = value;
				RebuildBoundingBox();
			}
		}

		public void IncrementPosition(float x, float y)
		{
			Position = new Point(position.X + x, position.Y + y);
		}

		public bool Intersect(TransformComponent other)
		{
			return boundingBox.Intersect(other.boundingBox);
		}

		private void RebuildBoundingBox()
		{
			boundingBox = new Rectangle(position.X, position.Y, position.X + size.X, position.Y + size.Y);
		}
	}
}