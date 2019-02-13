using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Doog
{
    /// <summary>
    /// Responsible for instanciate the World's implementation in the game assembly and configure the environment based on the passed args.
    /// </summary>
    public static class GameActivator
    {
        /// <summary>
        /// Creates the World implementation instance from game assembly.
        /// </summary>
        /// <param name="gameAssembly">The game assembly.</param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">Could not find a class that inherits from Doog.World class.</exception>
        public static World CreateInstance(Assembly gameAssembly)
        {			
			var worldType = typeof(World);
			var gameType = gameAssembly.GetTypes().FirstOrDefault(worldType.IsAssignableFrom);

			if (gameType == null)
			{
				throw new InvalidOperationException("Could not find a class that inherits from Doog.World class.");
			}

            return (World)Activator.CreateInstance(gameType);
        }

        /// <summary>
        /// Configure the game based on specified args.
        /// </summary>
        /// <param name="game">The game.</param>
        /// <param name="args">The arguments.</param>
        public static void Config(World game, string[] args)
        {
            Debug.Initialize(args);

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
