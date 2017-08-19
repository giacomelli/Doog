using System;

namespace Snake.Framework.Logging
{
    public class NullLogSystem : ILogSystem
    {
        public void Debug(string message, params object[] args)
        {
        }

        public void Error(string message, params object[] args)
        {
        }

        public void Info(string message, params object[] args)
        {
        }

        public void Warn(string message, params object[] args)
        {
        }
    }
}
