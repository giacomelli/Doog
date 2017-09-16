using System;
using Doog.Framework;

namespace Doog.Framework
{
    /// <summary>
    /// A float animation.
    /// </summary>
    public class FloatAnimation<TOwner> : AnimationBase<TOwner, float>
        where TOwner : IComponent
    {
        private Action<float> changeValue;

        public FloatAnimation(TOwner owner, float from, float to, float duration, Action<float> changeValue)
            : base(owner, duration)
        {
            From = from;
            To = to;
            this.changeValue = changeValue;
        }

        public override void Reset()
        {
            changeValue(From);
            base.Reset();
        }

        protected override void UpdateValue(float time)
        {
            changeValue(Easing.Calculate(From, To, time));
        }
    }
}
