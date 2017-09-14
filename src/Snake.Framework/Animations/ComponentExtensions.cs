using System;

namespace Snake.Framework.Animations
{
    /// <summary>
    /// Component extension methods.
    /// </summary>
    public static class ComponentExtensions
    {
        /// <summary>
        /// Animate the flaot value between the values defined in to and from arguments.
        /// </summary>
        /// <returns>The to.</returns>
        /// <param name="component">Component.</param>
        /// <param name="from">From.</param>
        /// <param name="to">To.</param>
        /// <param name="duration">Duration.</param>
        /// <param name="easing">Easing.</param>
        /// <param name="callback">Callback.</param>
        public static IAnimationPipeline<TOwner> To<TOwner>(this TOwner component, float from, float to, float duration, IEasing easing, Action<float> callback)
            where TOwner : IComponent
        {
            var animation = new FloatAnimation<TOwner>(component, from, to, duration, callback);
            animation.Easing = easing;

            return AnimationPipeline<TOwner>.Create(animation);
        }

        public static IAnimationPipeline<TOwner> To<TOwner>(this IAnimationPipeline<TOwner> pipeline, float from, float to, float duration, IEasing easing, Action<float> callback)
		  where TOwner : IComponent
		{
			var animation = new FloatAnimation<TOwner>(pipeline.Owner, from, to, duration, callback);
			animation.Easing = easing;
            pipeline.Add(animation);

            return pipeline;
		}

        /// <summary>
        /// Animates the boolean values using the start value.
        /// </summary>
        /// <returns>The toogle.</returns>
        /// <param name="component">Component.</param>
        /// <param name="start">If set to <c>true</c> start.</param>
        /// <param name="duration">Duration.</param>
        /// <param name="easing">Easing.</param>
        /// <param name="callback">Callback.</param>
        public static IAnimationPipeline<TOwner> Toogle<TOwner>(this TOwner component, bool start, float duration, IEasing easing, Action<bool> callback)
		    where TOwner : IComponent
        {
            return component.To(0f, 1f, duration, easing, v => {
                callback(start == v < 0.5f);
            });
	    }

        public static IAnimationPipeline<TOwner> Toogle<TOwner>(this IAnimationPipeline<TOwner> pipeline, bool start, float duration, IEasing easing, Action<bool> callback)
			where TOwner : IComponent
		{
			return pipeline.To(0f, 1f, duration, easing, v =>
			{
				callback(start == v < 0.5f);
			});
		}

        public static IAnimationPipeline<TOwner> Enable<TOwner>(this TOwner owner, float duration)
		    where TOwner : IComponent
        {
            return owner.Delay(duration, () =>
            {
                owner.Enabled = true;
            });
		}

		public static IAnimationPipeline<TOwner> Enable<TOwner>(this TOwner owner)
		   where TOwner : IComponent
		{
			return owner.Do(() =>
			{
				owner.Enabled = true;
			});
		}

        public static IAnimationPipeline<TOwner> Enable<TOwner>(this IAnimationPipeline<TOwner> pipeline, float duration)
			where TOwner : IComponent
		{
            return pipeline.Delay(duration, () =>
            {
                pipeline.Owner.Enabled = true;
            });
		}

		public static IAnimationPipeline<TComponent> Enable<TComponent>(this IAnimationPipeline<TComponent> pipeline)
			where TComponent : IComponent
		{
            return pipeline.Do(() =>
            {
				pipeline.Owner.Enabled = true;
            });
		}

        public static IAnimationPipeline<TOwner> Disable<TOwner>(this TOwner owner, float duration)
			where TOwner : IComponent
		{
            return owner.Delay(duration, () =>
            {
                owner.Enabled = false;
            });
		}

		public static IAnimationPipeline<TOwner> Disable<TOwner>(this TOwner owner)
			where TOwner : IComponent
		{
			return owner.Do(() =>
			{
				owner.Enabled = false;
			});
		}

        public static IAnimationPipeline<TOwner> Disable<TOwner>(this IAnimationPipeline<TOwner> pipeline, float duration)
            where TOwner : IComponent
        {
            return pipeline.Delay(duration, () =>
            {
                pipeline.Owner.Enabled = false;
            });
		}

        public static IAnimationPipeline<TOwner> Disable<TOwner>(this IAnimationPipeline<TOwner> pipeline)
			where TOwner : IComponent
		{
            return pipeline.Do(() => 
            {
				pipeline.Owner.Enabled = false;
            });
		}
    }
}