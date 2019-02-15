﻿using Doog;

namespace Snake
{
    public class Food : RectangleComponent, IDrawable, ICollidable
	{
        public static readonly Point DefaultScale = Point.Zero;

		public Food(IWorldContext context)
            : base(0, 0, context)
		{
            Pixel = '.'.Yellow();
            Transform.Scale = DefaultScale;

            //this
            //    .ForegroundColorTo(Color.DarkBlue, 1, Easing.InOutBounce)
            //    .PingPong();

            this
                .CharTo(new char[] { 'o', 'O' }, 0.25f, Easing.Linear)
                .Loop();
        }

  		public void OnCollision(Collision collision)
		{
            var otherTag = collision.Other.Tag;

            if (otherTag != "Food" &&  otherTag != "Snake")
            {
                Enabled = false;
            }
		}

        protected override void OnEnabled()
        {
            base.OnEnabled();
            Transform.Enabled = true;
        }

        protected override void OnDisabled()
        {
            base.OnDisabled();
            Transform.Enabled = false;
        }
	}
}
