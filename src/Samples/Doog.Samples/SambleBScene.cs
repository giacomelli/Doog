﻿namespace Doog.Samples
{
    public class SampleBScene : SceneBase
    {
        RectangleComponent _rect;

        public SampleBScene(IWorldContext context)
            : base(context)
        {
        }

        public override void Initialize()
        {
            Context.RemoveAllComponents();
            var bounds = Context.Bounds;
            var center = bounds.GetCenter();
            _rect = new RectangleComponent(new Rectangle(center.X, center.Y, 0, 0), Context);
            _rect.Transform.CentralizePivot();
        }

        public override void Update()
        {
            Context.InputSystem
                   .IsKeyDown(Keys.LeftArrow, () => _rect.Transform.Scale += Point.Left)
                   .IsKeyDown(Keys.UpArrow, () => _rect.Transform.Scale += Point.Down)
                   .IsKeyDown(Keys.RightArrow, () => _rect.Transform.Scale += Point.Right)
                   .IsKeyDown(Keys.DownArrow, () => _rect.Transform.Scale += Point.Up)
                   .IsKeyDown(Keys.A, () => _rect.Transform.Position += Point.Left)
                   .IsKeyDown(Keys.W, () => _rect.Transform.Position += Point.Down)
                   .IsKeyDown(Keys.D, () => _rect.Transform.Position += Point.Right)
                   .IsKeyDown(Keys.S, () => _rect.Transform.Position += Point.Up);
        }

        public override void Draw(IDrawContext drawContext)
        {
            drawContext.TextSystem.Draw(1, 1, $"x: {_rect.Transform.Position.X}, y: {_rect.Transform.Position.Y}, width:{_rect.Transform.Scale.X}, height:{_rect.Transform.Scale.Y}", fontName:"Default");

            base.Draw(drawContext);
        }
    }
}
