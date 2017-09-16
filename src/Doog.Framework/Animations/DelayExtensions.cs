using System;

namespace Doog.Framework
{
    public static class DelayExtensions
    {
		public static IAnimationPipeline<TOwner> Delay<TOwner>(this TOwner owner, float seconds)
			where TOwner : IComponent
		{
			var delayAnimation = new DelayAnimation<TOwner>(owner, seconds);

			return AnimationPipeline<TOwner>.Create(delayAnimation);
		}

        public static IAnimationPipeline<TOwner> Delay<TOwner>(this TOwner owner, float seconds, Action callback = null)
             where TOwner : IComponent
        {
            var delayAnimation = new DelayAnimation<TOwner>(owner, seconds, callback);

            return AnimationPipeline<TOwner>.Create(delayAnimation);
        }

		public static IAnimationPipeline<TOwner> Delay<TOwner>(this IAnimationPipeline<TOwner> pipeline, float seconds)
			where TOwner : IComponent
		{
			var delayAnimation = new DelayAnimation<TOwner>(pipeline.Owner, seconds);

			pipeline.Add(delayAnimation);

			return pipeline;
		}

        public static IAnimationPipeline<TOwner> Delay<TOwner>(this IAnimationPipeline<TOwner> pipeline, float seconds, Action callback = null)
			 where TOwner : IComponent
		{
			var delayAnimation = new DelayAnimation<TOwner>(pipeline.Owner, seconds, callback);

            pipeline.Add(delayAnimation);

            return pipeline;
		}
	}
}
