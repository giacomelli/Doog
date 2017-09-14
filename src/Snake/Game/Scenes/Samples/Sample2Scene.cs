using System;
using Snake.Framework;
using Snake.Framework.Animations;
using Snake.Framework.Geometry;
using Snake.Framework.Graphics;

namespace Snake.Game.Scenes.Samples
{
    public class Sample2Scene : SceneBase
    {
        Line[] lines;

		public Sample2Scene(IWorldContext context)
            : base(context)
        {
        }

        public override void Initialize()
        {
            Context.RemoveAllComponents();

            var center = Context.Bounds.GetCenter();
            var scale = new Point(40, 20);
            var rightBottom = Context.Bounds.RightBottomPoint() - scale;
            var rightTop = Context.Bounds.RightTopPoint() + new Point(scale.X * -1, 0);
            var leftBottom = Context.Bounds.LeftBottomPoint() + new Point(0, scale.Y * -1);
            var wall = Wall.Create(center.X, center.Y, 1, 1, Context);
            wall.Filled = true;

            wall.Transform
                .CentralizePivot()
                .ScaleTo(scale, 1, Easing.Linear)
                .MoveTo(new Point(1, 1), 1, Easing.Linear)
				.MoveTo(rightBottom, 1, Easing.Linear)
				.ScaleTo(Point.One, 1, Easing.Linear)
                .ScaleTo(scale, 1, Easing.Linear)
                .MoveTo(center, 1, Easing.Linear)
                .MoveTo(rightTop, 1, Easing.Linear)
                .MoveTo(leftBottom, 1, Easing.Linear)
                .PingPong();


            lines = new Line[20];

            for (int i = 0; i < lines.Length; i++)
            {
                lines[i] = new Line(new Point(i * 10, i % 2 == 0 ? 10 : 20), new Point((i + 1) * 10, i % 2 != 0 ? 10 : 20));
            }
        }

        public override void Draw(IDrawContext drawContext)
        {
            drawContext.Canvas.Draw(lines);
        }

    }
}
