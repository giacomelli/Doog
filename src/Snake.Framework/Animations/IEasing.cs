using System;

namespace Snake.Framework.Animations
{
	/// <summary>
	/// Define an interface to easing function.
	/// </summary>
	/// <remarks>
	/// http://easings.net
	/// </remarks>
	public interface IEasing
    {
        float Calculate(float start, float target, float time);
    }
}
