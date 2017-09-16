using System.Diagnostics;

namespace Doog.Framework
{
    /// <summary>
    /// An immutable line.
    /// </summary>
    [DebuggerDisplay("{PointA} => {PointB}")]
    public struct Line : ILine
    {
        private readonly Point pointA;
        private readonly Point pointB;
     
        public Line(Point pointA, Point pointB)
        {
            this.pointA = pointA;
            this.pointB = pointB;
        }

        public Line(float pointAX, float pointAY, float pointBX, float pointBY)
            : this (new Point(pointAX, pointAY), new Point(pointBX, pointBY))
        {
        }

		public Point PointA
		{
			get
			{
				return pointA;
			}
		}

		public Point PointB
		{
			get
			{
				return pointB;
			}
		}

		public override bool Equals(object obj)
		{
			if (!(obj is Line))
			{
				return false;
			}

			return ((Line)obj) == this;
		}

		public override int GetHashCode()
		{
			unchecked
			{
				int hash = 17;
				hash = hash * 23 + pointA.GetHashCode();
				hash = hash * 23 + pointB.GetHashCode();
			
				return hash;
			}
		}

		public static bool operator ==(Line a, Line b)
		{
            return
                a.pointA == b.pointA && a.pointB == b.pointB;

		}

		public static bool operator !=(Line a, Line b)
		{
			return !(a == b);
		}
    }
}
