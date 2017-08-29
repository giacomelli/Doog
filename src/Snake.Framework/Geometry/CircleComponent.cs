using System;
using Snake.Framework.Graphics;

namespace Snake.Framework.Geometry
{
    /// <summary>
    /// An circle component.
    /// </summary>
    public class CircleComponent : ComponentBase, ICircle, IDrawable
    {
       	public CircleComponent(Point position, float radius, IWorldContext context)
            : this(position.X, position.Y, radius, context) 
        {
            
        }

        public CircleComponent(float x, float y, float radius, IWorldContext context)
            : base(context)
        {
            Transform = new Transform(x, y, context);
            Transform.Scale = new Point(radius);
         	Sprite = '#';
			Filled = true;
        }

        public Transform Transform { get; private set; }
        public float Radius { get; set; }
		public char Sprite { get; set; }
		public bool Filled { get; set; }

        float ICircle.X  { get { return Transform.Position.X; }}

        float ICircle.Y { get { return Transform.Position.Y; } }

        float ICircle.Radius { get { return Transform.Scale.X / 2f; } }

        public virtual void Draw(IDrawContext context)
        {
            context.Canvas.Draw(this, Filled, Sprite);
        }
    }
}
