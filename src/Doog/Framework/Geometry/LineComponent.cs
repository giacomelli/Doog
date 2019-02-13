using System;
using Doog;

namespace Doog
{
    /// <summary>
    /// An line component.
    /// </summary>
    public class LineComponent : ComponentBase, ILine, IDrawable, ITransformable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LineComponent"/> class.
        /// </summary>
        /// <param name="pointA">The point a.</param>
        /// <param name="pointB">The point b.</param>
        /// <param name="context">The context.</param>
        public LineComponent(Point pointA, Point pointB, IWorldContext context)
         : base(context)
        {
			Transform = new Transform(pointA.X, pointA.Y, context);
            PointB = pointB;
			Sprite = '#';
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LineComponent"/> class.
        /// </summary>
        /// <param name="x1">The x1.</param>
        /// <param name="y1">The y1.</param>
        /// <param name="x2">The x2.</param>
        /// <param name="y2">The y2.</param>
        /// <param name="context">The context.</param>
        public LineComponent(float x1, float y1, float x2, float y2, IWorldContext context)
            : this(new Point(x1, y1), new Point(x2, y2), context)
        {
            
        }

        /// <summary>
        /// Gets the transform.
        /// </summary>
        public Transform Transform { get; private set; }

        /// <summary>
        /// Gets the point A.
        /// </summary>
        public Point PointA
        {
            get
            {
                return Transform.Position;
            }

            set
            {
                Transform.Position = value;    
            }
        }

        /// <summary>
        /// Gets the point B.
        /// </summary>
        public Point PointB { get; set; }

        /// <summary>
        /// Gets or sets the sprite.
        /// </summary>       
        public char Sprite { get; set; }

        /// <summary>
        /// Draws the instance on the specified draw context.
        /// </summary>
        /// <param name="drawContext">The draw context.</param>
        public virtual void Draw(IDrawContext drawContext)
        {
            drawContext.Canvas.Draw(this, Sprite);
        }
    }
}
