using System;

namespace Snake.Framework.Animations
{
    public class TweenEndedEventArgs : EventArgs
    {
        public TweenEndedEventArgs(ITween tween)
        {
            Tween = tween;
        }

        public ITween Tween { get; private set; }
    }
}
