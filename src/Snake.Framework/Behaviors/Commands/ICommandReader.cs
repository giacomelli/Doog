using System.Collections.Generic;

namespace Snake.Framework.Behaviors.Commands
{
    public interface ICommandReader
    {
        IEnumerable<ICommand> Read();
    }
}
