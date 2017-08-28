using System.Collections.Generic;

namespace Snake.Framework
{
    /// <summary>
    /// Define an interface for components.
    /// </summary>
    public interface IComponent
    {
        bool Enabled { get; set; }
		string Tag { get; }
        IWorldContext Context { get; }

        void AddChild(IComponent component);
        IEnumerable<IComponent> GetChildren();
    }
}
