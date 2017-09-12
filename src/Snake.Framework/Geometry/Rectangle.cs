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
        public static readonly Rectangle Zero = new Rectangle(0, 0, 0, 0);

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

			this.leftTop = new Point(left, top);
			this.rightTop = new Point(right, top);
			this.rightBottom = new Point(right, bottom);
			this.leftBottom = new Point(left, bottom);
        }


        public Point leftTop;
        public Point rightTop; 
        public Point rightBottom;
        public Point leftBottom;

        public Rectangle(Point leftTop, Point rightTop, Point rightBottom, Point leftBottom)
        {
            this.leftTop = leftTop;
            this.rightTop = rightTop;
            this.rightBottom = rightBottom;
            this.leftBottom = leftBottom;

            this.left = leftTop.X;
            this.top = leftTop.Y;
			this.right = rightTop.X;
			this.bottom = rightBottom.Y;
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
                return leftTop.DistanceFrom(rightTop);
            }
        }

        public float Height
        {
            get
            {
                 return leftTop.DistanceFrom(leftBottom);
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
            if (left >= other.right || other.left >= right
             || top >= other.bottom || other.top >= bottom)
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
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + left.GetHashCode();
                hash = hash * 23 + top.GetHashCode();
                hash = hash * 23 + right.GetHashCode();
                hash = hash * 23 + bottom.GetHashCode();

                return hash;
            }
		}

        public override string ToString()
        {
            return "{0}, {1}, {2}, {3}".With(left, top, right, bottom);
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

        public static Rectangle operator *(Rectangle a, float multiplier)
        {
            return new Rectangle(a.left, a.top, a.right * multiplier, a.bottom * multiplier);
        }

		public static Rectangle operator +(Rectangle a, Rectangle b)
		{
			return new Rectangle(
                a.left + b.left, 
                a.top + b.top, 
                a.right + b.right, 
                a.bottom + b.bottom);
		}

		public static Rectangle operator +(Rectangle a, Point b)
		{
			return new Rectangle(
				a.left + b.X,
				a.top + b.Y,
				a.right + b.X,
				a.bottom + b.Y);
		}
    }
}