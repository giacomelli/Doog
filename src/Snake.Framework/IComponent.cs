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

        // TODO: maybe IComponent should hold a property to his own IWorldContext to avoid
        // the need to pass the worldcontext everywhere.
        void AddChild(IComponent component, IWorldContext worldContext);
        IEnumerable<IComponent> GetChildren();
    }
}
