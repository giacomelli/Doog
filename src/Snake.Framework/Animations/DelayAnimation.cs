namespace Snake.Framework.Animations
{
    public class DelayAnimation<TComponent> : AnimationBase<TComponent, float>
        where TComponent : IComponent
    {
        public DelayAnimation(TComponent owner, float duration)
            : base(owner, duration)
        {
        }

        protected override void UpdateValue(float time)
        {
        }
    }
}
