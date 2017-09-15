using System;

namespace Snake.Framework
{
    public static class RandomExtensions
    {
		private static readonly System.Random rnd = new System.Random(DateTime.UtcNow.Millisecond);

        public static float Rand(this float maxValue)
        {
            return maxValue * (float)rnd.NextDouble();
;       }

        public static float Rand(this float maxValue, float minValue)
		{
            return minValue +  (maxValue - minValue) * (float)rnd.NextDouble();
			
		}
        
        public static TItem Rand<TItem>(this TItem[] items)
        {
            return items[rnd.Next(0, items.Length)];
        }
	}
}
