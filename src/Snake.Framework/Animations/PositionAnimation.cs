using System;
using Snake.Framework.Geometry;

namespace Snake.Framework.Animations
{
    /// <summary>
    /// A position animation.
    /// </summary>
    public class PositionAnimation : AnimationBase<Transform, Point>
    {
        public PositionAnimation(Transform owner, Point to, float duration)
            : base(owner, duration)
        {
            To = to;
        }

        public override void Play()
        {
            From = Owner.Position;
            base.Play();
        }

        protected override void UpdateValue(float time)
        {
			Owner.Position = new Point(
			     Easing.Calculate(From.X, To.X, time),
			     Easing.Calculate(From.Y, To.Y, time));
		}

        public override void Reset()
        {
            Owner.Position = From;
            base.Reset();
        }
    }
}
