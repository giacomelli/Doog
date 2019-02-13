namespace Doog
{
    /// <summary>
    /// Defines an interface for a log system.
    /// </summary>
    public interface ILogSystem
    {
        /// <summary>
        /// Write a debug message.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="args">Arguments.</param>
        void Debug(string message, params object[] args);

        /// <summary>
        /// Write an information message.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="args">Arguments.</param>
        void Info(string message, params object[] args);

        /// <summary>
        /// Write a warning message.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="args">Arguments.</param>
        void Warn(string message, params object[] args);

        /// <summary>
        /// Write an error message.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="args">Arguments.</param>
        void Error(string message, params object[] args);
    }
}
