namespace Doog
{
    /// <summary>
    /// A base class for log system.
    /// </summary>
    /// <seealso cref="Doog.ILogSystem" />
    /// <seealso cref="Doog.ISceneSurvivable" />
    public abstract class LogSystemBase : ILogSystem, ISceneSurvivable
    {
        private readonly IWorldContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="LogSystemBase"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        protected LogSystemBase(IWorldContext context)
        {
            this._context = context;    
        }

        /// <summary>
        /// Write a debug message.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="args">Arguments.</param>
        public virtual void Debug(string message, params object[] args)
		{
			Write("DEBUG", message, args);
		}

        /// <summary>
        /// Write an error message.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="args">Arguments.</param>
        public virtual void Error(string message, params object[] args)
		{
			Write("ERROR", message, args);
		}

        /// <summary>
        /// Write an information message.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="args">Arguments.</param>
        public virtual void Info(string message, params object[] args)
		{
			Write("INFO", message, args);
		}

        /// <summary>
        /// Write a warning message.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="args">Arguments.</param>
        public virtual void Warn(string message, params object[] args)
		{
			Write("WARN", message, args);
		}
        
		bool ISceneSurvivable.CanSurvive(IScene fromScene, IScene toScene)
		{
			return true;
		}

        /// <summary>
        /// Writes the message.
        /// </summary>
        /// <param name="level">The level.</param>
        /// <param name="message">The message.</param>
        /// <param name="args">The arguments.</param>
        protected virtual void Write(string level, string message, params object[] args)
        {
            Write("{0} ({1:HH:mm:ss}): {2}".With(level, _context.Time.Now, message.With(args)));   
        }

        /// <summary>
        /// Writes the specified full message.
        /// </summary>
        /// <param name="fullMessage">The full message.</param>
        protected abstract void Write(string fullMessage);
    }
}
