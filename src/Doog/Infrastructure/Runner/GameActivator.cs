﻿using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Doog
{
    public static class GameActivator
    {
        public static World CreateInstance(Assembly gameAssembly, string[] args)
        {			
			var worldType = typeof(World);
			var gameType = gameAssembly.GetTypes().FirstOrDefault(t => worldType.IsAssignableFrom(t));

			if (gameType == null)
			{
				throw new InvalidOperationException("Could not find a class that inherits from Doog.World class.");
			}

            return (World)Activator.CreateInstance(gameType);
        }

        public static void Config(World game, string[] args)
        {
			if (Debug.Enabled)
			{
				WorldStatsConsole.Create(game.Bounds.Left + 2, game.Bounds.Top + 2, game);
			}
             
			if (args.Contains("file-log"))
			{
				game.LogSystem = new FileLogSystem(
					Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log.txt"),
					game);
			}
			else if (args.Contains("ingame-log"))
			{
				var b = game.Bounds;
				game.LogSystem = new InGameLogSystem(
					new Rectangle(b.Left + 1, b.Bottom * 0.8f, b.Width - 2, (b.Height * 0.2f) - 1),
					game);
			}
        }
    }
}