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
        private readonly float width;
        private readonly float height;

        public Rectangle(float left, float top, float width, float height)
        {
            this.leftTop = new Point(left, top);
            this.rightTop = new Point(left + width, top);
            this.rightBottom = new Point(left + width, top + height);
            this.leftBottom = new Point(left, top + height);
            this.width = width;
            this.height = height;
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
            this.width = leftTop.DistanceFrom(rightTop);
            this.height = leftTop.DistanceFrom(leftBottom);
        }


        public float Left
        {
            get
            {
                return leftTop.X;
            }
        }

        public float Top
        {
            get
            {
                return leftTop.Y;
            }
        }

        public float Right
        {
            get
            {
                return rightTop.X;
            }
        }

        public float Bottom
        {
            get
            {
                return rightBottom.Y;
            }
        }

        public float Width
        {
            get
            {
                return width;
            }
        }

        public float Height
        {
            get
            {
                return height;
            }
        }

        public bool Contains(Point point)
        {
            return !(point.X < Left ||
                    point.X > Right ||
                    point.Y < Top ||
                    point.Y > Bottom);
        }

        private Point vector(Point a, Point b)
        {
            return new Point(b.X - a.X, b.Y - a.Y);    
        }

		public bool Intersect(Rectangle other)
        {
            if (Left > other.Right || other.Left > Right
             || Top > other.Bottom || other.Top > Bottom)
            {
                return false;
            }

            return true;
        }

        public Point GetCenter()
        {
            return new Point(
                Left + (Right - Left) / 2,
                Top + (Bottom - Top) / 2);
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
                hash = hash * 23 + Left.GetHashCode();
                hash = hash * 23 + Top.GetHashCode();
                hash = hash * 23 + Right.GetHashCode();
                hash = hash * 23 + Bottom.GetHashCode();

                return hash;
            }
        }

        public override string ToString()
        {
            return "{0}, {1}, {2}, {3}".With(Left, Top, Right, Bottom);
        }

        public static bool operator ==(Rectangle a, Rectangle b)
        {
            return a.Left.EqualsTo(b.Left)
                    && a.Top.EqualsTo(b.Top)
                    && a.Right.EqualsTo(b.Right)
                    && a.Bottom.EqualsTo(b.Bottom);

        }

        public static bool operator !=(Rectangle a, Rectangle b)
        {
            return !(a == b);
        }

        public static Rectangle operator *(Rectangle a, float multiplier)
        {
            return new Rectangle(a.Left, a.Top, a.Width * multiplier, a.Height * multiplier);
        }

        public static Rectangle operator +(Rectangle a, Point b)
        {
            return new Rectangle(
                a.Left + b.X,
                a.Top + b.Y,
                a.Width + b.X,
                a.Height + b.Y);
        }
    }
}
