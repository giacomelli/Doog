using System;
using Snake.Framework.Behaviors;

namespace Snake.Framework.Animations
{
    public class Animation
    {
        public Animation(AnimationId id, ITween tween)
        {
            Id = id;
            Tween = tween;
        }

        public AnimationId Id { get; private set; }
        public ITween Tween { get; private set; }
    }
}
