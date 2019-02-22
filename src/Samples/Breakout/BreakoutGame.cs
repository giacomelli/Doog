using System;
using Doog;
using Breakout.Scenes;

namespace Breakout
{
    public class BreakoutGame : World, IDisposable
	{
		private bool disposed = false; // To detect redundant calls

		public override void Initialize(
            IGraphicSystem graphicSystem, 
            IPhysicSystem physicSystem, 
            ITextSystem textSystem,
            IInputSystem inputSystem,
            Action exitAction)
		{
            base.Initialize(graphicSystem, physicSystem, textSystem, inputSystem, exitAction);
        
			this.OpenScene<ClassicModeLevelScene>();
		}

		protected override void Dispose(bool disposing)
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
