using System;
using System.Collections.Generic;

namespace Doog
{
    public interface IWorld : IWorldContext, IDisposable
    {
		IScene CurrentScene { get; }
        void Update(DateTime now);
        void Draw(); 
    }
}