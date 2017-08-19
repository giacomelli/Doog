using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Snake.Framework.Geometry;

namespace Snake.Framework.Graphics
{
    /// <summary>
    /// ICanvas extension methods.
    /// </summary>
    public static class CanvasExtensions
    {
        public static void Draw(this ICanvas canvas, Transform transform, char sprite)
        {
            canvas.Draw(transform.Position.X, transform.Position.Y, sprite);
        }

        public static void DrawRectangle(this ICanvas canvas, Rectangle rectangle, bool filled = false, char sprite = '.')
        {
            rectangle.Iterate(
                (x, y) =>
                {
                    if (!filled && !rectangle.IsXBorder(x) && !rectangle.IsYBorder(y))
                    {
                        return;
                    }

                    canvas.Draw(x, y, sprite);
                });
        }
    }
}
