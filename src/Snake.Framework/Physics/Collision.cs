using System.Collections;

namespace Snake.Framework.Physics
{
	public class Collision
	{
		public Collision(ICollidable target, ICollidable other)
		{
			Target = target;
			Other = other;
		}

		public ICollidable Target { get; private set; }
		public ICollidable Other { get; private set; }
	}
}