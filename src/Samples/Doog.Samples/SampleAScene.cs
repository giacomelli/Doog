namespace Doog.Samples
{
    public class SampleAScene : SceneBase
    {
        RectangleComponent _panel;

        public SampleAScene(IWorldContext context)
            : base(context)
        {
        }

        public override void Initialize()
        {
            Context.RemoveAllComponents();
            var bounds = Context.Bounds;
            var center = bounds.GetCenter();
            _panel = new RectangleComponent(new Rectangle(center.X, center.Y, 20, 20), Context);
            //_panel.Transform.CentralizePivot();

            var rect1 = new RectangleComponent(10, 10, 1, Context)
            {
                Filled = true,
                Pixel = Pixel.Green
            };
            //rect1.Transform.CentralizePivotX();


            //var rect2 = new RectangleComponent(2, 0, 1, Context)
            //{
            //    Filled = true,
            //    Pixel = Pixel.Red
            //};
            ////rect2.Transform.CentralizePivotX();

            //var rect3 = new RectangleComponent(4, 0, 1, Context)
            //{
            //    Filled = true,
            //    Pixel = Pixel.Blue
            //};
            ////rect3.Transform.CentralizePivotX();

            _panel.AddChild(rect1);
            //_panel.AddChild(rect2);
            //_panel.AddChild(rect3);

        }

        public override void Update()
        {
            Context.InputSystem
                   .IsKeyDown(Keys.A, () => _panel.Transform.Rotation -= 180f * Context.Time.SinceLastFrame)
                   .IsKeyDown(Keys.D, () => _panel.Transform.Rotation += 180f * Context.Time.SinceLastFrame)
                   .IsKeyDown(Keys.LeftArrow, () => _panel.Transform.Position += Point.Left)
                   .IsKeyDown(Keys.UpArrow, () => _panel.Transform.Position += Point.Up)
                   .IsKeyDown(Keys.RightArrow, () => _panel.Transform.Position += Point.Right)
                   .IsKeyDown(Keys.DownArrow, () => _panel.Transform.Position += Point.Down);
        }
    }
}
