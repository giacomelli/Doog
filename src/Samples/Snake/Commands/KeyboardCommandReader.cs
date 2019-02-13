using System.Collections.Generic;
using Doog;

namespace Snake.Commands
{
    public class KeyboardCommandReader : ICommandReader
    {
        private readonly KeyBinding _binding;
        private readonly IInputSystem _input;

        public KeyboardCommandReader(IInputSystem input, KeyBinding binding)
        {
            _binding = binding;
            _input = input;
        }

        public IEnumerable<ICommand> Read()
        {
            if (_input.IsKeyDown(_binding.MoveDown)) 
            {
                return new[] { MoveDownCommand.Default };
            }

            if (_input.IsKeyDown(_binding.MoveUp))
            {
                return new[] { MoveUpCommand.Default };
            }

            if (_input.IsKeyDown(_binding.MoveLeft))
            {
                return new[] { MoveLeftCommand.Default };
            }

            if (_input.IsKeyDown(_binding.MoveRight))
            {
                return new[] { MoveRightCommand.Default };
            }

            return new ICommand[] { };
        }
    }
}
