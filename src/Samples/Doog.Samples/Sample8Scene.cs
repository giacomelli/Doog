using Doog;

namespace Doog.Samples
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

            var rect = new Rectangle(center.X, center.Y, 20, 20);
            interactiveRectangle = new RectangleComponent(rect, Context)
            {
                Tag = "Interactive",
                Filled = true,
                Pixel = Pixel.Green()
            };
            interactiveRectangle.Transform.CentralizePivot();

            var animCtrl = interactiveRectangle.Transform
                .MoveTo(bounds.RightCenterPoint() - new Point(10, 0), 5f, Easing.InBounce)
                .MoveTo(bounds.LeftCenterPoint() + new Point(10, 0), 5f, Easing.InBounce)
                .PingPong();
        
            interactiveRectangle.Transform
                .RotateTo(360, 5, Easing.InBounce)
                .PingPong();


            var rect2 = new RectangleComponent(10, 1, 10, Context)
            {
                Filled = false,
                Pixel = Pixel.Red()
            };
            rect2.Transform
                 .RotateTo(360, 5, Easing.InOutElastic)
                 .PingPong();

            var rect3 = new RectangleComponent(140, 1, 10, Context)
            {
                Filled = false,
                Pixel = Pixel.Blue()
            };
            rect3.Transform
                 .RotateTo(-360, 5, Easing.InOutElastic)
                 .PingPong();
   
        }

        public override void Update()
        {
            Context.InputSystem
                   .IsKeyDown(Keys.P, AnimationPipelineController.PauseAll)
                   .IsKeyDown(Keys.R, AnimationPipelineController.ResumeAll)
                   .IsKeyDown(Keys.LeftArrow, () => interactiveRectangle.Transform.Rotation -= 180f * Context.Time.SinceLastFrame)
                   .IsKeyDown(Keys.RightArrow, () => interactiveRectangle.Transform.Rotation += 180f * Context.Time.SinceLastFrame);
        }

        public override void Draw(IDrawContext drawContext)
        {
            drawContext.TextSystem.DrawCenter($"Rotation: {interactiveRectangle.Transform.Rotation}", "Default");
        }
    }
}
