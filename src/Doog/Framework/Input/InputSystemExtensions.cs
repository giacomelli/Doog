using System;

namespace Doog
{
    /// <summary>
    /// IInputSystem extension methods.
    /// </summary>
    public static class InputSystemExtensions
    {
        /// <summary>
        /// Runs the action if specified key is down in the current framew.
        /// </summary>
        /// <returns>The input system.</returns>
        /// <param name="input">The input system.</param>
        /// <param name="key">The key.</param>
        /// <param name="action">The action.</param>
        public static IInputSystem IsKeyDown(this IInputSystem input, Keys key, Action action)
        {
            if(input.IsKeyDown(key))
            {
                action();
            }

            return input;
        }
    }
}
