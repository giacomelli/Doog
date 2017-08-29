using System;

namespace Snake.Framework.Animations
{
    public class DoAnimation<TComponent> : AnimationBase<TComponent, float>
        where TComponent : IComponent
    {
        private Action callback;

        public DoAnimation(TComponent owner,  Action callback = null)
            : base(owner, 0)
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
