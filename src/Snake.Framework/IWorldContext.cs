using System.Collections.Generic;
using Snake.Framework.Geometry;
using Snake.Framework.Graphics;
using Snake.Framework.Logging;
using Snake.Framework.Physics;
using Snake.Framework.Texts;
using Snake.Framework.Input;

namespace Snake.Framework
{
    public interface IWorldContext
    {
        IList<IComponent> Components { get; }

        IGraphicSystem GraphicSystem { get; }

        IPhysicSystem PhysicSystem { get; }

        ILogSystem LogSystem { get; }

        IFontSystem FontSystem { get; }

		Rectangle Bounds { get; }

        ITime Time { get; }

        IInputSystem InputSystem { get; }

		void AddComponent(IComponent component);

		void RemoveComponent(IComponent component);

		void OpenScene(IScene scene);

        void Exit();
    }
}
