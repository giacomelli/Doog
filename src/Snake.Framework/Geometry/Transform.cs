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
        private Point pivot;
		
		public Transform(IWorldContext context)
            : base(context)
		{
			Scale = Point.One;
            pivot = Point.Zero;
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
				Rebuild();
			}
		}

		/// <summary>
		/// Gets or sets the pivot. Default is 0, 0 (equals to left, top point)
		/// </summary>
		/// <remarks>
		/// Pivot its a % (0..1) of width and height:
		/// 0, 0 = left, top
		/// 0, 1 = left, bottom
		/// 1, 0 = right, top
		/// 1, 1 = right, bottom
		/// 0.5, 0.5 = center
		/// </remarks>
		/// <value>The pivot.</value>
		public Point Pivot
		{
			get
			{
				return pivot;
			}

			set
			{
				pivot = value;
				Rebuild();
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
				Rebuild();
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

        private void Rebuild()
		{
            var left = position.X - scale.X * Pivot.X;
            var top = position.Y - scale.Y * Pivot.Y;

			BoundingBox = new Rectangle(
                left, 
                top,
                left + scale.X,
                top + scale.Y);
    	}
	}
}
