using System;
using Doog;

namespace Snake
{
    public sealed class Snake : ComponentBase, IUpdatable, ITransformable, ICollidable
    {
        private const float MaxSpeed = 20;
        private const float Acceleration = 0.25f;
        public event EventHandler FoodEaten;
        public event EventHandler Died;

        private readonly ICommandReader m_commandReader;
        private SnakeTile tail;
        private int movingDirectionX;
        private int movingDirectionY;
        private Rectangle bounds;
        private float speed;

        public Snake(IWorldContext context, ICommandReader commandReader)
            : base(context)
        {
            bounds = context.Bounds;
            m_commandReader = commandReader;
        }

        public Transform Transform
        {
            get
            {
                return Head.Transform;
            }
        }

		public bool Dead { get; set; }
		public int FoodsEatenCount { get; private set; }
		public SnakeTile Head { get; private set; }
       
		public void Initialize(float x, float y, int length)
        {
            movingDirectionX = 1;
            movingDirectionY = 0;
            speed = length;
            Deploy(x, y, length);
        }

        public void Update()
        {
            foreach(var command in m_commandReader.Read())
            {
                command.Execute(this);
            }
            
            Move();

            if (!Context.Bounds.Contains(Head.Transform.Position))
            {
                OnDied();
            }
        }

        private float lastPositionChangeTime = 0;

        private void Move()
        {
            var hpos = Head.Transform.Position.Round();
            var newPosition = Point.Lerp(
                hpos,
                new Point(hpos.X + movingDirectionX, hpos.Y + movingDirectionY),
                (Context.Time.SinceSceneStart - lastPositionChangeTime) * speed)
                .Round();

            if (newPosition != hpos)
            {
                Head.Pixel = SnakeTile.BodyPixel;
                tail.Transform.Position = newPosition;
                Head.Next = tail;
                Head = tail;
                tail = tail.Next;
                Head.Next = null;
                Head.Pixel = SnakeTile.HeadPixel;

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
            Head = CreateTile(x++, y);
            tail.Next.Next = Head;
            length -= 3;

            for (int i = 0; i < length; i++, x++)
            {
                Head.Next = CreateTile(x, y);
                Head = Head.Next;
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

            if (speed < MaxSpeed)
            {
                speed += Acceleration;
            }

            Log.Debug("{0} foods eaten. New speed {1}", FoodsEatenCount, speed);
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

        public void MoveLeft()
        {
            if (movingDirectionX == 0)
            {
                ChangeMovingDirection(-1, 0);
            }
        }

        public void MoveUp()
        {
            if (movingDirectionY == 0)
            {
                ChangeMovingDirection(0, -1);
            }
        }

        public void MoveRight()
        {
            if (movingDirectionX == 0)
            {
                ChangeMovingDirection(1, 0);
            }
        }

        public void MoveDown()
        {
            if (movingDirectionY == 0)
            {
                ChangeMovingDirection(0, 1);
            }
        }

		public void OnCollision(Collision collision)
		{

		}
    }
}
