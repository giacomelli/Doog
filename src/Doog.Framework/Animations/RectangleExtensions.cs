using System;
using Doog.Framework.Geometry;

namespace Doog.Framework.Animations
{
    public static class RectangleExtensions
    {
        public static IAnimationPipeline<RectangleComponent> Iterate(this RectangleComponent owner, float duration, IEasing easing, Action<float, float> callback)
        {
            var animation = new RectangleIterateAnimation<RectangleComponent>(owner, owner.Transform.BoundingBox, owner.Filled, duration, callback)
            {
                Easing = easing 
            };

            return AnimationPipeline<RectangleComponent>.Create(animation);
        }

		public static IAnimationPipeline<RectangleComponent> Iterate(this IAnimationPipeline<RectangleComponent> pipeline, float duration, IEasing easing, Action<float, float> callback)
		{
            var owner = pipeline.Owner;
			var animation = new RectangleIterateAnimation<RectangleComponent>(owner, owner.Transform.BoundingBox, owner.Filled, duration, callback)
			{
				Easing = easing
			};

            pipeline.Add(animation);

            return pipeline;
		}

		public static IAnimationPipeline<TOwner> Iterate<TOwner>(this TOwner owner, Rectangle rectanle, bool filled,  float duration, IEasing easing, Action<float, float> callback)
            where TOwner : IComponent
		{
			var animation = new RectangleIterateAnimation<TOwner>(owner, rectanle, filled, duration, callback)
			{
				Easing = easing
			};

			return AnimationPipeline<TOwner>.Create(animation);
		}

		public static IAnimationPipeline<TOwner> Iterate<TOwner>(this IAnimationPipeline<TOwner> pipeline, Rectangle rectanle, bool filled, float duration, IEasing easing, Action<float, float> callback)
		where TOwner : IComponent
		{
			var animation = new RectangleIterateAnimation<TOwner>(pipeline.Owner, rectanle, filled, duration, callback)
			{
				Easing = easing
			};

            pipeline.Add(animation);

            return pipeline;
		}

		public static IAnimationPipeline<ITransformable> Iterate(this ITransformable owner, bool filled, float duration, IEasing easing, Action<float, float> callback)
		{
			var animation = new RectangleIterateAnimation<ITransformable>(owner, owner.Transform.BoundingBox, filled, duration, callback)
			{
				Easing = easing
			};

			return AnimationPipeline<ITransformable>.Create(animation);
		}

		public static IAnimationPipeline<ITransformable> Iterate(this IAnimationPipeline<ITransformable> pipeline, bool filled, float duration, IEasing easing, Action<float, float> callback)
		{
            var owner = pipeline.Owner;

			var animation = new RectangleIterateAnimation<ITransformable>(owner, owner.Transform.BoundingBox, filled, duration, callback)
			{
				Easing = easing
			};

            pipeline.Add(animation);

            return pipeline;
		}
    }
}
