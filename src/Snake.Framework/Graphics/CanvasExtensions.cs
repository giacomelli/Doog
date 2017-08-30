using System;
using Snake.Framework.Geometry;

namespace Snake.Framework.Graphics
{
    /// <summary>
    /// ICanvas extension methods.
    /// </summary>
    public static class CanvasExtensions
    {
        public static ICanvas Draw(this ICanvas canvas, Transform transform, char sprite)
        {
            canvas.Draw(transform.Position.X + transform.Pivot.X, transform.Position.Y + transform.Position.X, sprite);
         
            return canvas;
        }
     
        public static ICanvas Draw(this ICanvas canvas, Rectangle rectangle, bool filled = false, char sprite = '.')
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

            return canvas;
        }

        public static ICanvas Draw(this ICanvas canvas, ICircle circle, bool filled = false, char sprite = '.')
        {
            circle.Iterate(
                (x, y) =>
            {
                canvas.Draw(x, y, sprite);
            },
                filled ? 1 : circle.Radius
            );

            return canvas;
        }
    }
}
