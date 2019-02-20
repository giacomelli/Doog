using Doog;

namespace Doog.Samples
{
    public class Sample8Scene : SceneBase
    {
        RectangleComponent interactiveRectangle;
        VirtualGraphicSystem _virtualGfx;
        World _subWorld;
        
        public Sample8Scene(IWorldContext context)
            : base(context)
        {
        }

        public override void Initialize()
        {
            Context.RemoveAllComponents();

            _virtualGfx = new VirtualGraphicSystem(new Rectangle(0, 0, Context.Bounds.Width - 10, Context.Bounds.Height - 10), Context);
            var bounds = _virtualGfx.Bounds;
            var center = bounds.GetCenter();

            _subWorld = new World();
            _subWorld.Initialize(_virtualGfx, Context.PhysicSystem, Context.TextSystem, Context.InputSystem, Context.Exit);
            Context.AddSubWorld(_subWorld);

            //_virtualGfx.Transform
            //    .MoveTo(bounds.RightTopPoint() - new Point(_virtualGfx.Bounds.Width / 2, 0), 10f)
            //    .MoveTo(bounds.LeftTopPoint() + new Point(_virtualGfx.Bounds.Width / 2, 0), 10f)
            //    .PingPong();          


            var rect = new Rectangle(center.X, center.Y, 20, 20);
            interactiveRectangle = new RectangleComponent(rect, _subWorld)
            {
                Tag = "Interactive",
                Filled = true,
                Pixel = Pixel.Green
            };
            interactiveRectangle.Transform.CentralizePivot();

            var animCtrl = interactiveRectangle.Transform
                .MoveTo(bounds.RightCenterPoint() - new Point(10, 0), 5f, Easing.InBounce)
                .MoveTo(bounds.LeftCenterPoint() + new Point(10, 0), 5f, Easing.InBounce)
                .PingPong();
        
            interactiveRectangle.Transform
                .RotateTo(360, 5, Easing.InBounce)
                .PingPong();


            var rect2 = new RectangleComponent(10, 1, 10, _subWorld)
            {
                Filled = false,
                Pixel = Pixel.Red
            };
            rect2.Transform
                 .RotateTo(360, 5, Easing.InOutElastic)
                 .PingPong();

            var rect3 = new RectangleComponent(140, 1, 10, _subWorld)
            {
                Filled = false,
                Pixel = Pixel.Blue
            };
            rect3.Transform
                 .RotateTo(-360, 5, Easing.InOutElastic)
                 .PingPong();
   
        }

        public override void Update()
        {
            //Context.InputSystem
            //       .IsKeyDown(Keys.P, AnimationPipelineController.PauseAll)
            //       .IsKeyDown(Keys.R, AnimationPipelineController.ResumeAll)
            //       .IsKeyDown(Keys.LeftArrow, () => interactiveRectangle.Transform.Rotation -= 180f * Context.Time.SinceLastFrame)
            //       .IsKeyDown(Keys.RightArrow, () => interactiveRectangle.Transform.Rotation += 180f * Context.Time.SinceLastFrame);

            Context.InputSystem
                .IsKeyDown(Keys.LeftArrow, () => _virtualGfx.Transform.Position += Point.Left)
                .IsKeyDown(Keys.UpArrow, () => _virtualGfx.Transform.Position += Point.Up)
                .IsKeyDown(Keys.RightArrow, () => _virtualGfx.Transform.Position += Point.Right)
                .IsKeyDown(Keys.DownArrow, () => _virtualGfx.Transform.Position += Point.Down);
        }

        public override void Draw(IDrawContext drawContext)
        {
            drawContext.TextSystem.DrawCenter($"Rotation: {interactiveRectangle.Transform.Rotation}", "Default");
        }
    }
}
