using Doog.Framework.Graphics;

namespace Doog.Framework.Geometry
{
    /// <summary>
    /// A rectangle component.
    /// </summary>
    public class RectangleComponent : ComponentBase, IDrawable, ITransformable
    {
		public RectangleComponent(Point position, IWorldContext context)
            : this (position.X, position.Y, context)
        {
            
        }

		public RectangleComponent(Point position, float scale, IWorldContext context)
			: this(position.X, position.Y, scale, context)
		{

		}

		public RectangleComponent(RectangleComponent other)
			: this(other.Transform.Position.X, other.Transform.Position.Y, other.Context)
		{
            Transform.Scale = other.Transform.Scale;
		}

		public RectangleComponent(Rectangle other, IWorldContext context)
			: this(other.Left, other.Top, context)
		{
            Transform.Scale = new Point(other.Width, other.Height);
		}

        public RectangleComponent(float x, float y, float scale, IWorldContext context)
          : this(new Rectangle(x, y, scale, scale), context)
        {
        }

        public RectangleComponent(float x, float y, IWorldContext context)
            : base(context)
        {
            Transform = new Transform(x, y, context);
            Sprite = '#';
            Filled = false;
        }

        public Transform Transform { get; private set; }
        public char Sprite { get; set; }
        public bool Filled { get; set; }

        public virtual void Draw(IDrawContext drawContext)
        {
            drawContext.Canvas.Draw(Transform.BoundingBox, Filled, Sprite);
        }
    }
}
