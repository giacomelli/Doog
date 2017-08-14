using System;
using Snake.Framework;

namespace Snake.Framework.Animations
{
    public static class FloatExtensions
    {
        public static ITween Tween(this float from, float to, float duration, IEase ease, IWorldContext context, Action<float> changeValue)
        {
            var result = TweenFactory.Get<FloatTween>(
                "FloatExtensions_Tween_{0}_{1}_{2}_{3}".With(from, to, duration, ease),
                () =>
                {
                    var tween = new FloatTween(from, to, duration, context, changeValue);
                    tween.Ease = ease;
                    tween.Play();
                   
                    return tween;
                });

            return result;
        }
    }
}