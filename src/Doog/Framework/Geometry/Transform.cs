using System;
using System.Diagnostics;

namespace Doog
{
    /// <summary>
    /// Component used to manipulate the position, size, scale and rotation.
    /// </summary>
    [DebuggerDisplay("{BoundingBox}")]
    public class Transform : ComponentBase
    {
        private Point _position;
        private Point _scale;
        private float _rotation;
        private Point _pivot;
        private Rectangle _originalBoundingBox;

        /// <summary>
        /// Initializes a new instance of the <see cref="Transform"/> class.
        /// </summary>
        /// <param name="context">The world context.</param>
        public Transform(IWorldContext context)
            : this(0, 0, context)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Transform"/> class.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="context">The context.</param>
        public Transform(float x, float y, IWorldContext context)
            : base(context)
        {
            _scale = Point.Zero;
            _pivot = Point.Zero;
            _originalBoundingBox = new Rectangle(x, y, 0, 0);
            Position = new Point(x, y);
        }

        /// <summary>
        /// Gets or sets the position.
        /// </summary>        
        public Point Position
        {
            get
            {
                return _position;
            }

            set
            {
                _position = value;
                Rebuild();
            }
        }

        /// <summary>
        /// Gets or sets the pivot. Default is 0, 0 (equals to left, top point)
        /// </summary>
        /// <remarks>
        /// Pivot its a % (0..1) of width and height:
        /// 0, 0 = left, top
        /// 0, 1 = left, bottom
        /// 1, 0 = right, top
        /// 1, 1 = right, bottom
        /// 0.5, 0.5 = center
        /// </remarks>
        /// <value>The pivot.</value>
        public Point Pivot
        {
            get
            {
                return _pivot;
            }

            set
            {
                _pivot = value;
                Rebuild();
            }
        }

        /// <summary>
        /// Gets or sets the scale.
        /// </summary>        
        public Point Scale
        {
            get
            {
                return _scale;
            }

            set
            {
                _scale = value;
                _originalBoundingBox = new Rectangle(_originalBoundingBox.Left, _originalBoundingBox.Top, value.X, value.Y);
                Rebuild();
            }
        }

        /// <summary>
        /// Gets or sets the rotation.
        /// </summary>        
        public float Rotation
        {
            get
            {
                return _rotation;
            }

            set
            {
                _rotation = value;
                Rebuild();
            }
        }

        /// <summary>
        /// Gets the bounding box.
        /// </summary>
        public Rectangle BoundingBox { get; private set; }

        /// <summary>
        /// Increments the position.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        public void IncrementPosition(float x, float y)
        {
            Position = new Point(_position.X + x, _position.Y + y);
        }

        /// <summary>
        /// Sets the x position.
        /// </summary>
        /// <param name="x">The x.</param>
        public void SetX(float x)
        {
            Position = new Point(x, _position.Y);
        }

        /// <summary>
        /// Sets the y position.
        /// </summary>
        /// <param name="y">The y.</param>
        public void SetY(float y)
        {
            Position = new Point(_position.X, y);
        }

        /// <summary>
        /// Determines whether this instance intersects the specified one.
        /// </summary>
        /// <param name="other">The other transform.</param>
        /// <returns>True if intersects, otherwise false.</returns>
        public bool Intersect(Transform other)
        {
            return BoundingBox.Intersect(other.BoundingBox);
        }

        private void Rebuild()
        {
            var cos = (float)Math.Cos(_rotation * Math.PI / 180f);
            var sin = (float)Math.Sin(_rotation * Math.PI / 180f);

            var r = _originalBoundingBox;
            var center = r.LeftTop + _scale * _pivot;
       
            BoundingBox = new Rectangle(
                CalculateCorner(_position, r.LeftTop, center, cos, sin),
                CalculateCorner(_position, r.RightTop, center, cos, sin),
                CalculateCorner(_position, r.RightBottom, center, cos, sin),
                CalculateCorner(_position, r.LeftBottom, center, cos, sin)
            );
        }

        private Point CalculateCorner(Point pos, Point corner, Point center, float angleCos, float angleSin)
        {
            return new Point(((corner.X - center.X) * angleCos - (corner.Y - center.Y) * angleSin) + pos.X,
                             ((corner.Y - center.Y) * angleCos + (corner.X - center.X) * angleSin) + pos.Y);
        }
    }
}
