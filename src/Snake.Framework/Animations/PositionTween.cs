using System;
using Snake.Framework.Geometry;

namespace Snake.Framework.Animations
{
    public class PositionTween : TweenBase
    {
        private TransformComponent transform;
        private Point from;
        private Point to;

        public PositionTween(TransformComponent transform, Point to, float duration, IWorldContext context)
            : base(duration, context)
        {
            this.transform = transform;
            this.from = transform.Position;
            this.to = to;
        }

        public override void Play()
        {
            //from = transform.Position;
            base.Play();
        }

        protected override void UpdateValue(float time)
        {
            transform.Position = new Point(
                Ease.Calculate(from.X, to.X, time),
                Ease.Calculate(from.Y, to.Y, time));
        }

		public override void Reverse()
		{
			var temp = from;
			from = to;
			to = temp;
            Play();
		}
    }
}
