using System;

namespace Doog
{
	/// <summary>
	/// An InBack easing
	/// </summary>
	public class InBackEasing : IEasing
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
			return time * time * time - time * (float) Math.Sin(time * Math.PI);
		}
	}

	/// <summary>
	/// An OutBack easing.
	/// </summary>
	public class OutBackEasing : IEasing
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
			float f = (1 - time);
			return 1 - (f * f * f - f * (float)Math.Sin(f * Math.PI));
		}
	}

	/// <summary>
	/// An InOutBack easing.
	/// </summary>
	public class InOutBackEasing : IEasing
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
			if (time < 0.5f)
			{
				float f = 2 * time;
				return 0.5f * (f * f * f - f * (float)Math.Sin(f * Math.PI));
			}
			else
			{
				float f = (1 - (2 * time - 1));
				return 0.5f * (1 - (f * f * f - f * (float)Math.Sin(f * Math.PI))) + 0.5f;
			}
		}
	}
}
