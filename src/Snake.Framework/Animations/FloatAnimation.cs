using System;
using Snake.Framework.Geometry;

namespace Snake.Framework.Animations
{
    /// <summary>
    /// A float animation.
    /// </summary>
    public class FloatAnimation<TComponent> : AnimationBase<TComponent>
        where TComponent : IComponent
    {
        private float from;
        private float to;
        private Action<float> changeValue;

        public FloatAnimation(TComponent owner, float from, float to, float duration, Action<float> changeValue)
            : base(owner, duration)
        {
            this.from = from;
            this.to = to;
            this.changeValue = changeValue;
        }

        protected override void UpdateValue(float time)
        {
            changeValue(Easing.Calculate(from, to, time));
        }

        public override void Reverse()
        {
            var temp = from;
            from = to;
            to = temp;
        }
    }
}
