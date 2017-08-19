using System;
namespace Snake.Framework.Animations
{
    /// <summary>
    /// Availables easings.
    /// </summary>
    public static class Easing
    {
        /// <summary>
        /// Linear easing.
        /// </summary>
        public static readonly IEasing Linear = new LinearEasing();

        /// <summary>
        /// InBack easing.
        /// </summary>
        public static readonly IEasing InBack = new InBackEasing();
    }
}
