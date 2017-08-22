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
   	public class Transform : ComponentBase
	{
		private Point position;
        private Point scale;
		
		public Transform(IWorldContext context)
            : base(context)
		{
			Scale = Point.One;
		}

		public Transform(float x, float y, IWorldContext context)
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

		public Point Scale
		{
			get
			{
				return scale;
			}

			set
			{
				scale = value;
				RebuildBoundingBox();
			}
		}

        public Rectangle BoundingBox { get; private set; }


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

		public bool Intersect(Transform other)
		{
			return BoundingBox.Intersect(other.BoundingBox);
		}

		private void RebuildBoundingBox()
		{
			BoundingBox = new Rectangle(position.X, position.Y, position.X + scale.X, position.Y + scale.Y);
		}
	}
}
