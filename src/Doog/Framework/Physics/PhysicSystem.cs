using System;
using System.Collections.Generic;

namespace Doog
{
    /// <summary>
    /// A very basic physic system.
    /// </summary>
	public class PhysicSystem : IPhysicSystem
	{
		private readonly IList<ICollidable> _collidables = new List<ICollidable>();

        /// <summary>
        /// Adds a collidable object to the physics system.
        /// </summary>
        /// <param name="collidable">The collidable.</param>
        public void AddCollidable(ICollidable collidable)
		{
			_collidables.Add(collidable);
		}

        /// <summary>
        /// Removes the collidable object from the physics system.
        /// </summary>
        /// <param name="collidable">The collidable.</param>
        public void RemoveCollidable(ICollidable collidable)
		{
			_collidables.Remove(collidable);
		}

        /// <summary>
        /// Gets the collisions of the specified collidable with others collidables in the physics system.
        /// </summary>
        /// <param name="collidable">The collidable.</param>
        /// <returns>
        /// The collisions.
        /// </returns>
        public IList<Collision> GetCollisions(ICollidable collidable)
		{
			var collisions = new List<Collision>();
			FindCollisions((collidable1, collidable2) =>
			{
				collisions.Add(new Collision(collidable1, collidable1));

				return true;
			});

			return collisions;
		}

        /// <summary>
        /// Determinies whether the specified collidable is colliding with others collidables in the physics system.
        /// </summary>
        /// <param name="collidable">The collidable.</param>
        /// <returns>
        /// True if collides, otherwise false.
        /// </returns>
        public bool AnyCollision(ICollidable collidable)
		{
			var result = false;

            FindCollisions((collidable1, collidable2) =>
			{
				if (collidable == collidable1 || collidable == collidable2)
				{
					result = true;
					return false;
				}

				return true;
			});

			return result;
		}

        /// <summary>
        /// Updates this instance.
        /// </summary>
        public void Update()
		{
			FindCollisions((collidable1, collidable2) =>
			{
				collidable1.OnCollision(new Collision(collidable1, collidable2));
				collidable2.OnCollision(new Collision(collidable2, collidable1));

				return true;
			});
		}

		private void FindCollisions(Func<ICollidable, ICollidable, bool> found)
		{
            var count = _collidables.Count;
            ICollidable collidable1;
            ICollidable collidable2;
            Rectangle collidable1BoundingBox;

		    for (int i = 0; i < count; i++)
			{
				collidable1 = _collidables[i];

				if (!collidable1.Enabled)
				{
					continue;
				}

                collidable1BoundingBox = collidable1.Transform.BoundingBox;

				for (int j = i + 1; j < count; j++)
				{
					collidable2 = _collidables[j];

					if (!collidable2.Enabled)
					{
						continue;
					}

					if (collidable1BoundingBox.Intersect(collidable2.Transform.BoundingBox)
                    && !found(collidable1, collidable2))
					{
                        return;						
					}
				}
			}
		}
	}
}