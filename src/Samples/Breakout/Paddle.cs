using System;
using Doog;

namespace Breakout
{
    public sealed class Paddle : RectangleComponent, IUpdatable, ICollidable
    {
        public event EventHandler Hit;

        public event EventHandler Died;

        private readonly ICommandReader m_commandReader;
        private float speed;

        public Paddle(IWorldContext context, ICommandReader commandReader)
            : base(new Rectangle(0, 0, 10, 1), context)
        {
            m_commandReader = commandReader;
        }

		public int HitCount { get; private set; }
       
		public void Initialize(float speed)
        {
            this.speed = speed;
			Transform.Position = Context.Bounds.BottomCenterPoint() + Point.Up * 3;
        }

        public void Update()
        {
            foreach(var command in m_commandReader.Read())
            {
                command.Execute(this);
            }
        }

        public void MoveLeft()
        {
			Transform.Position += Point.Left * speed * Context.Time.SinceLastFrame;
        }

        public void MoveRight()
        {
			Transform.Position += Point.Right * speed * Context.Time.SinceLastFrame;
        }

		public void OnCollision(Collision collision)
		{

		}
    }
}
