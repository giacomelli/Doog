namespace Doog
{
    /// <summary>
    /// Defines an interface for a graphic system.
    /// </summary>
    public interface IGraphicSystem : ICanvas
    {
        /// <summary>
        /// Initialize this instance.
        /// </summary>
        void Initialize();

        /// <summary>
        /// Render all objects register by the Draw method in the current frame.
        /// </summary>
        void Render();
    }
}
