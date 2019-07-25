namespace Doog
{
	/// <summary>
	/// A linear easing with no easing and no acceleration.
	/// </summary>
	public class LinearEasing : IEasing
    {
        /// <summary>
        /// Calculate the easing to the specified time.
        /// </summary>
        /// <param name="time">Time.</param>
        /// <returns>
        /// The easing to the time.
        /// </returns>
        public float Calculate(float time)
        {
            return time;
        }
    }
}
