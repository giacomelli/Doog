using System.Diagnostics;

namespace Doog.Framework
{
    [DebuggerDisplay("{Target.Tag} <= {Other.Tag}")]
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