using System;
namespace Snake.Framework.Animations
{
    /// <summary>
    /// A linear easing.
    /// </summary>
    public class LinearEasing : IEasing
    {
        public float Calculate(float start, float target, float time)
        {
            return start + (target - start) * time;
        }
    }
}
