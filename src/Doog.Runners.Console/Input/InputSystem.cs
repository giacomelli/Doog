﻿using System.Collections.Generic;
using Doog.Framework;
using Underlying = System.Console;

namespace Doog.Runners.Console
{
    public class InputSystem : IInputSystem
    {
        private const int MaxBuffer = 10;
        private readonly Queue<Keys> m_buffer;

        public InputSystem()
        {
            m_buffer = new Queue<Keys>(MaxBuffer);
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
                m_buffer.Enqueue((Keys)consoleKey.Key);

                if ((int)consoleKey.Key == (int)key)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
