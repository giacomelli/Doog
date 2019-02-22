namespace Doog.Samples
{
    public class BreakoutScene : SceneBase
    {
        private RectangleComponent paddle;
     
        public BreakoutScene(IWorldContext context)
            : base(context)
        {

        }

        public override void Initialize()
        {
            Context.RemoveAllComponents();
            var bottomCenter = Context.Bounds.BottomCenterPoint();
            paddle = new RectangleComponent(new Rectangle(0, 0, 10, 0), Context);
            paddle.Transform.Position = bottomCenter + Point.Up * 3;
            paddle.Transform.CentralizePivot();
        }

        public override void Update()
        {
            Context.InputSystem.Do(() =>
            {
                paddle.Transform.Position += Point.Right * 2.0f;
            }, Keys.D, Keys.L, Keys.RightArrow)
            .Do(() =>
            {
                paddle.Transform.Position += Point.Left * 2.0f;
            }, Keys.A, Keys.H, Keys.LeftArrow);
        }

        public override void Draw(IDrawContext drawContext)
        {
            drawContext.TextSystem
                   .Draw(1, 1, "Use [A-D]/[H-L]/[Left-Right] to move the paddle", "Default");
        }
    }
}
