using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Snake.Framework.Geometry;

namespace Snake.Framework.Physics
{
    public interface ICollidable : IComponent
    {
		TransformComponent Transform { get; }
        void OnCollision(Collision collision);
    }
}
