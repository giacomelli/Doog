using System.Diagnostics;

namespace Doog
{
    /// <summary>
    /// Represents a collision between two collidable objects.
    /// </summary>
    [DebuggerDisplay("{Target.Tag} <= {Other.Tag}")]
	public class Collision
	{
        /// <summary>
        /// Initializes a new instance of the <see cref="Collision"/> class.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="other">The other.</param>
        public Collision(ICollidable target, ICollidable other)
		{
			Target = target;
			Other = other;
		}

        /// <summary>
        /// Gets the target collidable.
        /// </summary>
        public ICollidable Target { get; private set; }

        /// <summary>
        /// Gets the other collidable.
        /// </summary>
        public ICollidable Other { get; private set; }
	}
}