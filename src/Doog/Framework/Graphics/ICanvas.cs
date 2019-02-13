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
        /// Draw the sprite in the specified x and y coordinates.
        /// </summary>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        /// <param name="sprite">The sprite.</param>
        void Draw(float x, float y, char sprite);
    }
}
