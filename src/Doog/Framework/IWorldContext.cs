using System.Collections.Generic;

namespace Doog
{
    /// <summary>
    /// Defines an interface for a world context.
    /// </summary>
    public interface IWorldContext
    {
        /// <summary>
        /// Gets the components.
        /// </summary>
        IList<IComponent> Components { get; }

        /// <summary>
        /// Gets the graphic system.
        /// </summary>
        IGraphicSystem GraphicSystem { get; }

        /// <summary>
        /// Gets the physic system.
        /// </summary>
        IPhysicSystem PhysicSystem { get; }

        /// <summary>
        /// Gets the log system.
        /// </summary>
        ILogSystem LogSystem { get; }

        /// <summary>
        /// Gets the font system.
        /// </summary>
        IFontSystem FontSystem { get; }

        /// <summary>
        /// Gets the bounds.
        /// </summary>
		Rectangle Bounds { get; }

        /// <summary>
        /// Gets the time.
        /// </summary>
        ITime Time { get; }

        /// <summary>
        /// Gets the input system.
        /// </summary>
        IInputSystem InputSystem { get; }

        /// <summary>
        /// Adds the component.
        /// </summary>
        /// <param name="component">The component.</param>
		void AddComponent(IComponent component);

        /// <summary>
        /// Removes the component.
        /// </summary>
        /// <param name="component">The component.</param>
		void RemoveComponent(IComponent component);

        /// <summary>
        /// Opens the scene.
        /// </summary>
        /// <param name="scene">The scene.</param>
		void OpenScene(IScene scene);

        /// <summary>
        /// Exit the world.
        /// </summary>
        void Exit();
    }
}
