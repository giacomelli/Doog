using System;
using Snake.Framework.Geometry;

namespace Snake.Framework.Animations
{
    public static class TransformComponentExtensions
    {
        public static Animation MoveTo(this TransformComponent transform, float x, float y, float duration, IEase easing)
        {
            var tween = new PositionTween(transform, new Point(x, y), duration);
            tween.Ease = easing;

            return transform.Animate("MoveTo", tween);
        }
    }
}
