using Snake.Framework.Collections;
using Snake.Framework.Input;
using Underlying = System.Console;

namespace Snake.Runners.Console.Input
{
    public class InputSystem : IInputSystem
    {
        private const int MAX_BUFFER = 10;
        private readonly CircularQueue<Keys> m_buffer;

        public InputSystem()
        {
            m_buffer = new CircularQueue<Keys>(MAX_BUFFER);
        }

        public bool IsKeyDown(Keys key)
        {
            return CheckKeyDown(key);
        }

        public void Update()
        {
            m_buffer.Clear();
        }

        private bool CheckKeyDown(Keys key)
        {
            foreach (var k in m_buffer)
            {
                if (k == key)
                {
                    return true;
                }
            }
            
            if (Underlying.KeyAvailable)
            {
                var consoleKey = Underlying.ReadKey(true);
                m_buffer.Add((Keys)consoleKey.Key);
                if ((int)consoleKey.Key == (int)key)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
