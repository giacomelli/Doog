using System;
using System.Diagnostics;
using Doog;

namespace Doog
{
    /// <summary>
    /// An immutable 2D point.
    /// </summary>
	[DebuggerDisplay("{X}, {Y}")]
    public struct Point
    {
        /// <summary>
        /// new Point(0).
        /// </summary>
        public static readonly Point Zero = new Point(0);

        /// <summary>
        /// new Point(0.5).
        /// </summary>
        public static readonly Point HalfOne = new Point(0.5f);

        /// <summary>
        /// new Point(1).
        /// </summary>
        public static readonly Point One = new Point(1);

        /// <summary>
        /// new Point(2).
        /// </summary>
        public static readonly Point Two = new Point(2);

        /// <summary>
        /// new Point(3).
        /// </summary>
        public static readonly Point Three = new Point(3);

        /// <summary>
        /// new Point(4).
        /// </summary>
        public static readonly Point Four = new Point(4);

        /// <summary>
        /// new Point(5).
        /// </summary>
        public static readonly Point Five = new Point(5);

        /// <summary>
        /// new Point(6).
        /// </summary>
        public static readonly Point Six = new Point(6);

        /// <summary>
        /// new Point(7).
        /// </summary>
        public static readonly Point Seven = new Point(7);

        /// <summary>
        /// new Point(8).
        /// </summary>
        public static readonly Point Eight = new Point(8);

        /// <summary>
        /// new Point(9).
        /// </summary>
        public static readonly Point Nine = new Point(9);

        /// <summary>
        /// new Point(10).
        /// </summary>
        public static readonly Point Ten = new Point(10);

        /// <summary>
        /// Point direction to up: new Point(0, -1).
        /// </summary>
        public static readonly Point Up = new Point(0, -1);

        /// <summary>
        /// Point direction to right: new Point(1, 0).
        /// </summary>
        public static readonly Point Right = new Point(1, 0);

        /// <summary>
        /// Point direction to down: new Point(0, 1).
        /// </summary>
        public static readonly Point Down = new Point(0, 1);

        /// <summary>
        /// Point direction to left: new Point(-1, 0).
        /// </summary>
        public static readonly Point Left = new Point(-1, 0);

        private readonly float _x;
        private readonly float _y;

        /// <summary>
        /// Initializes a new instance of the <see cref="Point"/> struct.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        public Point(float x, float y)
        {
            _x = x;
            _y = y;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Point"/> struct.
        /// </summary>
        /// <param name="xy">The xy.</param>
        public Point(float xy)
		{
			_x = xy;
			_y = xy;
		}

        /// <summary>
        /// Gets the x.
        /// </summary>
        public float X => _x;

        /// <summary>
        /// Gets the y.
        /// </summary>
        public float Y => _y;

        /// <summary>
        /// Calculates de distance between this point and specified one.
        /// </summary>
        /// <param name="other">The other point.</param>
        /// <returns>The distance.</returns>
        public float DistanceFrom(Point other)
        {
            return (float)Math.Sqrt(Math.Pow(other._x - _x, 2) + Math.Pow(other._y - _y, 2));
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
            if(!(obj is Point))
            {
                return false;
            }

            return ((Point)obj) == this;
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
                hash = hash * 23 + _x.GetHashCode();
                hash = hash * 23 + _y.GetHashCode();

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
            return string.Format("X={0}, Y={1}", X, Y);
        }

        public Point Transform(Matrix matrix)
        {
            return new Point(
                matrix.M11 * X + matrix.M12 * Y + matrix.M13,
                matrix.M21 * X + matrix.M22 * Y + matrix.M23);
        }

        /// <summary>
        /// Calculates the linear interpolation between the points in the time specified.
        /// </summary>
        /// <param name="from">The from point.</param>
        /// <param name="to">The to point.</param>
        /// <param name="time">The time.</param>
        /// <returns>The point.</returns>
        public static Point Lerp(Point from, Point to, float time)
        {
            return new Point(
                Easing.Linear.Calculate(from._x, to._x, time),
                Easing.Linear.Calculate(from._y, to._y, time));
        }

        /// <summary>
        /// Calculates the dot product (scalar prodcut) of the two points.
        /// </summary>
        /// <see href="https://en.wikipedia.org/wiki/Dot_product"/>
        /// <param name="a">The point A</param>
        /// <param name="b">The point B.</param>
        /// <returns>The dot product (scalar prodcut).</returns>
        public static float Dot(Point a, Point b)
        {
			return a._x * b._x + a._y * b._y;
	    }

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="a">The point A</param>
        /// <param name="b">The point B.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator == (Point a, Point b)
        {
            return a._x.EqualsTo(b._x) && a._y.EqualsTo(b._y);
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="a">The point A</param>
        /// <param name="b">The point B.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator !=(Point a, Point b)
		{
            return !(a == b);
		}

        /// <summary>
        /// Implements the operator +.
        /// </summary>
        /// <param name="a">The point A</param>
        /// <param name="b">The point B.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Point operator +(Point a, Point b)
        {
            return new Point(a._x + b._x, a._y + b._y);   
        }

        /// <summary>
        /// Implements the operator -.
        /// </summary>
        /// <param name="a">The point A</param>
        /// <param name="b">The point B.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Point operator -(Point a, Point b)
		{
			return new Point(a._x - b._x, a._y - b._y);
		}

        /// <summary>
        /// Implements the operator *.
        /// </summary>
        /// <param name="a">The point A</param>
        /// <param name="b">The point B.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Point operator *(Point a, Point b)
		{
			return new Point(a._x * b._x, a._y * b._y);
		}

        /// <summary>
        /// Implements the operator +.
        /// </summary>
        /// <param name="a">The point A</param>
        /// <param name="b">The float B.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Point operator +(Point a, float b)
		{
			return new Point(a._x + b, a._y + b);
		}

        /// <summary>
        /// Implements the operator -.
        /// </summary>
        /// <param name="a">The point A</param>
        /// <param name="b">The float B.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Point operator -(Point a, float b)
		{
			return new Point(a._x - b, a._y - b);
		}

        /// <summary>
        /// Implements the operator *.
        /// </summary>
        /// <param name="a">The point A</param>
        /// <param name="b">The float B.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Point operator *(Point a, float b)
		{
			return new Point(a._x * b, a._y * b);
		}

        /// <summary>
        /// Implements the operator /.
        /// </summary>
        /// <param name="a">The point A</param>
        /// <param name="b">The point B.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Point operator /(Point a, float b)
		{
			return new Point(a._x / b, a._y / b);
		}
	}
}