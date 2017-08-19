using System;

namespace Snake.Framework.Logging
{
    public abstract class LogSystemBase : ILogSystem, ISceneSurvivable
    {
		public virtual void Debug(string message, params object[] args)
		{
			Write("DEBUG", message, args);
		}

		public virtual void Error(string message, params object[] args)
		{
			Write("ERROR", message, args);
		}

		public virtual void Info(string message, params object[] args)
		{
			Write("INFO", message, args);
		}

		public virtual void Warn(string message, params object[] args)
		{
			Write("WARN", message, args);
		}

		public virtual bool CanSurvive(IScene fromScene, IScene toScene)
		{
			return true;
		}

        protected virtual void Write(string level, string message, params object[] args)
        {
            Write("{0} ({1:HH:mm:ss}): {2}".With(level, DateTime.Now, message.With(args)));   
        }

        protected abstract void Write(string fullMessage);

    }
}
