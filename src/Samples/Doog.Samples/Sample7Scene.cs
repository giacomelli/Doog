﻿namespace Doog.Samples
{
    public class Sample7Scene : SceneBase
    {
        private LineComponent hourLine;
        private LineComponent minuteLine;
		private LineComponent secondLine;

        private CircleComponent circle;
   
		public Sample7Scene(IWorldContext context)
            : base(context)
        {
            
        }

        public override void Initialize()
        {
            Context.RemoveAllComponents();

            var center = Context.Bounds.GetCenter();

            hourLine = new LineComponent(center, center, Context) { Pixel = '#'.White() };
            secondLine = new LineComponent(center, center, Context) { Pixel = 'o'.White() };
            minuteLine = new LineComponent(center, center, Context) { Pixel = '.'.White() };

            circle = new CircleComponent(center, Context.Bounds.Height / 2f, Context)
            {
                Filled = false
            };
            circle.Transform.CentralizePivot();
        }

        public override void Update()
        {
            var now = Context.Time.Now;
            hourLine.PointB = Circle.GetPoint(hourLine.PointA, 15, (now.Hour + now.Minute / 60f) * 30 - 90);
            minuteLine.PointB = Circle.GetPoint(minuteLine.PointA, 20, (now.Minute + now.Second / 60f) * 6 - 90);
            secondLine.PointB = Circle.GetPoint(secondLine.PointA, 25, (now.Second + now.Millisecond / 1000f) * 6 - 90);
	    }

        public override void Draw(IDrawContext drawContext)
        {
            drawContext.Canvas
                       .Draw(circle, false, Pixel.Default);

            drawContext.TextSystem
                       .Draw(0, 0, Context.Time.Now.ToString("HH:mm:ss"), "Default");
        }
    }
}
