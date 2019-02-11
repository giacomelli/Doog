using System;
using Doog;
using Snake.Scenes;

namespace Snake
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
