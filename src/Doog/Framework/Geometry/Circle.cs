using System;

namespace Doog
{
    /// <summary>
    /// An immutable circle.
    /// </summary>
    public struct Circle : ICircle
    {
        private readonly float _left;
        private readonly float _top;
        private readonly float _right;
        private readonly float _bottom;
        private readonly float _radius;

        public Circle(Point point, float radius)
            : this(point.X, point.Y, radius)
        {
        }

        public Circle(float left, float top, float radius)
        {
            _left = left;
            _top = top;
            _radius = radius;
            _right = left + radius * 2;
            _bottom = top + radius * 2; 
        }

        public static Point GetPoint(Point position, float radius, float angleInDegrees)
        {            
            var angleInRadians = angleInDegrees * Math.PI / 180f;
            return new Point(
                position.X + radius * (float)Math.Cos(angleInRadians),
                position.Y + radius * (float)Math.Sin(angleInRadians));
        }

		public float Left
		{
			get
			{
				return _left;
			}
		}

		public float Top
		{
			get
			{
				return _top;
			}
		}

		public float Right
		{
			get
			{
				return _right;
			}
		}

		public float Bottom 
		{
			get
			{
				return _bottom;
			}
		}

        public float Radius 
        {
            get
            {
                return _radius;
            }
        }

		public Point GetCenter()
		{
			return new Point(
				_left + (_right - _left) / 2,
				_top + (_bottom - _top) / 2);
		}
    }
}
