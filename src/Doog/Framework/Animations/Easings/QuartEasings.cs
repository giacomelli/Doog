namespace Doog
{
	/// <summary>
	/// An InQuart easing: accelerating from zero velocity.
	/// </summary>
	public class InQuartEasing : IEasing
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
            return time * time * time * time;
		}
    }

	/// <summary>
	/// An OutQuart easing: decelerating to zero velocity.
	/// </summary>
	public class OutQuartEasing : IEasing
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
            return 1 - (--time) * time * time * time;
		}
	}

	/// <summary>
	/// An InQuart easing: acceleration until halfway, then deceleration.
	/// </summary>
	public class InOutQuartEasing : IEasing
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

            return time < .5 ? 8 * time * time * time * time : 1 - 8 * (--time) * time * time * time;
		}
	}
}
