using System;
using Snake.Framework.Graphics;

namespace Snake.Game
{
    public class SnakeGame : IDisposable
    {
		private const int MaxSnakes = 1;
        private IGraphicSystem graphicSystem;
        private Snake[] snakes;
        private bool gameOver;

        public void Initialize(IGraphicSystem graphicSystem)
        {
			this.graphicSystem = graphicSystem;
            this.graphicSystem.Initialize();

            snakes = new Snake[MaxSnakes];

			for (int i = 0; i < MaxSnakes; i++)
			{
				var snake = new Snake();
				snake.Initialize(0, 10 + i, 20, this.graphicSystem.Bounds);
            	snakes[i] = snake;
			}

            gameOver = false;
        }

        public bool GameOver
        {
            get
            {
                return gameOver;
            }
        }

        public void Update()
        {
            CheckGameOver();

            if (!gameOver)
            {
                for (int i = 0; i < MaxSnakes; i++)
                {
                    snakes[i].Update();
                }
            }           
        }

        public void Draw()
        {
		    for (int i = 0; i < MaxSnakes; i++)
            {
                snakes[i].Draw(graphicSystem);
            }

            graphicSystem.Render();
        }

        private bool disposed = false; // To detect redundant calls

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

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~SnakeGame() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        void IDisposable.Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }

        private void CheckGameOver()
        {
            if (!gameOver)
            {
                for (int i = 0; i < MaxSnakes; i++)
                {
                    var snake = snakes[i];

                    if(snake.IsOutOfBounds() || snake.IsOverlapped())
                    {
                        gameOver = true;
                        break;
                    }
                }                
            }
        }
    }
}