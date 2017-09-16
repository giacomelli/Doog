using System.Collections.Generic;
using Doog.Framework.Geometry;
using Doog.Framework.Graphics;
using Doog.Framework.Logging;
using Doog.Framework.Physics;
using Doog.Framework.Texts;
using Doog.Framework.Input;

namespace Doog.Framework
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
