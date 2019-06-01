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
        private Point _scale;
        private float _rotation;
        private Point _pivot;
        private Rectangle _originalBoundingBox;
        private Matrix _translationMatrix;
        private Matrix _scalingMatrix;
        private Matrix _rotationMatrix;

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
            _scale = Point.One;
            _pivot = Point.Zero;
            _originalBoundingBox = new Rectangle(x, y, 1, 1);
            Position = new Point(x, y);
        }

        /// <summary>
        /// Gets or sets the position.
        /// </summary>        
        public Point Position
        {
            get
            {
                return _translationMatrix.Translation;
            }

            set
            {
                _translationMatrix.Translation = value;
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
              //  Rebuild();
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
                var scaleValueForMatrix = (value - _scale) + Point.One;
                _scalingMatrix = Matrix.CreateScale(scaleValueForMatrix.X, scaleValueForMatrix.Y);
                _scale = value;
               
                //_originalBoundingBox = new Rectangle(_originalBoundingBox.Left, _originalBoundingBox.Top, value.X, value.Y);
               // Rebuild();
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
                _rotationMatrix = Matrix.CreateRotation(value);
               //Rebuild();
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
            var current = _translationMatrix.Translation;
            Position = new Point(current.X + x, current.Y + y);
        }

        /// <summary>
        /// Sets the x position.
        /// </summary>
        /// <param name="x">The x.</param>
        public void SetX(float x)
        {
            Position = new Point(x, _translationMatrix.Translation.Y);
        }

        /// <summary>
        /// Sets the y position.
        /// </summary>
        /// <param name="y">The y.</param>
        public void SetY(float y)
        {
            Position = new Point(_translationMatrix.Translation.X, y);
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
            //var r = new Rectangle(_originalBoundingBox.Left, _originalBoundingBox.Right, _scale.X, _scale.Y);
            var r = _originalBoundingBox;
            var pivotWorldPos = this.GetPivotWorldPosition();
            var pivotLocalPos = this.GetPivotLocalPosition();

            BoundingBox = new Rectangle(
               CalculateCorner(r.LeftTop, Point.Zero, pivotWorldPos, pivotLocalPos),
               CalculateCorner(r.RightTop, Point.Right, pivotWorldPos, pivotLocalPos),
               CalculateCorner(r.RightBottom, new Point(1,1), pivotWorldPos, pivotLocalPos),
               CalculateCorner(r.LeftBottom, Point.Down, pivotWorldPos, pivotLocalPos)
           );
        }

        private Point CalculateCorner(Point cornerWorlPos, Point cornerLocalPos, Point pivotWorldPos, Point pivotLocalPos)
        {
            var originTranslationMatrix = Matrix.CreateTranslation(pivotWorldPos.X, pivotWorldPos.Y);

            var pivotCornerPosition = cornerWorlPos - pivotLocalPos;
            var cornerTranslationMatrix = Matrix.CreateTranslation(pivotCornerPosition.X, pivotCornerPosition.Y);
         
            // http://web.cse.ohio-state.edu/~shen.94/681/Site/Slides_files/transformation_review.pdf
            // Affine Transformation 
            var transformMatrix = originTranslationMatrix * _scalingMatrix * cornerTranslationMatrix;
       
            return cornerWorlPos.Transform(transformMatrix);
        }
    }
}
