namespace Doog
{
    /// <summary>
    /// Defines an interface for a circle.
    /// </summary>
    public interface ICircle
    {
        /// <summary>
        /// Gets the most left x coordinate.
        /// </summary>
        float Left { get; }

        /// <summary>
        /// Gets the most top y coordinate.
        /// </summary>
        float Top { get; }

        /// <summary>
        /// Gets the most right x coordinate.
        /// </summary>
        float Right { get; }

        /// <summary>
        /// Gets the most bottom y coordinate.
        /// </summary>
        float Bottom { get; }

        /// <summary>
        /// Gets the radius.
        /// </summary>
        float Radius { get; }

        /// <summary>
        /// Gets the center point.
        /// </summary>
        /// <returns>The point.</returns>
		Point GetCenter();
    }
}
