using System;

namespace Doog
{
    /// <summary>
    /// A float animation.
    /// </summary>
    public class FloatAnimation<TOwner> : AnimationBase<TOwner, float>
        where TOwner : IComponent
    {
        private readonly Action<float> _changeValue;

        public FloatAnimation(TOwner owner, float from, float to, float duration, Action<float> changeValue)
            : base(owner, duration)
        {
            From = from;
            To = to;
            this._changeValue = changeValue;
        }

        public override void Reset()
        {
            _changeValue(From);
            base.Reset();
        }

        protected override void UpdateValue(float time)
        {
            _changeValue(Easing.Calculate(From, To, time));
        }
    }
}
