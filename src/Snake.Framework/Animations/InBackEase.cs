namespace Snake.Framework.Animations
{
    public class InBackEase : IEase
    {
		public static readonly InBackEase Default = new InBackEase();

		private InBackEase()
		{
		}

        public float Calculate(float start, float target, float time)
        {
            return (target - start) * time * time * ((1.70158f + 1f) * time - 1.70158f) + start;
        }
    }
}
