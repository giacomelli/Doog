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

        /// <summary>
        /// Initializes a new instance of the <see cref="Circle"/> struct.
        /// </summary>
        /// <param name="point">The pivot point.</param>
        /// <param name="radius">The radius.</param>
        public Circle(Point point, float radius)
            : this(point.X, point.Y, radius)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Circle"/> struct.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="top">The top.</param>
        /// <param name="radius">The radius.</param>
        public Circle(float left, float top, float radius)
        {
            _left = left;
            _top = top;
            _radius = radius;
            _right = left + radius * 2;
            _bottom = top + radius * 2; 
        }

        /// <summary>
        /// Gets a point in the circle in the specified position, radius and angle.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="radius">The radius.</param>
        /// <param name="angleInDegrees">The angle in degrees.</param>
        /// <returns>The point.</returns>
        public static Point GetPoint(Point position, float radius, float angleInDegrees)
        {            
            var angleInRadians = angleInDegrees * Math.PI / 180f;
            return new Point(
                position.X + radius * (float)Math.Cos(angleInRadians),
                position.Y + radius * (float)Math.Sin(angleInRadians));
        }

        /// <summary>
        /// Gets the most left x coordinate.
        /// </summary>
        public float Left => _left;

        /// <summary>
        /// Gets the most top y coordinate.
        /// </summary>
        public float Top => _top;

        /// <summary>
        /// Gets the most right x coordinate.
        /// </summary>
        public float Right => _right;

        /// <summary>
        /// Gets the most bottom y coordinate.
        /// </summary>
        public float Bottom => _bottom;

        /// <summary>
        /// Gets the radius.
        /// </summary>        
        public float Radius 
        {
            get
            {
                return _radius;
            }
        }

        /// <summary>
        /// Gets the center point.
        /// </summary>
        /// <returns></returns>
        public Point GetCenter()
		{
			return new Point(
				_left + (_right - _left) / 2,
				_top + (_bottom - _top) / 2);
		}
    }
}
