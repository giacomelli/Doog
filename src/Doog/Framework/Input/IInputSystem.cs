namespace Doog
{
    /// <summary>
    /// Defines an interface for an input system.
    /// </summary>
    public interface IInputSystem
    {
        /// <summary>
        /// Verify if specified key is down in the current frame.
        /// </summary>
        /// <returns><c>true</c>, if key down is down, <c>false</c> otherwise.</returns>
        /// <param name="key">The key.</param>
        bool IsKeyDown(Keys key);

        /// <summary>
        /// Update this instance.
        /// </summary>
        void Update();
    }
}
