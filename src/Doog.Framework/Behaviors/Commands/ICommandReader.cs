using System.Collections.Generic;

namespace Doog.Framework.Behaviors.Commands
{
    public interface ICommandReader
    {
        IEnumerable<ICommand> Read();
    }
}
