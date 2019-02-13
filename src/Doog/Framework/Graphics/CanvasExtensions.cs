using System.Collections.Generic;

namespace Doog
{
    /// <summary>
    /// ICanvas extension methods.
    /// </summary>
    public static class CanvasExtensions
    {
        /// <summary>
        /// Draws the sprite using the transform position.
        /// </summary>
        /// <param name="canvas">The canvas.</param>
        /// <param name="transform">The transform.</param>
        /// <param name="sprite">The sprite.</param>
        /// <returns>The canvas.</returns>
        public static ICanvas Draw(this ICanvas canvas, Transform transform, char sprite)
        {
            canvas.Draw(transform.Position.X, transform.Position.Y, sprite);
         
            return canvas;
        }

        /// <summary>
        /// Draws the sprite in the specified point.
        /// </summary>
        /// <param name="canvas">The canvas.</param>
        /// <param name="point">The point.</param>
        /// <param name="sprite">The sprite.</param>
        /// <returns>The canvas.</returns>
        public static ICanvas Draw(this ICanvas canvas, Point point, char sprite)
		{
			canvas.Draw(point.X, point.Y, sprite);

			return canvas;
		}

        /// <summary>
        /// Draws the specified rectangle.
        /// </summary>
        /// <param name="canvas">The canvas.</param>
        /// <param name="rectangle">The rectangle.</param>
        /// <param name="filled">if set to <c>true</c> [filled].</param>
        /// <param name="sprite">The sprite.</param>
        /// <returns>The canvas.</returns>
        public static ICanvas Draw(this ICanvas canvas, Rectangle rectangle, bool filled = false, char sprite = '.')
        {
            rectangle.Iterate(filled,
            (x, y) =>
            {
                canvas.Draw(x, y, sprite);
            });

            return canvas;
        }

        /// <summary>
        /// Draws the specified circle.
        /// </summary>
        /// <param name="canvas">The canvas.</param>
        /// <param name="circle">The circle.</param>
        /// <param name="filled">if set to <c>true</c> [filled].</param>
        /// <param name="sprite">The sprite.</param>
        /// <returns>The canvas.</returns>
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

        /// <summary>
        /// Draws the specified line.
        /// </summary>
        /// <param name="canvas">The canvas.</param>
        /// <param name="line">The line.</param>
        /// <param name="sprite">The sprite.</param>
        /// <returns>The canvas.</returns>
        public static ICanvas Draw(this ICanvas canvas, ILine line, char sprite = '.')
		{
			line.Iterate(
				(x, y) =>
				{
					canvas.Draw(x, y, sprite);
				});

			return canvas;
		}

        /// <summary>
        /// Draws the specified lines.
        /// </summary>
        /// <typeparam name="TLine">The type of the line.</typeparam>
        /// <param name="canvas">The canvas.</param>
        /// <param name="lines">The lines.</param>
        /// <param name="sprite">The sprite.</param>
        /// <returns>The canvas.</returns>
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
