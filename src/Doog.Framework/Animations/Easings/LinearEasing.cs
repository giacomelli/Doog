using System;
namespace Doog.Framework.Animations
{
	/// <summary>
	/// A linear easing with no easing and no acceleration.
	/// </summary>
	public class LinearEasing : IEasing
    {
        public float Calculate(float time)
        {
            return time;
        }
    }
}
