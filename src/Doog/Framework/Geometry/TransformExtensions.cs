namespace Doog
{
    /// <summary>
    /// Transform extensions methods.
    /// </summary>
    public static partial class TransformExtensions
    {
        private static readonly Point centralizedX = new Point(0.5f, 0);
        private static readonly Point centralizedY = new Point(0f, 0.5f);

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

        /// <summary>
        /// Centralizes the pivot in X coordinate.
        /// </summary>
        /// <returns>The transform.</returns>
        /// <param name="transform">The transform.</param>
        public static Transform CentralizePivotX(this Transform transform)
        {
            transform.Pivot = centralizedX;

            return transform;
        }

        /// <summary>
        /// Centralizes the pivot in Y coordinate.
        /// </summary>
        /// <returns>The transform.</returns>
        /// <param name="transform">The transform.</param>
        public static Transform CentralizePivotY(this Transform transform)
        {
            transform.Pivot = centralizedY;

            return transform;
        }
    }
}
