using System;
namespace Snake.Framework.Animations
{
    public static class AnimationPipelineExtensions
    {
		internal static IAnimation<TOwner> GetLast<TOwner>(this IAnimationPipeline<TOwner> pipeline)
			where TOwner : IComponent
        {
            return pipeline.Get(pipeline.Length - 1);    
        }

        public static IAnimationPipeline<TOwner> OnlyForward<TOwner>(this IAnimationPipeline<TOwner> pipeline)
            where TOwner : IComponent
        {
            pipeline.GetLast().Direction = AnimationDirection.Forward;

            return pipeline;
        }

		public static IAnimationPipeline<TOwner> OnlyBackward<TOwner>(this IAnimationPipeline<TOwner> pipeline)
		   where TOwner : IComponent
		{
			pipeline.GetLast().Direction = AnimationDirection.Backward;

			return pipeline;
		}
    }
}
