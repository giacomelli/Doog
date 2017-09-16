using System;
using Doog.Framework;
using Doog.Framework.Animations;
using Doog.Framework.Geometry;
using Doog.Framework.Graphics;

namespace Snake.Game.Scenes.Samples
{
    public class Sample3Scene : SceneBase
    {
        public Sample3Scene(IWorldContext context)
            : base(context)
        {
        }

        public override void Initialize()
        {
            Context.RemoveAllComponents();

            var bounds = Context.Bounds;
            var center = bounds.GetCenter();
            var rectsCount = 5;

            for (int i = 0; i < rectsCount; i++)
            {
                new RectangleComponent(center, Context)
                {
                    Filled = false
                }
                    .Transform
                    .CentralizePivot()
                    .Delay(i * 2)
                    .Enable()
                    .ScaleTo(bounds.Width, bounds.Height, 5f, Easing.InBounce)
                    .Disable()
                    .Loop();

                new CircleComponent(center, 0.1f, Context)
                {
                    Filled = false
                }
                   .Transform
                   .CentralizePivot()
                   .Delay(i * 2)
                   .Enable()
                   .ScaleTo(bounds.Width, bounds.Height, 5f, Easing.InBounce)
                    .Disable()
                   .Loop();
            }
        }

        public override void Draw(IDrawContext drawContext)
        {
            drawContext.TextSystem.DrawCenter("Open your mind", "Default");
        }

    }
}
