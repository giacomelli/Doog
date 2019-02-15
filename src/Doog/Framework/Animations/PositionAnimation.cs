namespace Doog
{
    /// <summary>
    /// A position animation.
    /// </summary>
    public class PositionAnimation : AnimationBase<Transform, Point>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PositionAnimation"/> class.
        /// </summary>
        /// <param name="owner">The owner.</param>
        /// <param name="to">To.</param>
        /// <param name="duration">The duration.</param>
        public PositionAnimation(Transform owner, Point to, float duration)
            : base(owner, duration)
        {
            To = to;
        }

        /// <summary>
        /// Play the animation.
        /// </summary>
        public override void Play()
        {
            From = Owner.Position;
            base.Play();
        }

        /// <summary>
        /// Updates the value.
        /// </summary>
        /// <param name="time">The animation time.</param>
        protected override void UpdateValue(float time)
        {
			Owner.Position = new Point(
			     Easing.Calculate(From.X, To.X, time),
			     Easing.Calculate(From.Y, To.Y, time));
		}

        /// <summary>
        /// Reset the animation.
        /// </summary>
        public override void Reset()
        {
            Owner.Position = From;
            base.Reset();
        }
    }
}
