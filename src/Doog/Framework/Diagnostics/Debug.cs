using System;
using System.Linq;

namespace Doog
{
	/// <summary>
	/// Central point to debug stuffs.
	/// </summary>
	public static class Debug
	{
		static Debug()
		{
			var args = Environment.GetCommandLineArgs();

			Initialize(args);
		}

        internal static void Initialize(params string[] args)
        {
			// Debug mode can be enable by passing the parameter "debug-enabled" to the game executable.
			Enabled = args.Contains ("debug-enabled");
        }

		/// <summary>
		/// Gets a value indicating whether debug mode is enabled.
		/// </summary>
		/// <value><c>true</c> if enabled; otherwise, <c>false</c>.</value>
		public static bool Enabled { get; private set; }
	}
}
