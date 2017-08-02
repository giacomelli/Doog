using System;
using Snake.Geometry;

namespace Snake.Game
{
    public class SnakeGame : IDisposable
    {
        private Snake snake;
        private bool gameOver;

        public void Initialize()
        {
            Console.CursorVisible = false;
            snake = new Snake();
            snake.Initialize();
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
                snake.Update();
            }           
        }

        public void Draw()
        {
            Console.Clear();
            snake.Draw();
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
                gameOver = snake.IsOutOfBounds() || snake.IsOverlapped();
            }
        }
    }
}