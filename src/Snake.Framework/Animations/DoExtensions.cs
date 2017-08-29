using System;
namespace Snake.Framework.Animations
{
    public static class DoExtensions
    {
		public static IAnimationPipeline<TOwner> Do<TOwner>(this TOwner owner, Action callback)
			where TOwner : IComponent
		{
            var animation = new DelayAnimation<TOwner>(owner, 0, callback);

			return AnimationPipeline<TOwner>.Create(animation);
		}

  
        public static IAnimationPipeline<TOwner> Do<TOwner>(this IAnimationPipeline<TOwner> pipeline, Action callback)
			 where TOwner : IComponent
		{
            var animation = new DelayAnimation<TOwner>(pipeline.Owner, 0, callback);

            pipeline.Add(animation);

            return pipeline;
		}
	}
}
