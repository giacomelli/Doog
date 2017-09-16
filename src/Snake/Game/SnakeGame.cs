using System;
using Doog.Framework;
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
