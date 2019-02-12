namespace Doog
{
    /// <summary>
    /// Defines an interface for a command.
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Execute the command on specified target.
        /// </summary>
        /// <param name="target">The command target.</param>
        void Execute(object target);
    }
}
