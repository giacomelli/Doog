using System.Collections.Generic;

namespace Snake.Framework
{
    public interface IWorld : IWorldContext
    {
        void Update();
        void Draw(); 
    }
}