using System;
using Snake.Framework;
using Snake.Framework.Diagnostics;
using Snake.Framework.Graphics;
using Snake.Framework.Logging;
using Snake.Framework.Physics;
using Snake.Framework.Texts;
using Snake.Game.Scenes;
using Snake.Framework.Input;

namespace Snake.Game
{
	public class SnakeGame : World, IDisposable
	{
		private bool disposed = false; // To detect redundant calls

		public override void Initialize(IGraphicSystem graphicSystem, IPhysicSystem physicSystem, ITextSystem textSystem, IInputSystem inputSystem)
		{
            base.Initialize(graphicSystem, physicSystem, textSystem, inputSystem);

			if (Debug.Enabled)
			{
				WorldStatsConsole.Create(2, 2, this);
			}

			this.OpenScene<ClassicModeLevelScene>();
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