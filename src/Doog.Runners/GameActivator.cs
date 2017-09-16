using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Doog.Framework;

namespace Doog.Runners
{
    public static class GameActivator
    {
        public static World CreateInstance(string[] args)
        {
			if (args.Length == 0)
			{
				throw new ArgumentException("Game assembly filename should be the first argument!");
			}

			var gameName = args[0];
			var gameAssembly = Assembly.LoadFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, gameName));
			var worldType = typeof(World);
			var gameType = gameAssembly.GetTypes().FirstOrDefault(t => worldType.IsAssignableFrom(t));

			if (gameType == null)
			{
				throw new InvalidOperationException("Could not find a class that inherits from Doog.Framework.World class.");
			}

            return (World)Activator.CreateInstance(gameType);
        }
    }
}
