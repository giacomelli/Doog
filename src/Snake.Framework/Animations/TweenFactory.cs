﻿using System;
using System.Collections.Generic;

namespace Snake.Framework.Animations
{
    public static class TweenFactory
    {
        private static Dictionary<string, ITween> cache = new Dictionary<string, ITween>();

        public static void Reset()
        {
            cache = new Dictionary<string, ITween>();
        }

        public static TTween Get<TTween>(string id, Func<TTween> createNew)
            where TTween : ITween
        {
            if (!cache.ContainsKey(id))
            {
                cache.Add(id, createNew());
            }

            var tween = cache[id];

            if(tween.State == TweenState.Paused)
            {
                tween.Resume();
            }

            return (TTween) cache[id];
        }
    }
}
