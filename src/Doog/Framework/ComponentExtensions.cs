using System.Collections.Generic;
using System.Linq;

namespace Doog
{
    /// <summary>
    /// Component extension methods.
    /// </summary>
    public static partial class ComponentExtensions
    {
        /// <summary>
        /// Gets all components of the specified type.
        /// </summary>
        /// <returns>The components.</returns>
        /// <param name="components">The source components.</param>
        /// <typeparam name="TComponent">The component type.</typeparam>
        public static IEnumerable<TComponent> Get<TComponent>(this IEnumerable<IComponent> components)
            where TComponent : IComponent
        {
            return components.Where(c => c is TComponent).Cast<TComponent>();
        }

        /// <summary>
        /// Gets first component of the specified type.
        /// </summary>
        /// <returns>The component..</returns>
        /// <param name="components">Components.</param>
        /// <typeparam name="TComponent">The component type.</typeparam>
        public static TComponent GetOne<TComponent>(this IEnumerable<IComponent> components)
            where TComponent : IComponent
        {
            return (TComponent)components.FirstOrDefault(c => c is TComponent);
        }

        /// <summary>
        /// Gets all components with any of the specified tags.
        /// </summary>
        /// <returns>The components.</returns>
        /// <param name="components">Components.</param>
        /// <param name="tags">The tags.</param>
        public static IEnumerable<IComponent> GetWithTag(this IEnumerable<IComponent> components, params string[] tags)
        {
            return components.Where(c => tags.Contains(c.Tag));
        }

        /// <summary>
        /// Gets all components without the specified tag.
        /// </summary>
        /// <returns>The components.</returns>
        /// <param name="components">Components.</param>
        /// <param name="tags">The tags.</param>
        public static IEnumerable<IComponent> GetWithoutTag(this IEnumerable<IComponent> components, params string[] tags)
        {
            return components.Where(c => !tags.Contains(c.Tag));
        }

        /// <summary>
        /// Enables all the components.
        /// </summary>
        /// <returns>The components.</returns>
        /// <param name="components">The components.</param>
        public static IEnumerable<IComponent> EnableAll(this IEnumerable<IComponent> components)
        {
            foreach (var c in components)
            {
                c.Enabled = true;
            }

            return components;
        }

        /// <summary>
        /// Disables all the components.
        /// </summary>
        /// <returns>The components.</returns>
        /// <param name="components">The components.</param>
        public static IEnumerable<IComponent> DisableAll(this IEnumerable<IComponent> components)
        {
            foreach (var c in components)
            {
                c.Enabled = false;
            }

            return components;
        }
    }
}