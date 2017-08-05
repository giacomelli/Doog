using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Snake.Framework.Geometry;

namespace Snake.Framework.Graphics
{
    public static class ICanvasExtensions
    {
        public static void Draw(this ICanvas canvas, TransformComponent transform, char sprite)
        {
            canvas.Draw(transform.Position.X, transform.Position.Y, sprite);
        }
    }
}
