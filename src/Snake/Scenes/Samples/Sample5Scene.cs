using Doog.Framework;

namespace Snake.Scenes.Samples
{
    public class Sample5Scene : SceneBase
    {
        private int currentEasingIndex;
        private SampleComponent ball;
        private SampleComponent[] bar;
        private Rectangle bounds;

        public Sample5Scene(IWorldContext context)
            : base(context)
        {

        }

        public override void Initialize()
        {
            Context.RemoveAllComponents();
            ball = new SampleComponent(0, 0, Context) { Filled = false };

            var b = Context.Bounds;
            bounds = new Rectangle(b.Left + 10, b.Top + 10, b.Width - 10, b.Height - 15);
            bar = new SampleComponent[(int)bounds.Width];

            for (int i = 0; i < bar.Length; i++)
            {
                bar[i] = new SampleComponent(0, 0, Context);
                bar[i].Sprite = '.';
            }

            StartAnimation();
        }

        public override void Update()
        {
            Context.InputSystem
                   .IsKeyDown(Keys.UpArrow, () =>
                   {
                       currentEasingIndex--;

                       if (currentEasingIndex < 0)
                       {
                           currentEasingIndex = 0;
                       }

                       StartAnimation();
                   })
                   .IsKeyDown(Keys.DownArrow, () =>
                   {
					   currentEasingIndex++;

					   if (currentEasingIndex >= Easing.All.Length)
					   {
						   currentEasingIndex = Easing.All.Length - 1;
					   }
					   StartAnimation();
                   });
        }

        public override void Draw(IDrawContext drawContext)
        {
            drawContext.TextSystem
                   .DrawCenterX(10, Easing.All[currentEasingIndex].GetType().Name.Replace("Easing", ""))
                   .Draw(1, 1, "Use down and up arrows to navigate between the {0} easings available".With(Easing.All.Length), "Default");
        }

        private void StartAnimation()
        {
            AnimationPipelineController.DestroyAll();
            var easing = Easing.All[currentEasingIndex];

            // Ball.
            var left = bounds.LeftCenterPoint();
            var right = bounds.RightCenterPoint() - new Point(20, 0);
            ball.Transform.CentralizePivot();
            ball.Transform.Position = left;
            ball.Transform.Scale = Point.One;
            ball.Transform.Rotation = 0f;

            var duration = 4f;

            ball.Transform
                .MoveTo(right, duration, easing)
                .PingPong();

            ball.Transform
                .ScaleTo(20, 10, duration, easing)
                .PingPong();

            ball.Transform
                .RotateTo(360, duration, easing)
                .PingPong();

            for (int i = 0; i < bar.Length; i++)
            {
                var time = (float)i / (float)bar.Length;
                var y = easing.Calculate(time);

                bar[i].Transform.Position = new Point(i + bounds.Left, bounds.Bottom);
                bar[i].Transform
                      .MoveTo(new Point(i + bounds.Left, bounds.Top + (1f - y) * (bounds.Height)), duration, easing)
                      .Once();
            }
        }
    }
}
