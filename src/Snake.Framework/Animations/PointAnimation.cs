using System;
using Snake.Framework.Geometry;

namespace Snake.Framework.Animations
{
    /// <summary>
    /// A point animation.
    /// </summary>
    public class PointAnimation<TOwner> : AnimationBase<TOwner, Point>
        where TOwner : IComponent
    {
        private Func<TOwner, Point> getFrom;
        private Action<Point> callback;

        public PointAnimation(TOwner owner, Func<TOwner, Point> getFrom, Point to, float duration, Action<Point> callback)
            : base(owner, duration)
        {
            this.getFrom = getFrom;
            To = to;
            this.callback = callback;
        }

        public override void Play()
        {
            From = getFrom(Owner);
			base.Play();
        }

        protected override void UpdateValue(float time)
        {
            callback(new Point(
                Easing.Calculate(From.X, To.X, time),
                Easing.Calculate(From.Y, To.Y, time)));
        }
    }
}
