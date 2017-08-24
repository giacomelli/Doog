namespace Snake.Framework.Animations
{
    public class DelayAnimation<TComponent> : AnimationBase<TComponent>
        where TComponent : IComponent
    {
        public DelayAnimation(TComponent owner, float duration)
            : base(owner, duration)
        {
        }

        public override void Reverse()
        {
        }

        protected override void UpdateValue(float time)
        {
        }
    }
}
