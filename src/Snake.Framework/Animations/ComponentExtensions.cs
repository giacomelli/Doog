using System;
using Snake.Framework;

namespace Snake.Framework.Animations
{
    public static class ComponentExtensions
    {
        public static Animation To(this IComponent component, float from, float to, float duration, IEase easing, Action<float> callback)
        {
            var tween = new FloatTween(from, to, duration, component.Context, callback);
            tween.Ease = easing;
            return component.Animate("To", tween);
        }

		public static Animation Toogle(this IComponent component, bool start, float duration, IEase easing, Action<bool> callback)
		{
            return component.To(0f, 1f, duration, easing, (v) => {
                callback(start == v < 0.5f);
            });
	    }
    }
}