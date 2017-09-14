using System;
using System.Collections.Generic;
using Snake.Framework;
using Snake.Framework.Geometry;
using Snake.Framework.Graphics;

namespace Snake.Game.Scenes.Samples
{
    public class SampleComponent : RectangleComponent, IDrawable
    {
        public SampleComponent(float x, float y, IWorldContext ctx)
        : base(new Point(x, y), ctx)
        {
        }

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
    }
}
