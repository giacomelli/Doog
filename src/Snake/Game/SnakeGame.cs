using System;
using Snake.Framework;
using Snake.Framework.Diagnostics;
using Snake.Framework.Geometry;
using Snake.Framework.Graphics;
using Snake.Framework.Logging;
using Snake.Framework.Physics;
using Snake.Framework.Texts;
using Snake.Game.Scenes;

namespace Snake.Game
{
	public class SnakeGame : World, IDisposable
	{
		private bool disposed = false; // To detect redundant calls

		public override void Initialize(
            IGraphicSystem graphicSystem, 
            IPhysicSystem physicSystem, 
            ITextSystem textSystem,
            Action exitAction)
		{
			Bounds = graphicSystem.Bounds + new Rectangle(5, 10, -5, 0);

            base.Initialize(graphicSystem, physicSystem, textSystem, exitAction);
         
			if (Debug.Enabled)
			{
				WorldStatsConsole.Create(Bounds.Left + 2, Bounds.Top + 2, this);
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