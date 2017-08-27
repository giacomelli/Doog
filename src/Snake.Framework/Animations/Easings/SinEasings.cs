using System;

namespace Snake.Framework.Animations
{
	/// <summary>
	/// An InSin easing: accelerating from zero velocity.
	/// </summary>
	public class InSinEasing : IEasing
    {
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
        public float Calculate(float time)
		{

            return (float) (1 + Math.Sin(Math.PI * time - Math.PI / 2)) / 2;
		}
	}
}
