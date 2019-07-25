using System;
using System.Collections.Generic;

namespace Doog
{
    /// <summary>
    /// An IInputSystem's console implementation.
    /// </summary>
    /// <seealso cref="Doog.IInputSystem" />
    public class InputSystem : IInputSystem
    {
        private const int MaxBuffer = 10;
        private readonly Queue<Keys> _buffer;

        /// <summary>
        /// Initializes a new instance of the <see cref="InputSystem"/> class.
        /// </summary>
        public InputSystem()
        {
            _buffer = new Queue<Keys>(MaxBuffer);
        }

        /// <summary>
        /// Verify if specified key is down in the current frame.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>
        ///   <c>true</c>, if key down is down, <c>false</c> otherwise.
        /// </returns>
        public bool IsKeyDown(Keys key)
        {
            return CheckKeyDown(key);
        }

        /// <summary>
        /// Update this instance.
        /// </summary>
        public void Update()
        {
            _buffer.Clear();
        }

        private bool CheckKeyDown(Keys key)
        {
            foreach (var k in _buffer)
            {
                if (k == key)
                {
                    return true;
                }
            }
            
            if (Console.KeyAvailable)
            {
                var consoleKey = Console.ReadKey(true);
                _buffer.Enqueue((Keys)consoleKey.Key);

                if ((int)consoleKey.Key == (int)key)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
