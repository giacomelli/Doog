namespace Snake.Framework.Geometry
{
    /// <summary>
    /// Transform extensions methods.
    /// </summary>
    public static class TransformExtensions
    {
        /// <summary>
        /// Centralizes the pivot.
        /// </summary>
        /// <returns>The pivot.</returns>
        /// <param name="transform">Transform.</param>
        public static Transform CentralizePivot(this Transform transform)
        {
            transform.Pivot = Point.HalfOne;

            return transform;
        }
    }
}
