using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snake.Framework.Physics
{
	public class PhysicSystem : IPhysicSystem
	{
		private IList<ICollidable> collidables = new List<ICollidable>();

		public void AddCollidable(ICollidable collidable)
		{
			collidables.Add(collidable);
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
				collidable1.OnCollision(new Collision(collidable1, collidable2));
				collidable2.OnCollision(new Collision(collidable2, collidable1));
				result = true;
				return false;
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
			for (int i = 0; i < collidables.Count; i++)
			{
				var collidable1 = collidables[i];

				if (!collidable1.Enabled)
				{
					continue;
				}

				for (int j = i + 1; j < collidables.Count; j++)
				{
					var collidable2 = collidables[j];

					if (!collidable2.Enabled)
					{
						continue;
					}

					if (collidable1.Transform.Intersect(collidable2.Transform))
					{
						if (!found(collidable1, collidable2))
						{
							return;
						}
					}
				}
			}
		}
	}
}
