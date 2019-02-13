namespace Doog
{
	/// <summary>
	/// An InCubic easing: accelerating from zero velocity.
	/// </summary>
	public class InCubicEasing : IEasing
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
            return time * time * time;
		}
    }

	/// <summary>
	/// An OutCubic easing: decelerating to zero velocity.
	/// </summary>
	public class OutCubicEasing : IEasing
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
            return (--time) * time * time + 1;
		}
	}

	/// <summary>
	/// An InCubic easing: acceleration until halfway, then deceleration.
	/// </summary>
	public class InOutCubicEasing : IEasing
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
            
            return time < .5 ? 4 * time * time * time : (time - 1) * (2 * time - 2) * (2 * time - 2) + 1;
		}
	}
}
