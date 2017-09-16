using System;
namespace Doog.Framework
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
