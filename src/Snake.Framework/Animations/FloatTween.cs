using System;
using Snake.Framework.Geometry;

namespace Snake.Framework.Animations
{
    public class FloatTween : TweenBase
    {
        private float from;
        private float to;
        private Action<float> changeValue;

        public FloatTween(float from, float to, float duration, IWorldContext context, Action<float> changeValue)
            : base(duration, context)
        {
            this.from = from;
            this.to = to;
            this.changeValue = changeValue;
        }

        protected override void UpdateValue(float time)
        {
            changeValue(Ease.Calculate(from, to, time));
        }

        public override void Reverse()
        {
            var temp = from;
            from = to;
            to = temp;
            Play();
        }
    }
}
