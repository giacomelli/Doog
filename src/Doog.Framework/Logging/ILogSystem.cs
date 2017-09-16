using System;

namespace Doog.Framework.Logging
{
    public interface ILogSystem
    {
        void Debug(string message, params object[] args);
        void Info(string message, params object[] args);
        void Warn(string message, params object[] args);
        void Error(string message, params object[] args);
    }
}
