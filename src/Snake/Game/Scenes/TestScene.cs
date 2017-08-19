using System;
using Snake.Framework;
using Snake.Framework.Animations;
using Snake.Framework.Geometry;
using Snake.Framework.Graphics;

namespace Snake.Game.Scenes
{
    public class TestScene : SceneBase
    {
        private Rectangle moveToSampleArea = new Rectangle(1, 10, 11, 21);
        private float numberSample1;
        private float numberSample2;

        public TestScene(IWorldContext context)
            : base(context)
        {
        }

        public override void Initialize()
        {
            Context.RemoveAllComponents();

            var moveToFood1 = new Food(Context);
            moveToFood1.Transform.Position = moveToSampleArea.LeftTopPoint();
            moveToFood1.Transform
                       .MoveTo(moveToSampleArea.RightBottomPoint(), 2, Easing.InBack, "anim1")
                       .Delay(1)
                       .MoveTo(moveToSampleArea.RightTopPoint(), 2, Easing.Linear, "anim2")
                       //.Loop();
                       .PingPong();
            //.Once();

            var moveToFood2 = new Food(Context);
            moveToFood2.Transform.Position = moveToSampleArea.RightBottomPoint();
            moveToFood2.Transform
                       .MoveTo(moveToSampleArea.LeftTopPoint(), 2, Easing.InBack)
                       .Delay(1)
                       .MoveTo(moveToSampleArea.LeftBottomPoint(), 2, Easing.Linear)
                       .PingPong();

            var blinkFood = new Food(Context);
            blinkFood.Transform.Position = new Point(30, 11);
            blinkFood.Enable(1f, Easing.Linear)
            .Loop();

            blinkFood.To(0, 100, 10, Easing.Linear, (v) => numberSample1 = v)
                     .Loop();

            blinkFood
                    .To(0, 10, 10, Easing.Linear, (v) => numberSample2= v)
                    .Delay(5)
				    .To(10, 30, 10, Easing.Linear, (v) => numberSample2 = v)
					.Delay(5)
				    .To(30, 100, 10, Easing.Linear, (v) => numberSample2 = v)
					.Delay(5)
                    .PingPong();

        }

        public override void Update()
        {
            Context.TextSystem.DrawCenter(0, -10, numberSample1.ToString("N0"));
			Context.TextSystem.DrawCenter(0, 0, numberSample2.ToString("N0"));
        }

        public override void Draw(IDrawContext context)
        {
            context.Canvas.DrawRectangle(moveToSampleArea);
        }
    }
}
