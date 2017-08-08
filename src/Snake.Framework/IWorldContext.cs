﻿using System.Collections.Generic;
using Snake.Framework.Geometry;
using Snake.Framework.Physics;
using Snake.Framework.Texts;

namespace Snake.Framework
{
	public interface IWorldContext
	{
		IList<IComponent> Components { get; }
		void AddComponent(IComponent component);
		void RemoveComponent(IComponent component);

		IPhysicSystem PhysicSystem { get; }
    
		ITextSystem TextSystem { get; }
		IntRectangle Bounds { get; }
    }
}
