using System;
using Snake.Framework.Geometry;

namespace Snake.Framework.Animations
{
    /// <summary>
    /// A position animation.
    /// </summary>
    public class PositionAnimation : AnimationBase<Transform>
    {
        private Point? fromForward;
        private Point toForward;

        private Point? fromBackward;
		private Point toBackward;

        public PositionAnimation(Transform owner, Point to, float duration)
            : base(owner, duration)
        {
            if (Direction == AnimationDirection.Backward)
            {
                this.toBackward = to;
            }
            else 
            {
                this.toForward = to;
            }
        }

        public override void Play()
        {
            if (Direction == AnimationDirection.Backward)
            {
                if (!fromBackward.HasValue)
                {
                    fromBackward = Owner.Position;
                }
            }
            else if (!fromForward.HasValue) 
			{
				fromForward = Owner.Position;
			}

            base.Play();
        }

        protected override void UpdateValue(float time)
        {
			if (Direction == AnimationDirection.Backward)
			{
				Owner.Position = new Point(
				Easing.Calculate(fromBackward.Value.X, toBackward.X, time),
				Easing.Calculate(fromBackward.Value.Y, toBackward.Y, time));
			}
			else
			{
				Owner.Position = new Point(
				Easing.Calculate(fromForward.Value.X, toForward.X, time),
				Easing.Calculate(fromForward.Value.Y, toForward.Y, time));
			}
        }

        public override void Reset()
        {
			if (Direction == AnimationDirection.Backward)
			{
                Owner.Position = fromBackward.Value;
			}
			else
			{
                Owner.Position = fromForward.Value;
			}

            base.Reset();
        }

        public override void Reverse()
        {
			if (Direction == AnimationDirection.Backward)
			{
                var temp = fromBackward.Value;
				fromBackward = toBackward;
				toBackward = temp;
			}
			else
			{
				var temp = fromForward.Value;
				fromForward = toForward;
				toForward = temp;
			}
        }
    }
}
