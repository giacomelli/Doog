using System;
using Snake.Framework;
using Snake.Framework.Animations;
using Snake.Framework.Geometry;
using Snake.Framework.Graphics;

namespace Snake.Game.Scenes.Samples
{
    public class Sample8Scene : SceneBase
    {
        RectangleComponent interactiveRectangle;
        public Sample8Scene(IWorldContext context)
            : base(context)
        {
        }

        public override void Initialize()
        {
            Context.RemoveAllComponents();
            var bounds = Context.Bounds;
            var center = bounds.GetCenter();

            var rect = new Rectangle(center.X, center.Y, center.X + 20, center.Y + 20);            
            interactiveRectangle = new RectangleComponent(rect, Context);
            interactiveRectangle.Tag = "Interactive";
            interactiveRectangle.Filled = true;
            interactiveRectangle.Transform.CentralizePivot();

            interactiveRectangle.Transform
                .MoveTo(bounds.RightCenterPoint() - new Point(10, 0), 5f, Easing.InBounce)
                .MoveTo(bounds.LeftCenterPoint() + new Point(10, 0), 5f, Easing.InBounce)
                .PingPong();

            //interactiveRectangle.Transform
                //.ScaleTo(40, 20, 5, Easing.InBounce)
                //.PingPong();

            interactiveRectangle.Transform
                .RotateTo(360, 5, Easing.InBounce)
                               .PingPong();


            var rect2 = new RectangleComponent(10, 1, 10, Context);
            rect2.Filled = false;
            rect2.Transform
                 .RotateTo(360, 5, Easing.InOutElastic)
                 .PingPong();

			var rect3 = new RectangleComponent(140, 1, 10, Context);
            rect3.Filled = false;
			rect3.Transform
				 .RotateTo(-360, 5, Easing.InOutElastic)
				 .PingPong();

        }

        public override void Update()
        {
            if (Console.KeyAvailable)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.LeftArrow:
                        interactiveRectangle.Transform.Rotation -= 180f * Context.Time.SinceLastFrame;
                        break;

                    case ConsoleKey.RightArrow:
                        interactiveRectangle.Transform.Rotation += 180f * Context.Time.SinceLastFrame;
                        break;

                }
            }
        }

        public override void Draw(IDrawContext drawContext)
        {
            drawContext.TextSystem.DrawCenter("Rotation: {0}".With(interactiveRectangle.Transform.Rotation), "Default");
        }
    }
}
