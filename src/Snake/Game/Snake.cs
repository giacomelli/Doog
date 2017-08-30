using System;
using Snake.Framework;
using Snake.Framework.Behaviors;
using Snake.Framework.Geometry;

namespace Snake.Game
{
    public sealed class Snake : ComponentBase, IUpdatable
    {
        public EventHandler FoodEaten;
        public EventHandler Died;

        private SnakeTile head;
        private SnakeTile tail;
        private int movingDirectionX;
        private int movingDirectionY;
        private Rectangle bounds;

        public bool Dead { get; set; }
        public int FoodsEatenCount { get; private set; }
        public float Speed { get; set; }

        public Snake(IWorldContext context)
            : base(context)
        {
            bounds = context.Bounds;
            Speed = 10f;
        }

        public void Initialize(int x, int y, int length)
        {
            movingDirectionX = 1;
            movingDirectionY = 0;
            Deploy(x, y, length);
        }

        public void Update()
        {
            // TODO: This user input should be deferred to a command pattern in the case we implement the multiplayer mode.
            // Besides, this pattern will allow us to easily send commands over network, create a demo mode and even a AI mode.
            HandleUserInput();

            Move();
        }

        private float lastPositionChangeTime = 0;

        private void Move()
        {
            var hpos = head.Transform.Position.Round();
            var newPosition = Point.Lerp(
                hpos,
                new Point(hpos.X + movingDirectionX, hpos.Y + movingDirectionY),
                (Context.Time.SinceSceneStart - lastPositionChangeTime) * Speed)
                .Round();

            if (newPosition != hpos)
            {
                tail.CopyPosition(head);
                tail.Transform.Position = newPosition;
                head.Next = tail;
                head = tail;
                tail = tail.Next;
                head.Next = null;

                lastPositionChangeTime = Context.Time.SinceSceneStart;
            }
        }

        private void Deploy(float x, float y, int length)
        {
            if (length < 3)
            {
                throw new ArgumentException("length must be greater than 2", "length");
            }

            x += bounds.Left;
            y += bounds.Top;

            tail = CreateTile(x++, y);
            tail.Next = CreateTile(x++, y);
            head = CreateTile(x++, y);
            tail.Next.Next = head;
            length -= 3;

            for (int i = 0; i < length; i++, x++)
            {
                head.Next = CreateTile(x, y);
                head = head.Next;
            }
        }

        private SnakeTile CreateTile(float x, float y)
        {

            var tile = new SnakeTile(
                x,
                y,
                Context,
                EatFood,
                OnDied,
                OnDied);

            return tile;
        }

        void EatFood()
        {
            var temp = tail;
            var next = tail.Next;

            tail = CreateTile(
                tail.Transform.Position.X + (tail.Transform.Position.X - next.Transform.Position.X),
                tail.Transform.Position.Y + (tail.Transform.Position.Y - next.Transform.Position.Y));

            tail.Next = temp;

            FoodsEatenCount++;

            if (FoodEaten != null)
            {
                FoodEaten(this, EventArgs.Empty);
            }

            Speed++;

            Log.Debug("{0} foods eaten. New speed {1}", FoodsEatenCount, Speed);
        }

        void OnDied()
        {
            Dead = true;

            if(Died != null) 
            {
                Died(this, EventArgs.Empty);    
            }
        }

        private void ChangeMovingDirection(int x, int y)
        {
			movingDirectionX = x;
			movingDirectionY = y;
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
                            ChangeMovingDirection(-1, 0);
                        }
                        break;

                    case ConsoleKey.UpArrow:
                    case ConsoleKey.K:
                        if (movingDirectionY == 0)
                        {
                            ChangeMovingDirection(0, -1);
                        }
                        break;

                    case ConsoleKey.RightArrow:
                    case ConsoleKey.L:
                        if (movingDirectionX == 0)
                        {
                            ChangeMovingDirection(1, 0);
                        }
                        break;

                    case ConsoleKey.DownArrow:
                    case ConsoleKey.J:
                        if (movingDirectionY == 0)
                        {
                            ChangeMovingDirection(0, 1);
                        }
                        break;
                }
            }
        }
    }
}
