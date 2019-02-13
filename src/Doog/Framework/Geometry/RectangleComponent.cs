using Doog;

namespace Doog
{
    /// <summary>
    /// A rectangle component.
    /// </summary>
    public class RectangleComponent : ComponentBase, IDrawable, ITransformable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RectangleComponent"/> class.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="context">The context.</param>
        public RectangleComponent(Point position, IWorldContext context)
            : this (position.X, position.Y, context)
        {
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RectangleComponent"/> class.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="scale">The scale.</param>
        /// <param name="context">The context.</param>
        public RectangleComponent(Point position, float scale, IWorldContext context)
			: this(position.X, position.Y, scale, context)
		{

		}

        /// <summary>
        /// Initializes a new instance of the <see cref="RectangleComponent"/> class.
        /// </summary>
        /// <param name="other">The other.</param>
        public RectangleComponent(RectangleComponent other)
			: this(other.Transform.Position.X, other.Transform.Position.Y, other.Context)
		{
            Transform.Scale = other.Transform.Scale;
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="RectangleComponent"/> class.
        /// </summary>
        /// <param name="other">The other.</param>
        /// <param name="context">The context.</param>
        public RectangleComponent(Rectangle other, IWorldContext context)
			: this(other.Left, other.Top, context)
		{
            Transform.Scale = new Point(other.Width, other.Height);
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="RectangleComponent"/> class.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="scale">The scale.</param>
        /// <param name="context">The context.</param>
        public RectangleComponent(float x, float y, float scale, IWorldContext context)
          : this(new Rectangle(x, y, scale, scale), context)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RectangleComponent"/> class.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="context">The context.</param>
        public RectangleComponent(float x, float y, IWorldContext context)
            : base(context)
        {
            Transform = new Transform(x, y, context);
            Sprite = '#';
            Filled = false;
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
        /// Gets or sets a value indicating whether this <see cref="RectangleComponent"/> is filled.
        /// </summary>
        /// <value>
        ///   <c>true</c> if filled; otherwise, <c>false</c>.
        /// </value>
        public bool Filled { get; set; }

        /// <summary>
        /// Draws the instance on the specified draw context.
        /// </summary>
        /// <param name="drawContext">The draw context.</param>
        public virtual void Draw(IDrawContext drawContext)
        {
            drawContext.Canvas.Draw(Transform.BoundingBox, Filled, Sprite);
        }
    }
}
