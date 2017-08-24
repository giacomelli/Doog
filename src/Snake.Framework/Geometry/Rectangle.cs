using System;
using System.Diagnostics;

namespace Snake.Framework.Geometry
{
    /// <summary>
    /// An immutable rectangle.
    /// </summary>
    [DebuggerDisplay("{Left}, {Top}, {Right}, {Bottom}")]
    public struct Rectangle
    {
        private readonly float left;
        private readonly float top;
        private readonly float right;

        private readonly float bottom;

        public Rectangle(float left, float top, float right, float bottom)
        {
            this.left = left;
            this.top = top;
            this.right = right;
            this.bottom = bottom;
        }

        public float Left
        {
            get
            {
                return left;
            }
        }

        public float Top
        {
            get
            {
                return top;
            }
        }

        public float Right
        {
            get
            {
                return right;
            }
        }

        public float Bottom
        {
            get
            {
                return bottom;
            }
        }

        public float Width
        {
            get
            {
                return right - left;
            }
        }

        public float Height
        {
            get
            {
                return bottom - top;
            }
        }

        public bool Contains(float x, float y)
        {
            return !(x < left ||
                    x > right ||
                    y < top ||
                    y > bottom);
        }

        public bool Intersect(Rectangle other)
        {
            if (this == other)
            {
                return true;
            }

            if (left >= other.right || other.left >= right)
            {
                return false;
            }

            if (top >= other.bottom || other.top >= bottom)
            {
                return false;
            }

			return true;
        }

        public Point GetCenter()
        {
            return new Point(
                left + (right - left) / 2,
                top + (bottom - top) / 2);
        }

        public Rectangle Scale(float scale)
        {
            return new Rectangle(left, top, right * scale, bottom * scale);
        }

		public override bool Equals(object obj)
		{
			if (!(obj is Rectangle))
			{
				return false;
			}

			return ((Rectangle)obj) == this;
		}

		public override int GetHashCode()
		{
			float hash = 23;
            hash = hash * 31 + left;
			hash = hash * 31 + top;
            hash = hash * 31 + right;
            hash = hash * 31 + bottom;

			return (int)hash;
		}

		public static bool operator ==(Rectangle a, Rectangle b)
		{
            return a.left.EqualsTo(b.left)
                    && a.top.EqualsTo(b.top)
                    && a.right.EqualsTo(b.Right)
                    && a.bottom.EqualsTo(b.bottom);
                 
		}

		public static bool operator !=(Rectangle a, Rectangle b)
		{
			return !(a == b);
		}
    }
}