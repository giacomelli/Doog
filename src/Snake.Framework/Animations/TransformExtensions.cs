using Snake.Framework.Geometry;

namespace Snake.Framework.Animations
{
    /// <summary>
    /// Transform extension methods.
    /// </summary>
    public static class TransformExtensions
    {
        /// <summary>
        /// Move the transfom between the from and to values using the duration and easing specified.
        /// </summary>
        /// <returns>The to.</returns>
        /// <param name="transform">Transform.</param>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        /// <param name="duration">Duration.</param>
        /// <param name="easing">Easing.</param>
        public static AnimationPipeline<Transform> MoveTo(this Transform transform, float x, float y, float duration, IEasing easing = null, string name = null)
        {
            name = name ?? "MoveFrom{0}To{1},{2}".With(transform.Position, x, y);
            var animation = new PositionAnimation(transform, name, new Point(x, y), duration);
            animation.Easing = easing;

            return AnimationPipeline<Transform>.Create(animation);
        }

		/// <summary>
		/// Move the transfom between the from and to values using the duration and easing specified.
		/// </summary>
		/// <returns>The to.</returns>
		/// <param name="transform">Transform.</param>
		/// <param name="point">The point.</param>
		/// <param name="duration">Duration.</param>
		/// <param name="easing">Easing.</param>
		public static AnimationPipeline<Transform> MoveTo(this Transform transform, Point point, float duration, IEasing easing = null, string name = null)
		{
            return transform.MoveTo(point.X, point.Y, duration, easing, name);
		}

		public static AnimationPipeline<Transform> MoveTo(this AnimationPipeline<Transform> pipeline, Point point, float duration, IEasing easing = null, string name = null)
		{
            pipeline.Join(pipeline.Owner.MoveTo(point.X, point.Y, duration, easing, name));
      
            return pipeline;
		}
    }
}
