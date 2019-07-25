using System;

namespace Doog
{
    /// <summary>
    /// A delay animation.
    /// </summary>
    /// <remarks>
    /// Usefull when you need to wait some amount of time between animations in a pipeline.
    /// </remarks>
    /// <typeparam name="TComponent">The type of the component.</typeparam>    
    public class DelayAnimation<TComponent> : AnimationBase<TComponent, float>
        where TComponent : IComponent
    {
        private readonly Action _callback;

        /// <summary>
        /// Initializes a new instance of the <see cref="DelayAnimation{TComponent}"/> class.
        /// </summary>
        /// <param name="owner">The owner.</param>
        /// <param name="duration">The duration.</param>
        /// <param name="callback">The callback.</param>
        public DelayAnimation(TComponent owner, float duration, Action callback = null)
            : base(owner, duration)
        {
            _callback = callback;
        }

        /// <summary>
        /// Updates the value.
        /// </summary>
        /// <param name="time">The animation time.</param>
        protected override void UpdateValue(float time)
        {
        }

        /// <summary>
        /// Called when animation ends.
        /// </summary>
        /// <param name="args">Arguments.</param>
        protected override void OnEnded(EventArgs args)
        {
            base.OnEnded(args);

            _callback?.Invoke();
        }
    }
}
