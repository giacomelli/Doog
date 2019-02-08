using System;

namespace Doog
{

    /// <summary>
    /// Float extension methods.
    /// </summary>
    public static class FloatExtensions
    {
        /// <summary>
        /// Compare current float with the other float using the float.Epsilon has acceptable difference.
        /// </summary>
        /// <returns><c>true</c>, if to was equalsed, <c>false</c> otherwise.</returns>
        /// <param name="current">The current float.</param>
        /// <param name="other">The other float,</param>
        public static bool EqualsTo(this float current, float other)
        {
            return Math.Abs(current - other) < float.Epsilon;
        }
    }
}