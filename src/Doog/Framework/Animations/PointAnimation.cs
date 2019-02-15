using System;

namespace Doog
{
    /// <summary>
    /// A point animation.
    /// </summary>
    public class PointAnimation<TOwner> : AnimationBase<TOwner, Point>
        where TOwner : IComponent
    {
        private readonly Func<TOwner, Point> getFrom;
        private readonly Action<Point> callback;

        /// <summary>
        /// Initializes a new instance of the <see cref="PointAnimation{TOwner}"/> class.
        /// </summary>
        /// <param name="owner">The owner.</param>
        /// <param name="getFrom">The get from ponit.</param>
        /// <param name="to">The to point.</param>
        /// <param name="duration">The duration.</param>
        /// <param name="callback">The callback.</param>
        public PointAnimation(TOwner owner, Func<TOwner, Point> getFrom, Point to, float duration, Action<Point> callback)
            : base(owner, duration)
        {
            this.getFrom = getFrom;
            To = to;
            this.callback = callback;
        }

        /// <summary>
        /// Play the animation.
        /// </summary>
        public override void Play()
        {
            From = getFrom(Owner);
			base.Play();
        }

        /// <summary>
        /// Updates the value.
        /// </summary>
        /// <param name="time">The animation time.</param>
        protected override void UpdateValue(float time)
        {
            callback(new Point(
                Easing.Calculate(From.X, To.X, time),
                Easing.Calculate(From.Y, To.Y, time)));
        }

        /// <summary>
        /// Reset the animation.
        /// </summary>
        public override void Reset()
		{
            callback(From);
			base.Reset();
		}
    }
}
