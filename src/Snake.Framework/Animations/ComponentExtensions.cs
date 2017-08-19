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
        public static AnimationPipeline<TComponent> To<TComponent>(this TComponent component, float from, float to, float duration, IEasing easing, Action<float> callback)
            where TComponent : IComponent
        {
            var animation = new FloatAnimation<TComponent>(component, "To", from, to, duration, callback);
            animation.Easing = easing;

            return AnimationPipeline<TComponent>.Create(animation);
        }

		public static AnimationPipeline<TComponent> To<TComponent>(this AnimationPipeline<TComponent> pipeline, float from, float to, float duration, IEasing easing, Action<float> callback)
		  where TComponent : IComponent
		{
			var animation = new FloatAnimation<TComponent>(pipeline.Owner, "To", from, to, duration, callback);
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
		public static AnimationPipeline<TComponent> Toogle<TComponent>(this TComponent component, bool start, float duration, IEasing easing, Action<bool> callback)
		    where TComponent : IComponent
        {
            return component.To(0f, 1f, duration, easing, (v) => {
                callback(start == v < 0.5f);
            });
	    }

		public static AnimationPipeline<TComponent> Enable<TComponent>(this TComponent component, float duration, IEasing easing = null)
		    where TComponent : IComponent
        {
            return component.Toogle(component.Enabled, duration, easing, v => component.Enabled = v);
		}
    }
}