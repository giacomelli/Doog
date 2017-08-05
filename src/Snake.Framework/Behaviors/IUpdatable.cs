using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snake.Framework.Behaviors
{
    public interface IUpdatable : IComponent
    {
        void Update(IWorldContext context);
    }
}
