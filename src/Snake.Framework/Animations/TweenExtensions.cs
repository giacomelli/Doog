using System;
namespace Snake.Framework.Animations
{
    public static class TweenExtensions
    {

        // https://stackoverflow.com/questions/30623682/how-to-get-unique-id-of-lambda-function-for-do-once-pattern
        public static ITween Loop(this ITween tween)
        {
            void LoopTweenEnded(object sender, TweenEndedEventArgs e)
            {
                e.Tween.Reset();
            }

            tween.Ended -= LoopTweenEnded;
            tween.Ended += LoopTweenEnded;

            return tween;
        }



        public static ITween PingPong(this ITween tween)
        {
			void PingPongTweenEnded(object sender, TweenEndedEventArgs e)
			{
				e.Tween.Reverse();
			}

			tween.Ended -= PingPongTweenEnded;
			tween.Ended += PingPongTweenEnded;

			return tween;
        }
    }
}
