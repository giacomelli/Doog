namespace Doog
{
    /// <summary>
    /// Base class for commands.
    /// </summary>
    public abstract class CommandBase<TTarget> : ICommand
    {
        /// <summary>
        /// Execute the command on specified target.
        /// </summary>
        /// <param name="target">The command target.</param>
        public void Execute(object target)
        {
            Execute((TTarget)target);
        }

        /// <summary>
        /// Execute the command on specified target.
        /// </summary>
        /// <param name="target">The command target.</param>
        protected abstract void Execute(TTarget target);
    }
}
