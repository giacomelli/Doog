using System.Collections.Generic;
using Snake.Framework.Geometry;
using Snake.Framework.Graphics;
using Snake.Framework.Logging;
using Snake.Framework.Physics;
using Snake.Framework.Texts;

namespace Snake.Framework
{
	public interface IWorldContext
	{
		IList<IComponent> Components { get; }

		IGraphicSystem GraphicSystem { get; }

		IPhysicSystem PhysicSystem { get; }

		ITextSystem TextSystem { get; }

        ILogSystem LogSystem { get; }

		Rectangle Bounds { get; }

        ITime Time { get; }

		void AddComponent(IComponent component);

		void RemoveComponent(IComponent component);

		void OpenScene(IScene scene);
	}
}
