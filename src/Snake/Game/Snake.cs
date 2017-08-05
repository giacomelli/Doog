using System;
using Snake.Framework;
using Snake.Framework.Behaviors;
using Snake.Framework.Geometry;
using Snake.Framework.Graphics;

namespace Snake.Game
{
	public class Snake : ComponentBase, IUpdatable
	{
		void HandleAction()
		{

		}

		private SnakeTile head;
		private SnakeTile tail;
		private int movingSpeed;
		private int movingDirectionX;
		private int movingDirectionY;
		private IntRectangle bounds;
		private IWorldContext worldContext;

		public bool Dead { get; set; }

		public void Initialize(int x, int y, int length, IntRectangle bounds, IWorldContext worldContext)
		{
			movingSpeed = 1;
			movingDirectionX = movingSpeed;
			movingDirectionY = 0;
			this.bounds = bounds;
			this.worldContext = worldContext;
			Deploy(x, y, length);
		}

		public void Update(IWorldContext context)
		{
			// TODO: This user input should be deferred to a command pattern in the case we implement the multiplayer mode.
			// Besides, this pattern will allow us to easily send commands over network, create a demo mode and even a AI mode.
			HandleUserInput();

			Move();
		}

		private void Move()
		{
			tail.CopyPosition(head);
			tail.Transform.IncrementPosition(movingDirectionX, movingDirectionY);
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

		private SnakeTile CreateTile(int x, int y)
		{
			var tile = new SnakeTile(
				x,
				y,
				() => { EatFood(); },
				() => { Dead = true; });

			worldContext.AddComponent(tile);

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
		}

		public bool IsOutOfBounds()
		{
			return !bounds.Contains(head.Transform.Position.X, head.Transform.Position.Y);
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