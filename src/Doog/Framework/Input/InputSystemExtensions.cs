using System;
namespace Doog
{
    public static class InputSystemExtensions
    {
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
