using System;

namespace Snake.Game
{
    public class SnakeGame : IDisposable
    {
        private SnakeTile head;
        private SnakeTile tail;
        private int movingSpeed;
        private int movingDirectionX;
        private int movingDirectionY;

        public void Initialize()
        {
            Console.CursorVisible = false;
            movingSpeed = 1;
            movingDirectionX = movingSpeed;
            movingDirectionY = 0;

            CreateSnake(10, 10, 20);
        }

        public void Update()
        {
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

        public void Dispose()
        {
        }

        private void Move()
        {
            tail.CopyPosition(head);
            tail.X += movingDirectionX;
            tail.Y += movingDirectionY;
            head.Next = tail;
            head = tail;
            tail = tail.Next;
            head.Next = null;
        }

        private void CreateSnake(int x, int y, int length)
        {
            if (length < 3)
            {
                throw new ArgumentException("length must be greater than 2", "length");
            }

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