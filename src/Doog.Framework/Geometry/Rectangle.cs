using System;
using System.Diagnostics;

namespace Doog.Framework
{
    /// <summary>
    /// An immutable rectangle.
    /// </summary>
    [DebuggerDisplay("{Left}, {Top}, {Right}, {Bottom}")]
    public struct Rectangle
    {
        public static readonly Rectangle Zero = new Rectangle(0, 0, 0, 0);
     
        public Rectangle(float left, float top, float width, float height)
        {
            this.LeftTop = new Point(left, top);
            this.RightTop = new Point(left + width, top);
            this.RightBottom = new Point(left + width, top + height);
            this.LeftBottom = new Point(left, top + height);
            this.Width = width;
            this.Height = height;
        }

        internal Rectangle(Point leftTop, Point rightTop, Point rightBottom, Point leftBottom)
        {
            this.LeftTop = leftTop;
            this.RightTop = rightTop;
            this.RightBottom = rightBottom;
            this.LeftBottom = leftBottom;
            this.Width = leftTop.DistanceFrom(rightTop);
            this.Height = leftTop.DistanceFrom(leftBottom);
        }

        public Point LeftTop { get; private set; }
        public Point RightTop { get; private set; }
        public Point RightBottom { get; private set; }
        public Point LeftBottom { get; private set; }



		public float Left
        {
            get
            {
                return LeftTop.X;
            }
        }

        public float Top
        {
            get
            {
                return LeftTop.Y;
            }
        }

        public float Right
        {
            get
            {
                return RightTop.X;
            }
        }

        public float Bottom
        {
            get
            {
                return RightBottom.Y;
            }
        }

        public float Width { get; private set; }
     
        public float Height { get; private set; }
      
        public bool Contains(Point point)
        {
            return !(point.X < Left ||
                    point.X > Right ||
                    point.Y < Top ||
                    point.Y > Bottom);
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
            return "{0}, {1} | {2}, {3}".With(Left, Top, Width, Height);
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
