using System;
using Snake.Framework.Geometry;

namespace Snake.Framework.Animations
{
    /// <summary>
    /// A float animation.
    /// </summary>
    public class FloatAnimation<TComponent> : AnimationBase<TComponent, float>
        where TComponent : IComponent
    {
        private Action<float> changeValue;

        public FloatAnimation(TComponent owner, float from, float to, float duration, Action<float> changeValue)
            : base(owner, duration)
        {
            From = from;
            To = to;
            this.changeValue = changeValue;
        }

        protected override void UpdateValue(float time)
        {
            changeValue(Easing.Calculate(From, To, time));
        }
    }
}
