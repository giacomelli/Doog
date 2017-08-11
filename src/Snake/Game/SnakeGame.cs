using System;
using Snake.Framework;
using Snake.Framework.Diagnostics;
using Snake.Framework.Graphics;
using Snake.Framework.Physics;
using Snake.Framework.Texts;
using Snake.Game.Scenes;

namespace Snake.Game
{
	public class SnakeGame : World, IDisposable
	{
		private bool disposed = false; // To detect redundant calls

		public SnakeGame(IGraphicSystem graphicSystem, ITextSystem textSystem)
			: base(graphicSystem, new PhysicSystem(), textSystem)
		{
		}

		public void Initialize()
		{
			if (Debug.Enabled)
			{
				AddComponent(new WorldStatsConsole(2, 2));
			}

			OpenScene(new ClassicModeLevelScene());
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!disposed)
			{
				if (disposing)
				{
				}

				disposed = true;
			}
		}

		void IDisposable.Dispose()
		{
			Dispose(true);
		}
	}
}