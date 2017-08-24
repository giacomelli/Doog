using System;
using Snake.Framework;
using Snake.Framework.Animations;
using Snake.Framework.Geometry;
using Snake.Framework.Graphics;

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
                bounds.Iterate((x, y) =>
                {
                    if (bounds.IsBorder(x, y))
                    {
                        new SampleComponent(center.X, center.Y, Context)
                            .Transform
                            .Delay(i * 2)
                            .MoveTo(x, y, 5f, Easing.Linear)
                            .Loop();
                    }
                });
            }
        }

        public override void Draw(IDrawContext context)
        {
            Context.TextSystem.DrawCenter("Open your mind", "Default");
        }

    }
}
