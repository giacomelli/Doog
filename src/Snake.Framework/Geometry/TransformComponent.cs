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
		private IntPoint position;
		private IntPoint size;
		private IntRectangle boundingBox;

		public TransformComponent()
		{
			Size = IntPoint.Zero;
		}

		public TransformComponent(int x, int y)
			: this()
		{
			Position = new IntPoint(x, y);
		}

		public IntPoint Position
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

		public IntPoint Size
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

		public void IncrementPosition(int x, int y)
		{
			Position = new IntPoint(position.X + x, position.Y + y);
		}

		public bool Intersect(TransformComponent other)
		{
			return boundingBox.Intersect(other.boundingBox);
		}

		private void RebuildBoundingBox()
		{
			boundingBox = new IntRectangle(position.X, position.Y, position.X + size.X, position.Y + size.Y);
		}
	}
}