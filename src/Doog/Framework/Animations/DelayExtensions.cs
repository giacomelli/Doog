using System;

namespace Doog
{
    /// <summary>
    /// DelayAnimation extensions methods.
    /// </summary>
    public static class DelayExtensions
    {
        /// <summary>
        /// Creates a new animation pipeline with a delay animation as first animation.
        /// </summary>
        /// <typeparam name="TOwner">The type of the owner.</typeparam>
        /// <param name="owner">The owner.</param>
        /// <param name="seconds">The duration seconds.</param>
        /// <param name="callback">The callback.</param>
        /// <returns>The animation pipeline.</returns>
        public static IAnimationPipeline<TOwner> Delay<TOwner>(this TOwner owner, float seconds, Action callback = null)
             where TOwner : IComponent
        {
            var delayAnimation = new DelayAnimation<TOwner>(owner, seconds, callback);

            return AnimationPipeline<TOwner>.Create(delayAnimation);
        }

        /// <summary>
        /// Adds a delay animation to the pipeline.
        /// </summary>
        /// <typeparam name="TOwner">The type of the owner.</typeparam>
        /// <param name="pipeline">The animation pipeline.</param>
        /// <param name="seconds">The duration seconds.</param>
        /// <param name="callback">The callback.</param>
        /// <returns>The animation pipeline.</returns>
        public static IAnimationPipeline<TOwner> Delay<TOwner>(this IAnimationPipeline<TOwner> pipeline, float seconds, Action callback = null)
			 where TOwner : IComponent
		{
			var delayAnimation = new DelayAnimation<TOwner>(pipeline.Owner, seconds, callback);

            pipeline.Add(delayAnimation);

            return pipeline;
		}
	}
}
