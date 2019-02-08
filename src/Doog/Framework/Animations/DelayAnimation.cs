using System;

namespace Doog
{
    public class DelayAnimation<TComponent> : AnimationBase<TComponent, float>
        where TComponent : IComponent
    {
        private Action callback;

        public DelayAnimation(TComponent owner, float duration, Action callback = null)
            : base(owner, duration)
        {
            this.callback = callback;
        }

        protected override void UpdateValue(float time)
        {
        }

        protected override void OnEnded(EventArgs args)
        {
            base.OnEnded(args);

            if (callback != null)
            {
                callback();
            }
        }
    }
}
