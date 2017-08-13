using System;
namespace Snake.Framework.Animations
{
    public class LinearEase : IEase
    {
        public static readonly LinearEase Default = new LinearEase();

        private LinearEase()
        {
        }

        public float Calculate(float start, float target, float time)
        {
            return start + (target - start) * time;
        }
    }
}
