using System.Collections.Generic;

namespace Doog
{
    public interface ICommandReader
    {
        IEnumerable<ICommand> Read();
    }
}
