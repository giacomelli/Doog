namespace Doog
{
	/// <summary>
	/// An InQuint easing: accelerating from zero velocity.
	/// </summary>
	public class InQuintEasing : IEasing
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
            return time * time * time * time * time;
		}
    }

	/// <summary>
	/// An OutQuint easing: decelerating to zero velocity.
	/// </summary>
	public class OutQuintEasing : IEasing
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
            return 1 + (--time) * time * time * time * time;
		}
	}

	/// <summary>
	/// An InOutQuint easing: acceleration until halfway, then deceleration.
	/// </summary>
	public class InOutQuintEasing : IEasing
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

            return time < .5 ? 16 * time * time * time * time * time : 1 + 16 * (--time) * time * time * time * time;
		}
	}
}
