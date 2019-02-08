using System;
using System.Collections.Generic;

namespace Doog.Framework
{
    public interface IWorld : IWorldContext, IDisposable
    {
		IScene CurrentScene { get; }
        void Update(DateTime now);
        void Draw(); 
    }
}