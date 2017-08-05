using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Snake.Framework.Geometry
{
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

		public IntRectangle BoundingBox
		{
			get
			{
				return boundingBox;
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
