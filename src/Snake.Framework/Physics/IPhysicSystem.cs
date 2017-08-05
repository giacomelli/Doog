using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snake.Framework.Physics
{
	public interface IPhysicSystem
	{
		void AddCollidable(ICollidable collidable);
		IList<Collision> GetCollisions(ICollidable collidable);
		bool AnyCollision(ICollidable collidable);
		void Update();
	}
}
