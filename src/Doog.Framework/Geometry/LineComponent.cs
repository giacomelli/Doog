using System;
using Doog.Framework;

namespace Doog.Framework
{
    /// <summary>
    /// An line component.
    /// </summary>
    public class LineComponent : ComponentBase, ILine, IDrawable, ITransformable
    {
        public LineComponent(Point pointA, Point pointB, IWorldContext context)
         : base(context)
        {
			Transform = new Transform(pointA.X, pointA.Y, context);
            PointB = pointB;
			Sprite = '#';
        }

        public LineComponent(float x1, float y1, float x2, float y2, IWorldContext context)
            : this(new Point(x1, y1), new Point(x2, y2), context)
        {
            
        }

        public Transform Transform { get; private set; }

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

        public Point PointB { get; set; }
        public char Sprite { get; set; }
       
      
        public virtual void Draw(IDrawContext drawContext)
        {
            drawContext.Canvas.Draw(this, Sprite);
        }
    }
}
