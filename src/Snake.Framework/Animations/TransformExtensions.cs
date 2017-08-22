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
        public static IAnimationPipeline<Transform> MoveTo(this Transform transform, float x, float y, float duration, IEasing easing = null, string name = null)
        {
            return AnimationPipeline<Transform>.Create(CreateMoveToAnimation(transform, x, y, duration, easing, name));
        }

		/// <summary>
		/// Move the transfom between the from and to values using the duration and easing specified.
		/// </summary>
		/// <returns>The to.</returns>
		/// <param name="transform">Transform.</param>
		/// <param name="point">The point.</param>
		/// <param name="duration">Duration.</param>
		/// <param name="easing">Easing.</param>
		public static IAnimationPipeline<Transform> MoveTo(this Transform transform, Point point, float duration, IEasing easing = null, string name = null)
		{
            return transform.MoveTo(point.X, point.Y, duration, easing, name);
		}

		public static IAnimationPipeline<Transform> MoveTo(this IAnimationPipeline<Transform> pipeline, Point point, float duration, IEasing easing = null, string name = null)
		{
            pipeline.Add(CreateMoveToAnimation(pipeline.Owner, point.X, point.Y, duration, easing, name));
      
            return pipeline;
		}

		public static IAnimationPipeline<Transform> ScaleTo(this Transform transform, Point to, float duration, IEasing easing = null)
		{
            var animation = new PointAnimation<Transform>(transform, "ScaleTo", transform.Scale, to, duration, (v) =>
            {
                transform.Scale = v;
            });

            animation.Easing = easing;

            return AnimationPipeline<Transform>.Create(animation);
		}

        private static IAnimation<Transform> CreateMoveToAnimation(Transform transform, float x, float y, float duration, IEasing easing = null, string name = null)
        {
			name = name ?? "MoveFrom{0}To{1},{2}".With(transform.Position, x, y);
			var animation = new PositionAnimation(transform, name, new Point(x, y), duration);
			animation.Easing = easing;

            return animation;
		}
    }
}
