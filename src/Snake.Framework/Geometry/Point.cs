using System;
using System.Diagnostics;

namespace Snake.Framework.Geometry
{
    /// <summary>
    /// An immutable 2D point.
    /// </summary>
	[DebuggerDisplay("{X}, {Y}")]
	public struct Point
    {
		public static readonly Point Zero = new Point(0, 0);
		public static readonly Point One = new Point(1, 1);

        private readonly float x;
        private readonly float y;

        public Point(float x, float y)
        {
            this.x = x;
            this.y = y;
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

        public double DistanceFrom(Point other)
        {
            return Math.Sqrt(Math.Pow(other.x - x, 2) + Math.Pow(other.y - y, 2));
        }
	}
}