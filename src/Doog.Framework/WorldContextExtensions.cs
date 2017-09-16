using System;
using Doog.Framework;

namespace Doog.Framework
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

		public static void OpenScene(this IWorldContext context, string name)
		{
            var sceneType =  Type.GetType(name) ?? context.GetType().Assembly.GetType(name);

            if (sceneType == null)
            {
                throw new ArgumentException("Could not find a scene with name '{0}'".With(name));
            }

			var scene = Activator.CreateInstance(sceneType, context) as IScene;

			context.OpenScene(scene);
		}

		public static IWorldContext OpenScene<TScene>(this IWorldContext context, Keys ifKeyIsDown)
		 where TScene : IScene
		{
			if (context.InputSystem.IsKeyDown(ifKeyIsDown))
			{
				context.OpenScene<TScene>();
			}

			return context;
		}
	}
}