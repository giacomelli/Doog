namespace Doog
{
    /// <summary>
    /// An implementation of ILogSystem using null pattern.
    /// </summary>
    public class NullLogSystem : ILogSystem
    {
        /// <summary>
        /// Write a debug message.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="args">Arguments.</param>
        public void Debug(string message, params object[] args)
        {
            // Null object pattern.
        }

        /// <summary>
        /// Write an error message.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="args">Arguments.</param>
        public void Error(string message, params object[] args)
        {
            // Null object pattern.
        }

        /// <summary>
        /// Write an information message.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="args">Arguments.</param>
        public void Info(string message, params object[] args)
        {
            // Null object pattern.
        }

        /// <summary>
        /// Write a warning message.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="args">Arguments.</param>
        public void Warn(string message, params object[] args)
        {
            // Null object pattern.
        }
    }
}