using System;

namespace Doog
{
    /// <summary>
    /// An InBounce easing.
    /// </summary>
    public class InBounceEasing : IEasing
    {
        internal static float GetBounce(float t)
        {
			if (t < 4 / 11.0f)
			{
				return (121 * t * t) / 16.0f;
			}
			else if (t < 8 / 11.0f)
			{
				return (363 / 40.0f * t * t) - (99 / 10.0f * t) + 17 / 5.0f;
			}
			else if (t < 9 / 10.0f)
			{
				return (4356 / 361.0f * t * t) - (35442 / 1805.0f * t) + 16061 / 1805.0f;
			}
			else
			{
				return (54 / 5.0f * t * t) - (513 / 25.0f * t) + 268 / 25.0f;
			}
        }

        public float Calculate(float time)
        {
            return 1 - GetBounce(1 - time);
        }
    }

	/// <summary>
	/// An OutBounce easing.
	/// </summary>
	public class OutBounceEasing : IEasing
    {
        public float Calculate(float time)
        {
            return InBounceEasing.GetBounce(time);
        }
    }

	/// <summary>
	/// An InOutBounce easing.
	/// </summary>
	public class InOutBounceEasing : IEasing
	{
        public float Calculate(float time)
		{
			if (time < 0.5f)
			{
				return 0.5f * (1 - InBounceEasing.GetBounce(1 - time * 2));
			}
			else
			{
				return 0.5f * InBounceEasing.GetBounce(time * 2 - 1) + 0.5f;
			}
		}
	}
}
