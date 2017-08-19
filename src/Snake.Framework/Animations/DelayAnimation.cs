namespace Snake.Framework.Animations
{
    public class DelayAnimation<TComponent> : AnimationBase<TComponent>
        where TComponent : IComponent
    {
        public DelayAnimation(TComponent owner, string name, float duration)
            : base(owner, name, duration)
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
