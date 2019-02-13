using System;

namespace Doog
{
    /// <summary>
    /// World context extension methods.
    /// </summary>
	public static class WorldContextExtensions
	{
        /// <summary>
        /// Removes the components without tag.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="tags">The tags.</param>
        public static void RemoveComponentsWithoutTag(this IWorldContext context, params string[] tags)
		{
            var toRemove = context.Components.GetWithoutTag(tags);

			foreach (var c in toRemove)
			{
				context.RemoveComponent(c);
			}
		}

        /// <summary>
        /// Removes all components.
        /// </summary>
        /// <param name="context">The context.</param>
        public static void RemoveAllComponents(this IWorldContext context)
		{
			foreach (var c in context.Components)
			{
				context.RemoveComponent(c);
			}
		}

        /// <summary>
        /// Opens the scene.
        /// </summary>
        /// <typeparam name="TScene">The type of the scene.</typeparam>
        /// <param name="context">The context.</param>
        public static void OpenScene<TScene>(this IWorldContext context)
            where TScene : IScene
        {
            var scene = Activator.CreateInstance(typeof(TScene), context) as IScene;

            context.OpenScene(scene);
        }

        /// <summary>
        /// Opens the scene with the specified name.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="name">The scene name.</param>
        /// <exception cref="ArgumentException">Could not find a scene with name '{0}'".With(name)</exception>
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

        /// <summary>
        /// Opens the scene if specified key is down.
        /// </summary>
        /// <typeparam name="TScene">The type of the scene.</typeparam>
        /// <param name="context">The context.</param>
        /// <param name="ifKeyIsDown">If key is down.</param>
        /// <returns></returns>
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