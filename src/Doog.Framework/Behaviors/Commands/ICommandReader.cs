using System.Collections.Generic;

namespace Doog.Framework
{
    public interface ICommandReader
    {
        IEnumerable<ICommand> Read();
    }
}
