using System;

namespace Doog.Framework.Geometry
{
    /// <summary>
    /// An immutable circle.
    /// </summary>
    public struct Circle : ICircle
    {
        private readonly float left;
        private readonly float top;
        private readonly float right;
        private readonly float bottom;
        private readonly float radius;

        public Circle(Point point, float radius)
            : this(point.X, point.Y, radius)
        {
        }

        public Circle(float left, float top, float radius)
        {
            this.left = left;
            this.top = top;
            this.radius = radius;
            this.right = left + radius * 2;
            this.bottom = top + radius * 2; 
        }

        public static Point GetPoint(Point position, float radius, float angleInDegrees)
        {
            // TODO: create a type Angle (with properties Radians and Degrees)
            var angleInRadians = angleInDegrees * Math.PI / 180f;
            return new Point(
                position.X + radius * (float)Math.Cos(angleInRadians),
                position.Y + radius * (float)Math.Sin(angleInRadians));
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

        public float Radius 
        {
            get
            {
                return radius;
            }
        }

		public Point GetCenter()
		{
			return new Point(
				left + (right - left) / 2,
				top + (bottom - top) / 2);
		}
    }
}
