namespace Doog
{
    /// <summary>
    /// Animation pipeline extension methods.
    /// </summary>
    public static class AnimationPipelineExtensions
    {
		internal static IAnimation<TOwner> GetLast<TOwner>(this IAnimationPipeline<TOwner> pipeline)
			where TOwner : IComponent
        {
            return pipeline.Get(pipeline.Length - 1);    
        }

        /// <summary>
        /// Changes the direction of the current animation in the pipeline (the last one) to forward.
        /// </summary>
        /// <returns>The pipeline.</returns>
        /// <param name="pipeline">Pipeline.</param>
        /// <typeparam name="TOwner">The 1st type parameter.</typeparam>
        public static IAnimationPipeline<TOwner> OnlyForward<TOwner>(this IAnimationPipeline<TOwner> pipeline)
            where TOwner : IComponent
        {
            pipeline.GetLast().Direction = AnimationDirection.Forward;

            return pipeline;
        }

		/// <summary>
		/// Changes the direction of the current animation in the pipeline (the last one) to backward.
		/// </summary>
		/// <returns>The pipeline.</returns>
		/// <param name="pipeline">Pipeline.</param>
		/// <typeparam name="TOwner">The 1st type parameter.</typeparam>
		public static IAnimationPipeline<TOwner> OnlyBackward<TOwner>(this IAnimationPipeline<TOwner> pipeline)
		   where TOwner : IComponent
		{
			pipeline.GetLast().Direction = AnimationDirection.Backward;

			return pipeline;
		}
    }
}
