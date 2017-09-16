using System;
using System.Collections.Generic;
using Doog.Framework;

namespace Doog.Framework
{
    /// <summary>
    /// ICanvas extension methods.
    /// </summary>
    public static class CanvasExtensions
    {
        public static ICanvas Draw(this ICanvas canvas, Transform transform, char sprite)
        {
            canvas.Draw(transform.Position.X, transform.Position.Y, sprite);
         
            return canvas;
        }

		public static ICanvas Draw(this ICanvas canvas, Point point, char sprite)
		{
			canvas.Draw(point.X, point.Y, sprite);

			return canvas;
		}
     
        public static ICanvas Draw(this ICanvas canvas, Rectangle rectangle, bool filled = false, char sprite = '.')
        {
            rectangle.Iterate(filled,
            (x, y) =>
            {
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

		public static ICanvas Draw(this ICanvas canvas, ILine line, char sprite = '.')
		{
			line.Iterate(
				(x, y) =>
				{
					canvas.Draw(x, y, sprite);
				});

			return canvas;
		}

		public static ICanvas Draw<TLine>(this ICanvas canvas, IEnumerable<TLine> lines, char sprite = '.')
            where TLine : ILine
		{

            foreach(var line in lines)
            {
                canvas.Draw(line, sprite);
            }

			return canvas;
		}
    }
}
