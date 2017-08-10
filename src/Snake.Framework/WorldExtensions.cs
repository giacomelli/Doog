using System;
namespace Snake.Framework
{
	public static class WorldExtensions
	{
		public static void RemoveComponentsWithoutTag(this IWorld world, string tag)
		{
			foreach (var c in world.Components.GetWithoutTag(tag))
			{
				world.RemoveComponent(c);
			}
		}

		public static void RemoveAllComponents(this IWorld world)
		{
			foreach (var c in world.Components)
			{
				world.RemoveComponent(c);
			}
		}
	}
}
