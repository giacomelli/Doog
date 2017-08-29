using System;
using Snake.Framework;
using Snake.Framework.Animations;
using Snake.Framework.Geometry;
using Snake.Framework.Graphics;

namespace Snake.Game.Scenes.Samples
{
    public class Sample1Scene : SceneBase
    {
        private Rectangle moveToSampleArea = new Rectangle(1, 10, 11, 21);
        private float numberSample1;
        private float numberSample2;
        private IAnimationPipelineController controller1;
        private IAnimationPipelineController controller2;

        public Sample1Scene(IWorldContext context)
            : base(context)
        {
        }

        public override void Initialize()
        {
            Context.RemoveAllComponents();
            var bounds = Context.Bounds;

            var moveToFood1 = new Food(Context);
            moveToFood1.Transform.Position = moveToSampleArea.LeftTopPoint();
            moveToFood1.Transform
                       .MoveTo(moveToSampleArea.RightBottomPoint(), 2, Easing.InBack)
                       .Delay(1)
                       .MoveTo(moveToSampleArea.RightTopPoint(), 2, Easing.Linear)
                       .PingPong();

            var moveToFood2 = new Food(Context);
            moveToFood2.Transform.Position = moveToSampleArea.RightBottomPoint();
            moveToFood2.Transform
                       .MoveTo(moveToSampleArea.LeftTopPoint(), 2, Easing.InBack)
                       .Delay(1)
                       .MoveTo(moveToSampleArea.LeftBottomPoint(), 2, Easing.Linear)
                       .PingPong();

            var blinkFood = new Food(Context);
            blinkFood.Transform.Position = new Point(30, 11);
            blinkFood
                .Enable(1f, Easing.Linear)
                .Loop();

            controller1 = blinkFood
                .To(0, 100, 19, Easing.Linear, v => numberSample1 = v)
                .Loop();


            controller2 = blinkFood
                    .To(0, 10, 10, Easing.Linear, v => numberSample2 = v)
                    .Delay(5)
                    .To(10, 30, 10, Easing.Linear, v => numberSample2 = v)
                    .Delay(5)
                    .To(30, 100, 10, Easing.Linear, v => numberSample2 = v)
                    .Delay(5)
                    .PingPong();


            // Once blink
            for (var i = 0; i < 100; i++)
            {
                var b = new Food(Context);
                b.Transform.Position = new Point(31 + i, 11);
                b
                    .Delay(i * 0.05f)
                    .Enable(1f, Easing.Linear)
                    .Enable(0.5f, Easing.Linear)
                    .Enable(0.5f, Easing.Linear)
                       .Once();
            }

            // Ping-pong move
            var length = 100;
            var speed = 0.1f;
            var maxTime = (length - 1) * speed;

            for (var i = 0; i < length; i++)
            {
                var b = new Food(Context);
                b.Transform.Position = new Point(31 + i, 13);
                b
                    .Disable(i * speed, Easing.Linear).OnlyForward()
                    .Delay(maxTime - (i * speed)).OnlyForward()

                    .Delay(maxTime - ((length - 1 - i) * speed)).OnlyBackward()
                    .Enable(((length - 1) - i) * speed, Easing.Linear).OnlyBackward()

                    .PingPong();
            }

            // ScaleTo, MoveTo and PingPong
            new RectangleComponent(140, 1, Context).Transform
                .ScaleTo(new Point(20, 10), 1, Easing.InExpo)
                .MoveTo(new Point(140, bounds.Bottom - 10), 2, Easing.InBounce)
                .PingPong();

            // Circle
            var center = Context.Bounds.GetCenter();
            var circle = new CircleComponent(new Point(20, 40), 1, Context)
            {
                Filled = false
            };

            circle.Transform
                .Do(() => circle.Filled = false).OnlyForward()
                .ScaleTo(30, 3, Easing.InOutQuint)
                .Do(() => circle.Filled = true).OnlyBackward()
                .PingPong();
        }

        public override void Update()
        {
            if (Console.KeyAvailable)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.D1:
                        ToogleAnimation(controller1);
                        break;

                    case ConsoleKey.D2:
                        ToogleAnimation(controller2);
                        break;

                    case ConsoleKey.D3:
                        ToogleAnimation(controller1);
                        ToogleAnimation(controller2);
                        break;

                    case ConsoleKey.D0:
                        controller1.Destroy();
                        controller2.Destroy();
                        break;

                    case ConsoleKey.D7:
                        AnimationPipelineController.PauseAll();
                        break;

                    case ConsoleKey.D8:
                        AnimationPipelineController.ResumeAll();
                        break;

                    case ConsoleKey.D9:
                        AnimationPipelineController.DestroyAll();
                        break;
                }
            }
        }

        private void ToogleAnimation(IAnimationPipelineController controller)
        {
            if (controller.State == AnimationState.Playing)
            {
                controller.Pause();
            }
            else
            {
                controller.Resume();
            }
        }

        public override void Draw(IDrawContext context)
        {
            context.Canvas
                   .Draw(moveToSampleArea);

            Context.TextSystem
                .DrawCenter(0, -10, numberSample1.ToString("N0"))
                .DrawCenter(0, 0, numberSample2.ToString("N0"));

        }
    }
}
