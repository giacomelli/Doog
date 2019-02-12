using System;

namespace Doog
{
	/// <summary>
	/// An InSin easing: accelerating from zero velocity.
	/// </summary>
	public class InSinEasing : IEasing
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
            return (float) (1 + Math.Sin(Math.PI / 2 * time - Math.PI / 2));
		}
    }

	/// <summary>
	/// An OutSin easing: decelerating to zero velocity.
	/// </summary>
	public class OutSinEasing : IEasing
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
            return (float)Math.Sin(Math.PI / 2 * time);
		}
	}

	/// <summary>
	/// An InSin easing: acceleration until halfway, then deceleration.
	/// </summary>
	public class InOutSinEasing : IEasing
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

            return (float) (1 + Math.Sin(Math.PI * time - Math.PI / 2)) / 2;
		}
	}
}
