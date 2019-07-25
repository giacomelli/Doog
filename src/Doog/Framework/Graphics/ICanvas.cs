namespace Doog
{
    /// <summary>
    /// Defines an interface for a canvas.
    /// </summary>
    public interface ICanvas
    {
        /// <summary>
        /// Gets the bounds.
        /// </summary>
        Rectangle Bounds { get; }

        /// <summary>
        /// Draw the pixel in the specified x and y coordinates.
        /// </summary>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        /// <param name="pixel">The pixel.</param>
        void Draw(float x, float y, Pixel pixel);
    }
}
