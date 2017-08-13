using System;
using System.Collections.Generic;

namespace Snake.Framework.Animations
{
    public static class AnimationCache
    {
        private static readonly Dictionary<AnimationId, Animation> animations;

		static AnimationCache()
		{
			animations = new Dictionary<AnimationId, Animation>();
		}

        public static void Add(Animation animation)
        {
            animations.Add(animation.Id, animation);
        }

        public static Animation Get(AnimationId id)
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
