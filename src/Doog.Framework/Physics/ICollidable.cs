using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Doog.Framework.Geometry;

namespace Doog.Framework.Physics
{
    public interface ICollidable : IComponent
    {
		Transform Transform { get; }
        void OnCollision(Collision collision);
    }
}
