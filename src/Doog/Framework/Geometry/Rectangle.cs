using System.Diagnostics;

namespace Doog
{
    /// <summary>
    /// An immutable rectangle.
    /// </summary>
    [DebuggerDisplay("{Left}, {Top}, {Right}, {Bottom}")]
    public struct Rectangle
    {
        /// <summary>
        /// new Rectangle(0, 0, 0, 0).
        /// </summary>
        public static readonly Rectangle Zero = new Rectangle(0, 0, 0, 0);

        /// <summary>
        /// Initializes a new instance of the <see cref="Rectangle"/> struct.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="top">The top.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
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

        /// <summary>
        /// Gets the left top point.
        /// </summary>
        public Point LeftTop { get; private set; }

        /// <summary>
        /// Gets the right top point.
        /// </summary>
        public Point RightTop { get; private set; }

        /// <summary>
        /// Gets the right bottom point.
        /// </summary>
        public Point RightBottom { get; private set; }

        /// <summary>
        /// Gets the left bottom point.
        /// </summary>
        public Point LeftBottom { get; private set; }

        /// <summary>
        /// Gets the left.
        /// </summary>
        public float Left => LeftTop.X;

        /// <summary>
        /// Gets the top.
        /// </summary>   
        public float Top => LeftTop.Y;

        /// <summary>
        /// Gets the right.
        /// </summary>
        public float Right => RightTop.X;

        /// <summary>
        /// Gets the bottom.
        /// </summary>
        public float Bottom => RightBottom.Y;

        /// <summary>
        /// Gets the width.
        /// </summary>
        public float Width { get; private set; }

        /// <summary>
        /// Gets the height.
        /// </summary>
        public float Height { get; private set; }

        /// <summary>
        /// Determines whether the specified point is a point in the rectangle.
        /// </summary>
        /// <param name="point">The point.</param>
        /// <returns>
        ///   <c>true</c> if contains the specified point; otherwise, <c>false</c>.
        /// </returns>
        public bool Contains(Point point)
        {
            return !(point.X < Left ||
                    point.X > Right ||
                    point.Y < Top ||
                    point.Y > Bottom);
        }

        /// <summary>
        /// Determines whether this rectangle intersects the specified one.
        /// </summary>
        /// <param name="other">The other rectangle.</param>
        /// <returns>True if intersects, othewise false</returns>
        public bool Intersect(Rectangle other)
        {
            if (Left > other.Right || other.Left > Right
             || Top > other.Bottom || other.Top > Bottom)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Gets the center.
        /// </summary>
        /// <returns>The center point.</returns>
        public Point GetCenter()
        {
            return new Point(
                Left + (Right - Left) / 2,
                Top + (Bottom - Top) / 2);
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (!(obj is Rectangle))
            {
                return false;
            }

            return ((Rectangle)obj) == this;
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
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

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return "{0}, {1} | {2}, {3}".With(Left, Top, Width, Height);
        }


        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="a">The rectangle A.</param>
        /// <param name="b">The rectangle B.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator ==(Rectangle a, Rectangle b)
        {
            return a.Left.EqualsTo(b.Left)
                    && a.Top.EqualsTo(b.Top)
                    && a.Right.EqualsTo(b.Right)
                    && a.Bottom.EqualsTo(b.Bottom);

        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="a">The rectangle A.</param>
        /// <param name="b">The rectangle B.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator !=(Rectangle a, Rectangle b)
        {
            return !(a == b);
        }

        /// <summary>
        /// Implements the operator *
        /// </summary>
        /// <param name="a">The rectangle A.</param>
        /// <param name="multiplier">The multiplier.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Rectangle operator *(Rectangle a, float multiplier)
        {
            return new Rectangle(a.Left, a.Top, a.Width * multiplier, a.Height * multiplier);
        }

        /// <summary>
        /// Implements the operator +
        /// </summary>
        /// <param name="a">The rectangle A.</param>
        /// <param name="b">The point to sum.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
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
