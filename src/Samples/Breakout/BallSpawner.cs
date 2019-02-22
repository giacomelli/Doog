using Doog;

namespace Breakout
{
	public class BallSpawner : ComponentBase, IUpdatable
	{
		private Ball[] balls = new Ball[1];

		private BallSpawner(IWorldContext context)
			: base(context)
		{
			for (int i = 0; i < balls.Length; i++)
			{
				balls[i] = new Ball(Context) { Enabled = false };
			}
		}

		public void Spawn()
		{
			for (int i = 0; i < balls.Length; i++)
			{
				if (!balls[i].Enabled)
				{
					balls[i].Enabled = true;
					balls[i].Transform.Position = Context.Bounds.GetCenter();
					break;
				}
			}
		}

		public void Update()
		{
		}

		public static BallSpawner Create(IWorldContext context)
		{
			return new BallSpawner(context);
		}
	}
}
