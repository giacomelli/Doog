using System;
using System.Collections.Generic;

namespace Doog.Framework.Animations
{
    /// <summary>
    /// Availables easings.
    /// </summary>
    /// <remarks>
    /// All those easing are coded with help from:
    /// * https://gist.github.com/gre/1650294
    /// * http://easings.net
    /// * https://github.com/cinder/Cinder/blob/3fc0c0f8ae268fa0589e412d19c7372951cef447/include/cinder/Easing.h#L375
    /// * https://github.com/acron0/Easings/blob/master/Easings.cs
    /// Thank you guys!
    /// </remarks>
    public static class Easing
    {
        static Easing()
        {
            All = new IEasing[]
            {
                Linear,
          
                InQuad,
                OutQuad,
                InOutQuad,

                InCubic,
                OutCubic,
                InOutCubic,

                InQuart,
                OutQuart,
                InOutQuart,

                InQuint,
                OutQuint,
                InOutQuint,

                InElastic,
                OutElastic,
                InOutElastic,

                InSin,
                OutSin,
                InOutSin,

                InExpo,
                OutExpo,
                InOutExpo,

                InCirc,
                OutCirc,
                InOutCirc,

                InBack,
                OutBack, // Steakhouse :D
                InOutBack,

                InBounce,
                OutBounce,
                InOutBounce
            };
        }

        public static IEasing Random()
        {
            return All.Rand();
        }

        /// <summary>
        /// Linear easing.
        /// </summary>
        public static readonly LinearEasing Linear = new LinearEasing();

        /// <summary>
        /// InQuad easing.
        /// </summary>
        public static readonly InQuadEasing InQuad = new InQuadEasing();

        /// <summary>
        /// OutQuad easing.
        /// </summary>
        public static readonly OutQuadEasing OutQuad = new OutQuadEasing();

        /// <summary>
        /// InOutQuad easing.
        /// </summary>
        public static readonly InOutQuadEasing InOutQuad = new InOutQuadEasing();

        /// <summary>
        /// InCubic easing.
        /// </summary>
        public static readonly InCubicEasing InCubic = new InCubicEasing();

        /// <summary>
        /// OutCubic easing.
        /// </summary>
        public static readonly OutCubicEasing OutCubic = new OutCubicEasing();

        /// <summary>
        /// InOutCubic easing.
        /// </summary>
        public static readonly InOutCubicEasing InOutCubic = new InOutCubicEasing();

        /// <summary>
        /// InQuart easing.
        /// </summary>
        public static readonly InQuartEasing InQuart = new InQuartEasing();

        /// <summary>
        /// OutQuart easing.
        /// </summary>
        public static readonly OutQuartEasing OutQuart = new OutQuartEasing();

        /// <summary>
        /// InOutQuart easing.
        /// </summary>
        public static readonly InOutQuartEasing InOutQuart = new InOutQuartEasing();

        /// <summary>
        /// InQuint easing.
        /// </summary>
        public static readonly InQuintEasing InQuint = new InQuintEasing();

        /// <summary>
        /// OutQuint easing.
        /// </summary>
        public static readonly OutQuintEasing OutQuint = new OutQuintEasing();

        /// <summary>
        /// InOutQuint easing.
        /// </summary>
        public static readonly InOutQuintEasing InOutQuint = new InOutQuintEasing();

        /// <summary>
        /// InElastic easing.
        /// </summary>
        public static readonly InElasticEasing InElastic = new InElasticEasing();

        /// <summary>
        /// OutElastic easing.
        /// </summary>
        public static readonly OutElasticEasing OutElastic = new OutElasticEasing();

        /// <summary>
        /// InOutElastic easing.
        /// </summary>
        public static readonly InOutElasticEasing InOutElastic = new InOutElasticEasing();

        /// <summary>
        /// InSin easing.
        /// </summary>
        public static readonly InSinEasing InSin = new InSinEasing();

        /// <summary>
        /// OutSin easing.
        /// </summary>
        public static readonly OutSinEasing OutSin = new OutSinEasing();

        /// <summary>
        /// InOutSin easing.
        /// </summary>
        public static readonly InOutSinEasing InOutSin = new InOutSinEasing();

        /// <summary>
        /// InExpo easing.
        /// </summary>
        public static readonly InExpoEasing InExpo = new InExpoEasing();

        /// <summary>
        /// OutExpo easing.
        /// </summary>
        public static readonly OutExpoEasing OutExpo = new OutExpoEasing();

        /// <summary>
        /// InOutExpo easing.
        /// </summary>
        public static readonly InOutExpoEasing InOutExpo = new InOutExpoEasing();

        /// <summary>
        /// InCirc easing.
        /// </summary>
        public static readonly InCircEasing InCirc = new InCircEasing();

        /// <summary>
        /// OutCirc easing.
        /// </summary>
        public static readonly OutCircEasing OutCirc = new OutCircEasing();

        /// <summary>
        /// InOutCirc easing.
        /// </summary>
        public static readonly InOutCircEasing InOutCirc = new InOutCircEasing();

        /// <summary>
        /// InBack easing.
        /// </summary>
        public static readonly InBackEasing InBack = new InBackEasing();

        /// <summary>
        /// OutBack easing.
        /// </summary>
        public static readonly OutBackEasing OutBack = new OutBackEasing();

        /// <summary>
        /// InOutBack easing.
        /// </summary>
        public static readonly InOutBackEasing InOutBack = new InOutBackEasing();


        /// <summary>
        /// InBounce easing.
        /// </summary>
        public static readonly InBounceEasing InBounce = new InBounceEasing();

        /// <summary>
        /// OutBounce easing.
        /// </summary>
        public static readonly OutBounceEasing OutBounce = new OutBounceEasing();

        /// <summary>
        /// InOutBounce easing.
        /// </summary>
        public static readonly InOutBounceEasing InOutBounce = new InOutBounceEasing();

        /// <summary>
        /// Gets all eansings.
        /// </summary>
        /// <value>All.</value>
        public static IEasing[] All { get; private set; }

    }
}
