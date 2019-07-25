using System;

namespace Doog
{
    /// <summary>
    /// Rectangle extension methods.
    /// </summary>
    public static partial class RectangleExtensions
    {
        /// <summary>
        /// Creates a new animation pipeline with a rectangle iteration animation as first animation.
        /// </summary>        
        /// <param name="owner">The owner.</param>
        /// <param name="duration">The duration seconds.</param>]
        /// <param name="easing">The easing.</param>
        /// <param name="callback">The callback.</param>
        /// <returns>The animation pipeline.</returns>
        public static IAnimationPipeline<RectangleComponent> Iterate(this RectangleComponent owner, float duration, IEasing easing, Action<float, float> callback)
        {
            var animation = new RectangleIterateAnimation<RectangleComponent>(owner, owner.Transform.BoundingBox, owner.Filled, duration, callback)
            {
                Easing = easing 
            };

            return AnimationPipeline<RectangleComponent>.Create(animation);
        }

        /// <summary>
        /// Adds a rectangle iteration animation.
        /// </summary>        
        /// <param name="pipeline">The pipeline.</param>
        /// <param name="duration">The duration seconds.</param>
        /// <param name="easing">The easing.</param>
        /// <param name="callback">The callback.</param>
        /// <returns>The animation pipeline.</returns>
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

        /// <summary>
        /// Creates a new animation pipeline with a rectangle iteration animation as first animation.
        /// </summary>        
        /// <param name="owner">The owner.</param>
        /// <param name="rectanle">The rectangle.</param>
        /// <param name="filled">If rectangle should be filled.</param>
        /// <param name="duration">The duration seconds.</param>]
        /// <param name="easing">The easing.</param>
        /// <param name="callback">The callback.</param>
        /// <returns>The animation pipeline controller.</returns>
		public static IAnimationPipeline<TOwner> Iterate<TOwner>(this TOwner owner, Rectangle rectanle, bool filled,  float duration, IEasing easing, Action<float, float> callback)
            where TOwner : IComponent
		{
			var animation = new RectangleIterateAnimation<TOwner>(owner, rectanle, filled, duration, callback)
			{
				Easing = easing
			};

			return AnimationPipeline<TOwner>.Create(animation);
		}

        /// <summary>
        /// Adds a rectangle iteration animation.
        /// </summary>        
        /// <param name="pipeline">The pipeline.</param>
        /// <param name="rectangle">The rectangle.</param>
        /// <param name="filled">If rectangle should be filled.</param>
        /// <param name="duration">The duration seconds.</param>
        /// <param name="easing">The easing.</param>
        /// <param name="callback">The callback.</param>
        /// <returns>The animation pipeline.</returns>
		public static IAnimationPipeline<TOwner> Iterate<TOwner>(this IAnimationPipeline<TOwner> pipeline, Rectangle rectangle, bool filled, float duration, IEasing easing, Action<float, float> callback)
		where TOwner : IComponent
		{
			var animation = new RectangleIterateAnimation<TOwner>(pipeline.Owner, rectangle, filled, duration, callback)
			{
				Easing = easing
			};

            pipeline.Add(animation);

            return pipeline;
		}

        /// <summary>
        /// Creates a new animation pipeline with a rectangle iteration animation as first animation.
        /// </summary>        
        /// <param name="owner">The owner.</param>
        /// <param name="filled">If rectangle should be filled.</param>
        /// <param name="duration">The duration seconds.</param>
        /// <param name="easing">The easing.</param>
        /// <param name="callback">The callback.</param>
        /// <returns>The animation pipeline.</returns>
		public static IAnimationPipeline<ITransformable> Iterate(this ITransformable owner, bool filled, float duration, IEasing easing, Action<float, float> callback)
		{
			var animation = new RectangleIterateAnimation<ITransformable>(owner, owner.Transform.BoundingBox, filled, duration, callback)
			{
				Easing = easing
			};

			return AnimationPipeline<ITransformable>.Create(animation);
		}

        /// <summary>
        /// Adds a rectangle iteration animation.
        /// </summary>        
        /// <param name="pipeline">The pipeline.</param>
        /// <param name="filled">If rectangle should be filled.</param>
        /// <param name="duration">The duration seconds.</param>
        /// <param name="easing">The easing.</param>
        /// <param name="callback">The callback.</param>
        /// <returns>The animation pipeline.</returns>
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
