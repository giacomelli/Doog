using System;
using Doog.Framework;
using Doog.Framework.Diagnostics;
using Doog.Framework.Geometry;
using Doog.Framework.Graphics;
using Doog.Framework.Logging;
using Doog.Framework.Physics;
using Doog.Framework.Texts;
using Snake.Game.Scenes;
using Doog.Framework.Input;
using Snake.Game.Scenes.Samples;

namespace Snake.Game
{
	public class SnakeGame : World, IDisposable
	{
		private bool disposed = false; // To detect redundant calls

		public override void Initialize(
            IGraphicSystem graphicSystem, 
            IPhysicSystem physicSystem, 
            ITextSystem textSystem,
            IInputSystem inputSystem,
            Action exitAction)
		{
            var b = graphicSystem.Bounds;
            Bounds = new Rectangle(b.Left + 5, b.Top + 10, b.Width - 10, b.Height -10);

            base.Initialize(graphicSystem, physicSystem, textSystem, inputSystem, exitAction);
         
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
