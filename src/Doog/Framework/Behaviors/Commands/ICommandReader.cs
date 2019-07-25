using System.Collections.Generic;

namespace Doog
{
    /// <summary>
    /// Defines an interface for a command reader.
    /// </summary>
    public interface ICommandReader
    {
        /// <summary>
        /// Read the commands of current frame.
        /// </summary>
        /// <returns>The commands read.</returns>
        IEnumerable<ICommand> Read();
    }
}
