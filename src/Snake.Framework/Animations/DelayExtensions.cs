using System;
namespace Snake.Framework.Animations
{
    public static class DelayExtensions
    {
		public static AnimationPipeline<TComponent> Delay<TComponent>(this IAnimation<TComponent> animation, float seconds)
             where TComponent : IComponent
        {
            var delayAnimation = new DelayAnimation<TComponent>(animation.Owner, "{0}_Delay".With(animation.Name), seconds);

            return AnimationPipeline<TComponent>.Create(delayAnimation);
        }

		public static AnimationPipeline<TComponent> Delay<TComponent>(this AnimationPipeline<TComponent> pipeline, float seconds)
			 where TComponent : IComponent
		{
			var delayAnimation = new DelayAnimation<TComponent>(pipeline.Owner, "Delay", seconds);

            pipeline.Add(delayAnimation);

            return pipeline;
		}
	}
}
