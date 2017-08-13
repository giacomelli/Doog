using System;
using Snake.Framework.Geometry;

namespace Snake.Framework.Animations
{
    public static class TransformComponentExtensions
    {
        public static Animation MoveTo(this TransformComponent transform, float x, float y, float duration, IEase easing, IWorldContext context)
        {
            var tween = new PositionTween(transform, new Point(x, y), duration, context);
            tween.Ease = easing;

            return transform.Animate("MoveToX", tween, context);
        }
    }
}
