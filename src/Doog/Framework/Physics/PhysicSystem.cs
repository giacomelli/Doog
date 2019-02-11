using System;
using System.Collections.Generic;

namespace Doog
{
    /// <summary>
    /// A very basic physic system.
    /// </summary>
	public class PhysicSystem : IPhysicSystem
	{
		private readonly IList<ICollidable> collidables = new List<ICollidable>();

		public void AddCollidable(ICollidable collidable)
		{
			collidables.Add(collidable);
		}

		public void RemoveCollidable(ICollidable collidable)
		{
			collidables.Remove(collidable);
		}

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
            var count = collidables.Count;
            ICollidable collidable1;
            ICollidable collidable2;
            Rectangle collidable1BoundingBox;

		    for (int i = 0; i < count; i++)
			{
				collidable1 = collidables[i];

				if (!collidable1.Enabled)
				{
					continue;
				}

                collidable1BoundingBox = collidable1.Transform.BoundingBox;

				for (int j = i + 1; j < count; j++)
				{
					collidable2 = collidables[j];

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