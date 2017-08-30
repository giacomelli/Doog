using System;

namespace Snake.Framework
{
    /// <summary>
    /// World context extension methods.
    /// </summary>
	public static class WorldContextExtensions
	{
        public static void RemoveComponentsWithoutTag(this IWorldContext context, params string[] tags)
		{
            var toRemove = context.Components.GetWithoutTag(tags);

			foreach (var c in toRemove)
			{
				context.RemoveComponent(c);
			}
		}

        public static void RemoveAllComponents(this IWorldContext context)
		{
			foreach (var c in context.Components)
			{
				context.RemoveComponent(c);
			}
		}

        public static void OpenScene<TScene>(this IWorldContext context)
            where TScene : IScene
        {
            var scene = Activator.CreateInstance(typeof(TScene), context) as IScene;

            context.OpenScene(scene);
        }
	}
}