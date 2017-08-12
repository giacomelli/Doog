namespace Snake.Framework.Geometry
{
    /// <summary>
    /// Point extension methods.
    /// </summary>
    public static class PointExtensions
    {
        /// <summary>
        /// Truncate the specified Point.
        /// </summary>
        /// <remarks>
        /// Values between 0..1 will be truncated to 0.
        /// Values between 1..2 will be truncated to 1.
        /// and so on.
        /// </remarks>
        /// <returns>The truncated values.</returns>
        /// <param name="value">Value.</param>
        public static Point Truncate(this Point value)
        {
            return new Point((int)value.X, (int)value.Y);
        }
    }
}