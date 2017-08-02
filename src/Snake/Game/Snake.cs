using System;
using Snake.Geometry;

namespace Snake.Game
{    
    public class Snake
    {
        private SnakeTile head;
        private SnakeTile tail;
        private int movingSpeed;
        private int movingDirectionX;
        private int movingDirectionY;
        private IntRectangle bounds;

        public void Initialize()
        {
            movingSpeed = 1;
            movingDirectionX = movingSpeed;
            movingDirectionY = 0;
            bounds = new IntRectangle(0, 0, Console.WindowWidth, Console.WindowHeight);
            Deploy(10, 10, 20);
        }
      
        public void Update()
        {
            // TODO: This user input should be deferred to a command pattern in the case we implement the multiplayer mode.
            // Besides, this pattern will allow us to easy send commands over network, create a demo mode and even a AI mode.
            HandleUserInput();

            Move();
        }

        public void Draw()
        {            
            SnakeTile temp = tail;

            while (temp != null)
            {                
                Console.SetCursorPosition(temp.X, temp.Y);
                Console.Write('@');
                temp = temp.Next;
            }
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

        private void Deploy(int x, int y, int length)
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

        public bool IsOutOfBounds()
        {
            return head.X <= bounds.Left ||
                    head.X >= bounds.Right ||
                    head.Y <= bounds.Top ||
                    head.Y >= bounds.Bottom;
        }

        public bool IsOverlapped()
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