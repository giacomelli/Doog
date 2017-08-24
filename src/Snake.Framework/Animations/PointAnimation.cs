using System;
using Snake.Framework.Geometry;

namespace Snake.Framework.Animations
{
    /// <summary>
    /// A point animation.
    /// </summary>
    public class PointAnimation<TOwner> : AnimationBase<TOwner>
        where TOwner : IComponent
    {
        private Point from;
        private Func<TOwner, Point> getFrom;
        private Point to;
        private Action<Point> callback;

        public PointAnimation(TOwner owner, Func<TOwner, Point> getFrom, Point to, float duration, Action<Point> callback)
            : base(owner, duration)
        {
            this.getFrom = getFrom;
            this.to = to;
            this.callback = callback;
        }

        public override void Play()
        {
            this.from = getFrom(Owner);
			base.Play();
        }

        protected override void UpdateValue(float time)
        {
            callback(new Point(
                Easing.Calculate(from.X, to.X, time),
                Easing.Calculate(from.Y, to.Y, time)));
        }

        public override void Reverse()
        {
            var temp = from;
            from = to;
            to = temp;
        }
    }
}
