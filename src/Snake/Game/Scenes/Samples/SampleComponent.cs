using System;
using System.Collections.Generic;
using Snake.Framework;
using Snake.Framework.Geometry;
using Snake.Framework.Graphics;

namespace Snake.Game.Scenes.Samples
{
    public class SampleComponent : ComponentBase, IDrawable
    {
        public SampleComponent(float x, float y, IWorldContext ctx)
        : base(ctx)
        {
            Transform = new Transform(x, y, ctx);
            Sprite = '#';
        }

        public Transform Transform { get; set; }
        public char Sprite { get; set; }

        public override bool Enabled
        {
            get
            {
                return Transform.Enabled;
            }
            set
            {
                base.Enabled = value;
                Transform.Enabled = value;
            }
        }

        public void Draw(IDrawContext context)
        {
            context.Canvas.Draw(Transform.BoundingBox, true, Sprite);
        }
    }
}
