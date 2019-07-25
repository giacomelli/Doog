using System;

namespace Doog
{
    /// <summary>
    /// Random extension methods.
    /// </summary>
    public static class RandomExtensions
    {
		private static readonly Random _rnd = new Random(DateTime.UtcNow.Millisecond);

        /// <summary>
        /// Gets a random float value between 0 and the specified max value.
        /// </summary>
        /// <param name="maxValue">The maximum value.</param>
        /// <returns>The random float.</returns>
        public static float Rand(this float maxValue)
        {
            return maxValue * (float)_rnd.NextDouble();
        }

        /// <summary>
        /// Gets a random float value between min and max values.
        /// </summary>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <returns>The random float.</returns>
        public static float Rand(this float maxValue, float minValue)
		{
            return minValue +  (maxValue - minValue) * (float)_rnd.NextDouble();
			
		}

        /// <summary>
        /// Gets a random item from the specified items.
        /// </summary>
        /// <typeparam name="TItem">The type of the item.</typeparam>
        /// <param name="items">The items.</param>
        /// <returns>The random item.</returns>
        public static TItem Rand<TItem>(this TItem[] items)
        {
            return items[_rnd.Next(0, items.Length)];
        }
	}
}