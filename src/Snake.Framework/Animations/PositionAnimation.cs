using System;
using Snake.Framework.Geometry;

namespace Snake.Framework.Animations
{
    /// <summary>
    /// A position animation.
    /// </summary>
    public class PositionAnimation : AnimationBase<Transform>
    {
        private Point to;
        private Point from;

        public PositionAnimation(Transform owner, Point to, float duration)
            : base(owner, duration)
        {
            this.to = to;
        }

        public override void Play()
        {
            this.from = Owner.Position;
            base.Play();
        }

        protected override void UpdateValue(float time)
        {
			Owner.Position = new Point(
			     Easing.Calculate(from.X, to.X, time),
			     Easing.Calculate(from.Y, to.Y, time));
		}

        public override void Reset()
        {
            Owner.Position = from;
            base.Reset();
        }

        public override void Reverse()
        {
			var temp = from;
			from = to;
			to = temp;
		}
    }
}
