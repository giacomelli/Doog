namespace Doog
{
    /// <summary>
    /// Define an interface to easing function.
    /// </summary>
    /// <remarks>
    /// http://easings.net
    /// </remarks>
    public interface IEasing
    {
        /// <summary>
        /// Calculate the easing to the specified time.
        /// </summary>
        /// <returns>The easing to the time.</returns>
        /// <param name="time">Time.</param>
        float Calculate(float time);
    }
}
