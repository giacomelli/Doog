using Snake.Framework.Graphics;

namespace Snake.Framework.Geometry
{
    /// <summary>
    /// A rectangle component.
    /// </summary>
    public class RectangleComponent : ComponentBase, IDrawable
    {
		public RectangleComponent(Point position, IWorldContext context)
            : this (position.X, position.Y, context)
        {
            
        }

        public RectangleComponent(float x, float y, IWorldContext context)
            : base(context)
        {
            Transform = new Transform(x, y, context);
            Sprite = '#';
            Filled = true;
        }

        public Transform Transform { get; private set; }
        public char Sprite { get; set; }
        public bool Filled { get; set; }

        public virtual void Draw(IDrawContext context)
        {
            context.Canvas.Draw(Transform.BoundingBox, Filled, Sprite);
        }
    }
}
