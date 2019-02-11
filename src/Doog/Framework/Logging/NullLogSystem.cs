namespace Doog
{
    /// <summary>
    /// An implementation of ILogSystem using null pattern.
    /// </summary>
    public class NullLogSystem : ILogSystem
    {
        public void Debug(string message, params object[] args)
        {
            // Null object pattern.
        }

        public void Error(string message, params object[] args)
        {
            // Null object pattern.
        }

        public void Info(string message, params object[] args)
        {
            // Null object pattern.
        }

        public void Warn(string message, params object[] args)
        {
            // Null object pattern.
        }
    }
}
