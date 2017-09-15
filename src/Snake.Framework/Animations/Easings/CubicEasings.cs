namespace Snake.Framework.Animations
{
	/// <summary>
	/// An InCubic easing: accelerating from zero velocity.
	/// </summary>
	public class InCubicEasing : IEasing
    {
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
        public float Calculate(float time)
		{
            
            return time < .5 ? 4 * time * time * time : (time - 1) * (2 * time - 2) * (2 * time - 2) + 1;
		}
	}
}
