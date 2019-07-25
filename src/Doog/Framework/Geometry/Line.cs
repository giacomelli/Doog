using System.Diagnostics;

namespace Doog
{
    /// <summary>
    /// An immutable line.
    /// </summary>
    [DebuggerDisplay("{PointA} => {PointB}")]
    public struct Line : ILine
    {
        private readonly Point pointA;
        private readonly Point pointB;

        /// <summary>
        /// Initializes a new instance of the <see cref="Line"/> struct.
        /// </summary>
        /// <param name="pointA">The point a.</param>
        /// <param name="pointB">The point b.</param>
        public Line(Point pointA, Point pointB)
        {
            this.pointA = pointA;
            this.pointB = pointB;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Line"/> struct.
        /// </summary>
        /// <param name="pointAX">The point ax.</param>
        /// <param name="pointAY">The point ay.</param>
        /// <param name="pointBX">The point bx.</param>
        /// <param name="pointBY">The point by.</param>
        public Line(float pointAX, float pointAY, float pointBX, float pointBY)
            : this (new Point(pointAX, pointAY), new Point(pointBX, pointBY))
        {
        }

        /// <summary>
        /// Gets the point A.
        /// </summary>
        public Point PointA => pointA;

        /// <summary>
        /// Gets the point B.
        /// </summary>        
        public Point PointB => pointB;

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
		{
			if (!(obj is Line))
			{
				return false;
			}

			return ((Line)obj) == this;
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
				hash = hash * 23 + pointA.GetHashCode();
				hash = hash * 23 + pointB.GetHashCode();
			
				return hash;
			}
		}

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="a">The a operand.</param>
        /// <param name="b">The b operand.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator ==(Line a, Line b)
		{
            return
                a.pointA == b.pointA && a.pointB == b.pointB;

		}

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="a">The a operand.</param>
        /// <param name="b">The b operand.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator !=(Line a, Line b)
		{
			return !(a == b);
		}
    }
}