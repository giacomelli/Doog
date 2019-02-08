namespace Doog
{
	/// <summary>
	/// An InQuad easing: accelerating from zero velocity.
	/// </summary>
	public class InQuadEasing : IEasing
	{
		public float Calculate(float time)
		{
			return time * time;
		}
	}

	/// <summary>
	/// An OutQuad easing: decelerating to zero velocity.
	/// </summary>
	public class OutQuadEasing : IEasing
    {
        public float Calculate(float time)
        {
            return time * (2 - time);
        }
    }

	/// <summary>
	/// An InOutQuad easing: acceleration until halfway, then deceleration.
	/// </summary>
	public class InOutQuadEasing : IEasing
	{
		public float Calculate(float time)
		{
			return time < .5 ? 2 * time * time : -1 + (4 - 2 * time) * time;
		}
	}
}
