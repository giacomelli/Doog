using System.Collections.Generic;

namespace Doog
{
    /// <summary>
    /// Defines an interface for a physic system.
    /// </summary>
	public interface IPhysicSystem
	{
        /// <summary>
        /// Adds a collidable object to the physics system.
        /// </summary>
        /// <param name="collidable">The collidable.</param>
        void AddCollidable(ICollidable collidable);

        /// <summary>
        /// Removes the collidable object from the physics system.
        /// </summary>
        /// <param name="collidable">The collidable.</param>
        void RemoveCollidable(ICollidable collidable);

        /// <summary>
        /// Gets the collisions of the specified collidable with others collidables in the physics system.
        /// </summary>
        /// <param name="collidable">The collidable.</param>
        /// <returns>The collisions.</returns>
        IList<Collision> GetCollisions(ICollidable collidable);

        /// <summary>
        /// Determinies whether the specified collidable is colliding with others collidables in the physics system.
        /// </summary>
        /// <param name="collidable">The collidable.</param>
        /// <returns>True if collides, otherwise false.</returns>
        bool AnyCollision(ICollidable collidable);

        /// <summary>
        /// Updates this instance.
        /// </summary>
        void Update();
	}
}
