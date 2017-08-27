using System;
using Snake.Framework;
using Snake.Framework.Animations;
using Snake.Framework.Geometry;
using Snake.Framework.Graphics;

namespace Snake.Game.Scenes.Samples
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
			ball = new SampleComponent(0, 0, Context);

            bounds = Context.Bounds + new Rectangle(10, 10, -5, -5);
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
            if(Console.KeyAvailable)
            {
                var key = Console.ReadKey(true).Key;

                switch(key)
                {
                    case ConsoleKey.UpArrow:
                        currentEasingIndex--;

                        if(currentEasingIndex < 0) 
                        {
                            currentEasingIndex = 0;
                        }

                        StartAnimation();
                        break;

					case ConsoleKey.DownArrow:
                        currentEasingIndex++;

                        if(currentEasingIndex >= Easing.All.Length)
                        {
                            currentEasingIndex = Easing.All.Length - 1;
                        }
                        StartAnimation();

						break;
                }
            }
        }

        public override void Draw(IDrawContext context)
        {
			Context.TextSystem
                   .DrawCenterX(10, Easing.All[currentEasingIndex].GetType().Name.Replace("Easing", ""))
                   .Draw(1, 1, "Use down and up arrows to navigate between the {0} easings available".With(Easing.All.Length), "Default");
        }

        private void StartAnimation()
        {
            AnimationPipelineController.DestroyAll();
            var easing = Easing.All[currentEasingIndex];

			// Ball.
			var left = bounds.LeftCenterPoint();
            var right = bounds.RightCenterPoint() - new Point(20, 0); ;
            ball.Transform.Position = left;
            ball.Transform.Scale = Point.One;

            var duration = 2f;

			ball.Transform
				.MoveTo(right, duration, easing)
				.PingPong();

			ball.Transform
				.ScaleTo(20, 10, duration, easing)
				.PingPong();
            
     		for (int i = 0; i < bar.Length; i++)
			{
                var time = (float)i / (float)bar.Length;
                var y = easing.Calculate(time);

                bar[i].Transform.Position = new Point(i + bounds.Left, bounds.Bottom);
                bar[i].Transform
                      .MoveTo(new Point(i + bounds.Left, bounds.Top +  (1f - y) * (bounds.Height)), duration, easing)
                      .Once();
			}
        }
    }
}
