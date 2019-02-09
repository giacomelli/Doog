using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Doog;

namespace Doog
{
    public interface ICollidable : IComponent
    {
		Transform Transform { get; }
        void OnCollision(Collision collision);
    }
}
