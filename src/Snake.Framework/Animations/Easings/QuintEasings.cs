namespace Snake.Framework.Animations
{
	/// <summary>
	/// An InQuint easing: accelerating from zero velocity.
	/// </summary>
	public class InQuintEasing : IEasing
    {
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
        public float Calculate(float time)
		{

            return time < .5 ? 16 * time * time * time * time * time : 1 + 16 * (--time) * time * time * time * time;
		}
	}
}
