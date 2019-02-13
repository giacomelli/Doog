using System;

namespace Doog
{
    /// <summary>
    /// Defines an interface for a world.
    /// </summary>
    public interface IWorld : IWorldContext, IDisposable
    {
        /// <summary>
        /// Gets the current scene.
        /// </summary>
		IScene CurrentScene { get; }

        /// <summary>
        /// Update the instance.
        /// </summary>
        /// <param name="now">The current real world time.</param>
        void Update(DateTime now);

        /// <summary>
        /// Draw this instance on current frame.
        /// </summary>
        void Draw(); 
    }
}