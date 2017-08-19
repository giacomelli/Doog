namespace Snake.Framework.Animations
{
	/// <summary>
	/// An InBack easing: http://easings.net/#easeInBack
	/// </summary>
	public class InBackEasing : IEasing
    {
        public float Calculate(float start, float target, float time)
        {
            return (target - start) * time * time * ((1.70158f + 1f) * time - 1.70158f) + start;
        }
    }
}
