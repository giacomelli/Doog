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
    // TODO: maybe only Transform is a better name.
	public class TransformComponent : ComponentBase
	{
		private Point position;
		private Point size;
		private Rectangle boundingBox;

		public TransformComponent(IWorldContext context)
            : base(context)
		{
			Size = Point.Zero;
		}

		public TransformComponent(float x, float y, IWorldContext context)
			: this(context)
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

		public void SetX(float x)
		{
			Position = new Point(x, position.Y);
		}

		public void SetY(float y)
		{
			Position = new Point(position.X, y);
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
