using System;

namespace Snake.Framework.Geometry
{
    /// <summary>
    /// An immutable integer 2D point.
    /// </summary>
    public struct IntPoint
    {
        private readonly int x;
        private readonly int y;

        public IntPoint(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int X
        {
            get
            {
                return x;
            }
        }

        public int Y
        {
            get
            {
                return y;
            }
        }

        public double DistanceFrom(IntPoint other)
        {
            return Math.Sqrt(Math.Pow(other.x - x, 2) + Math.Pow(other.y - y, 2));
        }
    }
}