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
        private Point to;
        private Action<Point> callback;

        public PointAnimation(TOwner owner, string name, Point from, Point to, float duration, Action<Point> callback)
            : base(owner, name, duration)
        {
            this.from = from;
            this.to = to;
            this.callback = callback;
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
