using System;

namespace Doog
{
    public class DelayAnimation<TComponent> : AnimationBase<TComponent, float>
        where TComponent : IComponent
    {
        private readonly Action _callback;

        public DelayAnimation(TComponent owner, float duration, Action callback = null)
            : base(owner, duration)
        {
            _callback = callback;
        }

        protected override void UpdateValue(float time)
        {
        }

        protected override void OnEnded(EventArgs args)
        {
            base.OnEnded(args);

            _callback?.Invoke();
        }
    }
}
