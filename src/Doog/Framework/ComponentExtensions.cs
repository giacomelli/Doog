using System.Collections.Generic;
using System.Linq;

namespace Doog
{
    /// <summary>
    /// Component extension methods.
    /// </summary>
    public static partial class ComponentExtensions
    {
        public static IEnumerable<TComponent> Get<TComponent>(this IEnumerable<IComponent> components)
            where TComponent : IComponent
        {
            return components.Where(c => c is TComponent).Cast<TComponent>();
        }

        public static TComponent GetOne<TComponent>(this IEnumerable<IComponent> components)
            where TComponent : IComponent
        {
            return (TComponent)components.FirstOrDefault(c => c is TComponent);
        }

        public static IEnumerable<IComponent> GetWithTag(this IEnumerable<IComponent> components, params string[] tags)
        {
            return components.Where(c => tags.Contains(c.Tag));
        }

        public static IEnumerable<IComponent> GetWithoutTag(this IEnumerable<IComponent> components, params string[] tags)
        {
            return components.Where(c => !tags.Contains(c.Tag));
        }

        public static IEnumerable<IComponent> EnableAll(this IEnumerable<IComponent> components)
        {
            foreach (var c in components)
            {
                c.Enabled = true;
            }

            return components;
        }

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