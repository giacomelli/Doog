using System;

namespace Doog
{
    /// <summary>
    /// Do (perform an action) extension methods.
    /// </summary>
    public static class DoExtensions
    {
        /// <summary>
        /// Creates a new animation pipeline with a callback.
        /// </summary>
        /// <typeparam name="TOwner">The type of the owner.</typeparam>
        /// <param name="owner">The owner.</param>
        /// <param name="callback">The callback.</param>
        /// <returns>The animation pipeline controller.</returns>
		public static IAnimationPipeline<TOwner> Do<TOwner>(this TOwner owner, Action callback)
			where TOwner : IComponent
		{
            var animation = new DelayAnimation<TOwner>(owner, 0, callback);

			return AnimationPipeline<TOwner>.Create(animation);
		}

        /// <summary>
        /// Adds a callback to the pipeline.
        /// </summary>
        /// <typeparam name="TOwner">The type of the owner.</typeparam>
        /// <param name="pipeline">The animation pipeline.</param>
        /// <param name="callback">The callback.</param>
        /// <returns>The animation pipeline controller.</returns>
        public static IAnimationPipeline<TOwner> Do<TOwner>(this IAnimationPipeline<TOwner> pipeline, Action callback)
			 where TOwner : IComponent
		{
            var animation = new DelayAnimation<TOwner>(pipeline.Owner, 0, callback);

            pipeline.Add(animation);

            return pipeline;
		}
	}
}
