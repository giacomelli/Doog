using System;
namespace Snake.Framework.Animations
{
    public static class TweenExtensions
    {
        // https://stackoverflow.com/questions/30623682/how-to-get-unique-id-of-lambda-function-for-do-once-pattern
        public static ITween Loop(this ITween tween)
        {
            tween.Ended -= LoopTweenEnded;
            tween.Ended += LoopTweenEnded;

            return tween;
        }

		static void LoopTweenEnded(object sender, EventArgs e)
		{
            ((ITween)sender).Reset();
		}


		public static ITween PingPong(this ITween tween)
        {
			tween.Ended -= PingPongTweenEnded;
			tween.Ended += PingPongTweenEnded;

			return tween;
        }

		static void PingPongTweenEnded(object sender, EventArgs e)
		{
			((ITween)sender).Reverse();
		}

	}
}
