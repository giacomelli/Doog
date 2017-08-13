using System;

namespace Snake.Framework.Animations
{
	/// <summary>
	/// Define an interface to ease that calculate the easing function.
	/// </summary>
	/// <remarks>
	/// http://easings.net
	/// </remarks>
	public interface IEase
    {
        float Calculate(float start, float target, float time);
    }
}
