using System.Collections.Generic;

namespace Doog
{
    /// <summary>
    /// ICanvas extension methods.
    /// </summary>
    public static class CanvasExtensions
    {
        /// <summary>
        /// Draws the pixel using the transform position.
        /// </summary>
        /// <param name="canvas">The canvas.</param>
        /// <param name="transform">The transform.</param>
        /// <param name="pixel">The pixel.</param>
        /// <returns>The canvas.</returns>
        public static ICanvas Draw(this ICanvas canvas, Transform transform, Pixel pixel)
        {
            canvas.Draw(transform.Position.X, transform.Position.Y, pixel);
         
            return canvas;
        }

        /// <summary>
        /// Draws the pixel in the specified point.
        /// </summary>
        /// <param name="canvas">The canvas.</param>
        /// <param name="point">The point.</param>
        /// <param name="pixel">The pixel.</param>
        /// <returns>The canvas.</returns>
        public static ICanvas Draw(this ICanvas canvas, Point point, Pixel pixel)
		{
			canvas.Draw(point.X, point.Y, pixel);

			return canvas;
		}

        /// <summary>
        /// Draws the specified rectangle.
        /// </summary>
        /// <param name="canvas">The canvas.</param>
        /// <param name="rectangle">The rectangle.</param>
        /// <param name="filled">if set to <c>true</c> [filled].</param>
        /// <param name="pixel">The pixel.</param>
        /// <returns>The canvas.</returns>
        public static ICanvas Draw(this ICanvas canvas, Rectangle rectangle, bool filled, Pixel pixel)
        {
            rectangle.Iterate(filled,
            (x, y) =>
            {
                canvas.Draw(x, y, pixel);
            });

            return canvas;
        }

        /// <summary>
        /// Draws the specified circle.
        /// </summary>
        /// <param name="canvas">The canvas.</param>
        /// <param name="circle">The circle.</param>
        /// <param name="filled">if set to <c>true</c> [filled].</param>
        /// <param name="pixel">The pixel.</param>
        /// <returns>The canvas.</returns>
        public static ICanvas Draw(this ICanvas canvas, ICircle circle, bool filled, Pixel pixel)
        {
            circle.Iterate(
                (x, y) =>
            {
                canvas.Draw(x, y, pixel);
            },
                filled ? 1 : circle.Radius
            );

            return canvas;
        }

        /// <summary>
        /// Draws the specified line.
        /// </summary>
        /// <param name="canvas">The canvas.</param>
        /// <param name="line">The line.</param>
        /// <param name="pixel">The pixel.</param>
        /// <returns>The canvas.</returns>
        public static ICanvas Draw(this ICanvas canvas, ILine line, Pixel pixel)
		{
			line.Iterate(
				(x, y) =>
				{
					canvas.Draw(x, y, pixel);
				});

			return canvas;
		}

        /// <summary>
        /// Draws the specified lines.
        /// </summary>
        /// <typeparam name="TLine">The type of the line.</typeparam>
        /// <param name="canvas">The canvas.</param>
        /// <param name="lines">The lines.</param>
        /// <param name="pixel">The pixel.</param>
        /// <returns>The canvas.</returns>
        public static ICanvas Draw<TLine>(this ICanvas canvas, IEnumerable<TLine> lines, Pixel pixel)
            where TLine : ILine
		{

            foreach(var line in lines)
            {
                canvas.Draw(line, pixel);
            }

			return canvas;
		}
    }
}
