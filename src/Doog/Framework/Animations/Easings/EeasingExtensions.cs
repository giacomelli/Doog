namespace Doog
{
    /// <summary>
    /// Easing extensions methods.
    /// </summary>
    public static class EeasingExtensions
    {
        /// <summary>
        /// Calculate the easing to the specified time.
        /// </summary>
        /// <param name="easing">The easing</param>
        /// <param name="start">The start value.</param>
        /// <param name="target">The target value.</param>
        /// <param name="time">The current time.</param>
        /// <returns>
        /// The easing to the time.
        /// </returns>
		public static float Calculate(this IEasing easing, float start, float target, float time)
		{
			return start + (target - start) * easing.Calculate(time);
		}
    }
}
