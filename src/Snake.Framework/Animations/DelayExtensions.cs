using System;
namespace Snake.Framework.Animations
{
    public static class DelayExtensions
    {
		public static IAnimationPipeline<TComponent> Delay<TComponent>(this TComponent owner, float seconds)
             where TComponent : IComponent
        {
            var delayAnimation = new DelayAnimation<TComponent>(owner, seconds);

            return AnimationPipeline<TComponent>.Create(delayAnimation);
        }

		public static IAnimationPipeline<TComponent> Delay<TComponent>(this IAnimationPipeline<TComponent> pipeline, float seconds)
			 where TComponent : IComponent
		{
			var delayAnimation = new DelayAnimation<TComponent>(pipeline.Owner, seconds);

            pipeline.Add(delayAnimation);

            return pipeline;
		}
	}
}
