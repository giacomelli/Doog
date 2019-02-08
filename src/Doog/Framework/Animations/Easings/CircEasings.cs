using System;

namespace Doog
{
    /// <summary>
    /// An InCirc easing.
    /// </summary>
    public class InCircEasing : IEasing
    {
        public float Calculate(float time)
        {
            return 1 - (float)Math.Sqrt(1 - (time * time));
        }
    }

    /// <summary>
    /// An OutCirc easing.
    /// </summary>
    public class OutCircEasing : IEasing
    {
        public float Calculate(float time)
        {
            return (float)Math.Sqrt((2 - time) * time);
        }
    }

    /// <summary>
    /// An InOutCirc easing.
    /// </summary>
    public class InOutCircEasing : IEasing
    {
        public float Calculate(float time)
        {
			if (time < 0.5f)
			{
				return 0.5f * (1 - (float)Math.Sqrt(1 - 4 * (time * time)));
			}
			else
			{
				return 0.5f * ((float)Math.Sqrt(-((2 * time) - 3) * ((2 * time) - 1)) + 1);
			}
        }
    }
}
