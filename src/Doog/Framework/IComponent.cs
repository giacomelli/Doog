using System.Collections.Generic;

namespace Doog
{
    /// <summary>
    /// Define an interface for components.
    /// </summary>
    public interface IComponent
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:Doog.IComponent"/> is enabled.
        /// </summary>
        /// <value><c>true</c> if enabled; otherwise, <c>false</c>.</value>
        bool Enabled { get; set; }

        /// <summary>
        /// Gets the tag.
        /// </summary>
        /// <value>The tag.</value>
		string Tag { get; }

        /// <summary>
        /// Gets the world context.
        /// </summary>
        /// <value>The context.</value>
        IWorldContext Context { get; }

        /// <summary>
        /// Adds the child to the component.
        /// </summary>
        /// <param name="component">The child component.</param>
        void AddChild(IComponent component);

        /// <summary>
        /// Gets the children components.
        /// </summary>
        /// <returns>The children.</returns>
        IEnumerable<IComponent> GetChildren();

        /// <summary>
        /// Removes the component from the its context.
        /// </summary>
		void Remove();
    }
}
