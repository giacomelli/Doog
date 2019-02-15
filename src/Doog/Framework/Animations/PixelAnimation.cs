using System;
using System.Collections.Generic;

namespace Doog
{
    public class PixelAnimation : AnimationBase<IPixelable, int>
    {
        private IList<Pixel> _pixelsRange;

        public PixelAnimation(IPixelable owner, IEnumerable<Pixel>pixelsRange, float duration)
           : base(owner, duration)
        {
            _pixelsRange = new List<Pixel>(pixelsRange);
            _pixelsRange.Insert(0, owner.Pixel);

            To = _pixelsRange.Count - 1;
        }
        /// <summary>
        /// Play the animation.
        /// </summary>
        public override void Play()
        {
            From = 0;
            base.Play();
        }

        /// <summary>
        /// Updates the value.
        /// </summary>
        /// <param name="time">The animation time.</param>
        protected override void UpdateValue(float time)
        {
            var index = (int)Math.Round(Easing.Calculate(From, To, time));

            Owner.Pixel = _pixelsRange[index];
        }

        /// <summary>
        /// Reset the animation.
        /// </summary>
        public override void Reset()
        {
            Owner.Pixel = _pixelsRange[0];
            base.Reset();
        }
    }
}
