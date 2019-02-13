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

        /// <summary>
        /// Initializes a new instance of the <see cref="FloatAnimation{TOwner}"/> class.
        /// </summary>
        /// <param name="owner">The owner.</param>
        /// <param name="from">From.</param>
        /// <param name="to">To.</param>
        /// <param name="duration">The duration.</param>
        /// <param name="changeValue">The change value.</param>
        public FloatAnimation(TOwner owner, float from, float to, float duration, Action<float> changeValue)
            : base(owner, duration)
        {
            From = from;
            To = to;
            this._changeValue = changeValue;
        }

        /// <summary>
        /// Reset the animation.
        /// </summary>
        public override void Reset()
        {
            _changeValue(From);
            base.Reset();
        }

        /// <summary>
        /// Updates the value.
        /// </summary>
        /// <param name="time">The animation time.</param>
        protected override void UpdateValue(float time)
        {
            _changeValue(Easing.Calculate(From, To, time));
        }
    }
}
