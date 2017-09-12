using System;
using System.Diagnostics;
using Snake.Framework.Animations;

namespace Snake.Framework.Geometry
{
    /// <summary>
    /// An immutable 2D point.
    /// </summary>
	[DebuggerDisplay("{X}, {Y}")]
    public struct Point
    {
        public static readonly Point Zero = new Point(0);
        public static readonly Point HalfOne = new Point(0.5f);
        public static readonly Point One = new Point(1);
        public static readonly Point Two = new Point(2);
        public static readonly Point Three = new Point(3);
        public static readonly Point Four = new Point(4);
        public static readonly Point Five = new Point(5);
        public static readonly Point Six = new Point(6);
        public static readonly Point Seven = new Point(7);
        public static readonly Point Eight = new Point(8);
        public static readonly Point Nine = new Point(9);
        public static readonly Point Ten= new Point(10);

        private readonly float x;
        private readonly float y;

        public Point(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

		public Point(float xy)
		{
			this.x = xy;
			this.y = xy;
		}

        public float X
        {
            get
            {
                return x;
            }
        }

        public float Y
        {
            get
            {
                return y;
            }
        }

        public float DistanceFrom(Point other)
        {
            return (float)Math.Sqrt(Math.Pow(other.x - x, 2) + Math.Pow(other.y - y, 2));
        }

        public override bool Equals(object obj)
        {
            if(!(obj is Point))
            {
                return false;
            }

            return ((Point)obj) == this;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + x.GetHashCode();
                hash = hash * 23 + y.GetHashCode();

                return hash;
            }
        }

        public override string ToString()
        {
            return string.Format("X={0}, Y={1}", X, Y);
        }

        public static Point Lerp(Point from, Point to, float time)
        {
            return new Point(
                Easing.Linear.Calculate(from.x, to.x, time),
                Easing.Linear.Calculate(from.y, to.y, time));
        }

        public static bool operator == (Point a, Point b)
        {
            return a.x.EqualsTo(b.x) && a.y.EqualsTo(b.y);
        }

		public static bool operator !=(Point a, Point b)
		{
            return !(a == b);
		}

        public static Point operator +(Point a, Point b)
        {
            return new Point(a.x + b.x, a.y + b.y);   
        }

		public static Point operator -(Point a, Point b)
		{
			return new Point(a.x - b.x, a.y - b.y);
		}

		public static Point operator *(Point a, Point b)
		{
			return new Point(a.x * b.x, a.y * b.y);
		}

		public static Point operator +(Point a, float b)
		{
			return new Point(a.x + b, a.y + b);
		}

		public static Point operator -(Point a, float b)
		{
			return new Point(a.x - b, a.y - b);
		}

		public static Point operator *(Point a, float b)
		{
			return new Point(a.x * b, a.y * b);
		}

		public static Point operator /(Point a, float b)
		{
			return new Point(a.x / b, a.y / b);
		}
	}
}