using System.Collections.Generic;
using Snake.Framework.Physics;

namespace Snake.Framework
{
    public interface IWorldContext
    {
        IList<IComponent> Components { get; }
        void AddComponent(IComponent component);        
        void RemoveComponent(IComponent component);

		IPhysicSystem PhysicSystem { get; }
    }
}