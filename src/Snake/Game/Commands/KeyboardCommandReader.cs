using System.Collections.Generic;
using Doog.Framework;

namespace Snake.Game.Commands
{
    public class KeyboardCommandReader : ICommandReader
    {
        private readonly KeyBinding m_binding;
        private readonly IInputSystem m_input;

        public KeyboardCommandReader(IInputSystem input, KeyBinding binding)
        {
            m_binding = binding;
            m_input = input;
        }

        public IEnumerable<ICommand> Read()
        {
            if (m_input.IsKeyDown(Keys.DownArrow)) 
            {
                return new[] { SnakeCommandPool.MoveDown };
            }

            if (m_input.IsKeyDown(Keys.UpArrow))
            {
                return new[] { SnakeCommandPool.MoveUp };
            }

            if (m_input.IsKeyDown(Keys.LeftArrow))
            {
                return new[] { SnakeCommandPool.MoveLeft };
            }

            if (m_input.IsKeyDown(Keys.RightArrow))
            {
                return new[] { SnakeCommandPool.MoveRight };
            }

            return new ICommand[] { };
        }
    }
}
