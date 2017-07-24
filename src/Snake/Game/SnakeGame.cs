using System;
using Snake.Geometry;

namespace Snake.Game
{
    public class SnakeGame : IDisposable
    {
        private SnakeTile head;
        private SnakeTile tail;
        private int movingSpeed;
        private int movingDirectionX;
        private int movingDirectionY;
        private IntRectangle bounds;
        private bool gameOver;

        public void Initialize()
        {
            Console.CursorVisible = false;
            movingSpeed = 1;
            movingDirectionX = movingSpeed;
            movingDirectionY = 0;
            bounds = new IntRectangle(0, 0, Console.WindowWidth, Console.WindowHeight);
            CreateSnake(10, 10, 20);
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
            HandleUserInput();
            Move();
        }

        public void Draw()
        {
            Console.Clear();
            SnakeTile temp = tail;
            while (temp != null)
            {
                Console.SetCursorPosition(temp.X, temp.Y);
                Console.Write('@');
                temp = temp.Next;
            }
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

        private void Move()
        {
            if (!gameOver)
            {
                tail.CopyPosition(head);
                tail.X += movingDirectionX;
                tail.Y += movingDirectionY;
                head.Next = tail;
                head = tail;
                tail = tail.Next;
                head.Next = null;
            }
        }

        private void CreateSnake(int x, int y, int length)
        {
            if (length < 3)
            {
                throw new ArgumentException("length must be greater than 2", "length");
            }

            x += bounds.Left;
            y += bounds.Top;

            tail = new SnakeTile(x++, y);
            tail.Next = new SnakeTile(x++, y);
            head = new SnakeTile(x++ + 2, y);
            tail.Next.Next = head;
            length -= 3;

            for (int i = 0; i < length; i++, x++)
            {
                head.Next = new SnakeTile(x, y);
                head = head.Next;
            }
        }

        private void CheckGameOver()
        {
            if (!gameOver)
            {
                gameOver = IsOutOfBounds() || IsOverlapped();
            }
        }

        private bool IsOutOfBounds()
        {
            return head.X <= bounds.Left ||
                    head.X >= bounds.Right ||
                    head.Y <= bounds.Top ||
                    head.Y >= bounds.Bottom;
        }

        private bool IsOverlapped()
        {
            SnakeTile temp = tail;
            while (temp != null && temp != head)
            {
                if (temp.X == head.X &&
                    temp.Y == head.Y)
                {
                    return true;
                }

                temp = temp.Next;
            }

            return false;
        }

        private void HandleUserInput()
        {
            if (Console.KeyAvailable)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.LeftArrow:
                    case ConsoleKey.H:
                        if (movingDirectionX == 0)
                        {
                            movingDirectionX = -movingSpeed;
                            movingDirectionY = 0;
                        }
                        break;

                    case ConsoleKey.UpArrow:
                    case ConsoleKey.K:
                        if (movingDirectionY == 0)
                        {
                            movingDirectionY = -movingSpeed;
                            movingDirectionX = 0;
                        }
                        break;

                    case ConsoleKey.RightArrow:
                    case ConsoleKey.L:
                        if (movingDirectionX == 0)
                        {
                            movingDirectionX = movingSpeed;
                            movingDirectionY = 0;
                        }
                        break;

                    case ConsoleKey.DownArrow:
                    case ConsoleKey.J:
                        if (movingDirectionY == 0)
                        {
                            movingDirectionY = movingSpeed;
                            movingDirectionX = 0;
                        }
                        break;
                }
            }
        }
    }
}