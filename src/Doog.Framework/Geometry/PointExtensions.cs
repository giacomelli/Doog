using System;

namespace Doog.Framework.Geometry
{
    /// <summary>
    /// Point extension methods.
    /// </summary>
    public static class PointExtensions
    {
        /// <summary>
        /// Ruound the specified Point.
        /// </summary>
        /// <returns>The rounded point.</returns>
        /// <param name="value">Value.</param>
        public static Point Round(this Point value)
        {
            return new Point(
                (int)Math.Round(value.X, 0), 
                (int)Math.Round(value.Y, 0));
        }
    }
}