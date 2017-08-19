using System.Collections.Generic;

namespace Snake.Framework.Animations
{
    /// <summary>
    /// An animation cache used by animation extension methods to control animation life cycle.
    /// </summary>
    internal static class AnimationCache
    {
        private static readonly Dictionary<AnimationId, IAnimation> animations;

		static AnimationCache()
		{
			animations = new Dictionary<AnimationId, IAnimation>();
		}

        public static void Add(IAnimation animation)
        {
            animations.Add(animation.Id, animation);
        }

        public static IAnimation<TComponent> Get<TComponent>(AnimationId id)
            where TComponent : IComponent
        {
            return (IAnimation<TComponent>) animations[id];
        }

		public static IAnimation Get(AnimationId id)
		{
			return animations[id];
		}

        public static bool Contains(AnimationId id)
        {
            return animations.ContainsKey(id);
        }

		public static void Remove(AnimationId id)
		{
            if (animations.ContainsKey(id))
            {
                animations.Remove(id);
            }
		}
	}
}
