using System;
using System.Diagnostics;

namespace Snake.Framework.Geometry
{
    /// <summary>
    /// Component used to manipulate the position and size.
    /// <remarks>
    /// In the future we can add rotation and scale to it.
    /// </remarks>
    /// </summary>
    [DebuggerDisplay("{BoundingBox}")]
    public class Transform : ComponentBase
    {
        private Point position;
        private Point scale;
        private float rotation;
        private Point pivot;
        private Rectangle originalBoundingBox;

        public Transform(IWorldContext context)
            : this(0, 0, context)
        {
        }

        public Transform(float x, float y, IWorldContext context)
            : base(context)
        {
            scale = Point.Zero;
            pivot = Point.Zero;
            originalBoundingBox = new Rectangle(x, y, 0, 0);
            Position = new Point(x, y);
        }

        public Point Position
        {
            get
            {
                return position;
            }

            set
            {
                position = value;
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
                return pivot;
            }

            set
            {
                pivot = value;
                Rebuild();
            }
        }

        public Point Scale
        {
            get
            {
                return scale;
            }

            set
            {
                scale = value;
                originalBoundingBox = new Rectangle(originalBoundingBox.Left, originalBoundingBox.Top, value.X, value.Y);
                Rebuild();
            }
        }

        // TODO: when we support 3D, so this will need to change
        public float Rotation
        {
            get
            {
                return rotation;
            }

            set
            {
                rotation = value;
                Rebuild();
            }
        }

        public Rectangle BoundingBox { get; private set; }


        public void IncrementPosition(float x, float y)
        {
            Position = new Point(position.X + x, position.Y + y);
        }

        public void SetX(float x)
        {
            Position = new Point(x, position.Y);
        }

        public void SetY(float y)
        {
            Position = new Point(position.X, y);
        }

        public bool Intersect(Transform other)
        {
            return BoundingBox.Intersect(other.BoundingBox);
        }

        private void Rebuild()
        {
            var cos = (float)Math.Cos(rotation * Math.PI / 180f);
            var sin = (float)Math.Sin(rotation * Math.PI / 180f);

            var r = originalBoundingBox;
            var center = r.leftTop + scale * pivot;
       
            BoundingBox = new Rectangle(
                CalculateCorner(position, r.leftTop, center, cos, sin),
                CalculateCorner(position, r.rightTop, center, cos, sin),
                CalculateCorner(position, r.rightBottom, center, cos, sin),
                CalculateCorner(position, r.leftBottom, center, cos, sin)
            );
        }

        private Point CalculateCorner(Point pos, Point corner, Point center, float angleCos, float angleSin)
        {
            return new Point(((corner.X - center.X) * angleCos - (corner.Y - center.Y) * angleSin) + pos.X,
                             ((corner.Y - center.Y) * angleCos + (corner.X - center.X) * angleSin) + pos.Y);
        }
    }
}
