using System;
using Doog;

namespace Doog
{
    /// <summary>
    /// An circle component.
    /// </summary>
    public class CircleComponent : ComponentBase, ICircle, IDrawable, ITransformable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CircleComponent"/> class.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="radius">The radius.</param>
        /// <param name="context">The context.</param>
        public CircleComponent(Point position, float radius, IWorldContext context)
         : this(position.X, position.Y, radius, context)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CircleComponent"/> class.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="radius">The radius.</param>
        /// <param name="context">The context.</param>
        public CircleComponent(float x, float y, float radius, IWorldContext context)
            : base(context)
        {
            Transform = new Transform(x, y, context);
            Transform.Scale = new Point(radius * 2);
            Sprite = '#';
            Filled = true;
        }

        /// <summary>
        /// Gets the transform.
        /// </summary>
        public Transform Transform { get; private set; }

        /// <summary>
        /// Gets or sets the sprite.
        /// </summary>        
        public char Sprite { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="CircleComponent"/> is filled.
        /// </summary>
        /// <value>
        ///   <c>true</c> if filled; otherwise, <c>false</c>.
        /// </value>
        public bool Filled { get; set; }

        float ICircle.Left { get { return Transform.BoundingBox.Left; } }

        float ICircle.Top { get { return Transform.BoundingBox.Top; } }

        float ICircle.Radius { get { return Transform.Scale.X / 2f; } }

        float ICircle.Right { get { return Transform.BoundingBox.Right; } }

        float ICircle.Bottom { get { return Transform.BoundingBox.Bottom; } }

        /// <summary>
        /// Draws the instance on the specified draw context.
        /// </summary>
        /// <param name="drawContext">The draw context.</param>
        public virtual void Draw(IDrawContext drawContext)
        {
            drawContext.Canvas.Draw(this, Filled, Sprite);
        }

        Point ICircle.GetCenter()
        {
            return Transform.BoundingBox.GetCenter();
        }
    }
}
