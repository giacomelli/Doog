using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Snake.Framework.Animations
{
    public static class AnimationExtensions
    {
        public static Animation Animate(
            this IComponent owner,
            string name,
            ITween tween,
            IWorldContext context)
        {
            var id = new AnimationId(owner, name);

            AbortAnimation(id);

            tween.Play();
            owner.AddChild(tween, context);

            var animation = new Animation(id, tween);
            AnimationCache.Add(animation);

            return animation;
        }

        public static Animation Loop(this Animation animation)
        {
            AnimationCache.Get(animation.Id).Tween.Loop();

            return animation;
        }

		public static Animation PingPong(this Animation animation)
		{
			AnimationCache.Get(animation.Id).Tween.PingPong();

			return animation;
		}

        private static void AbortAnimation(AnimationId id)
        {
            if (AnimationCache.Contains(id))
            {
                AnimationCache.Get(id).Tween.Stop();
                AnimationCache.Remove(id);
            }
        }
    }
}
