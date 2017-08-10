using System;
using System.Collections.Generic;
using System.Linq;

namespace Snake.Framework
{
	public static class ComponentExtensions
	{
		public static IEnumerable<TComponent> Get<TComponent>(this IEnumerable<IComponent> components)
			where TComponent : IComponent
		{
			return components.Where(c => c.GetType() == typeof(TComponent)).Cast<TComponent>();
		}

		public static IEnumerable<IComponent> GetWithTag(this IEnumerable<IComponent> components, string tag)
		{
			return components.Where(c => c.Tag.Equals(tag, StringComparison.OrdinalIgnoreCase));
		}

		public static IEnumerable<IComponent> GetWithoutTag(this IEnumerable<IComponent> components, string tag)
		{
			return components.Where(c => !c.Tag.Equals(tag, StringComparison.OrdinalIgnoreCase));
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
