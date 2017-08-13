using System;
using Snake.Framework.Geometry;
using Snake.Framework.Graphics;
using underlying = System.Console;

namespace Snake.Runners.Console
{
    public class GraphicSystem : IGraphicSystem
    {
        private const char EmptySprite = ' ';
        private char[,] m_sprites;
        private char[,] m_lastFrame;

        public void Initialize()
        {
            Bounds = new Rectangle(0, 0, underlying.WindowWidth - 1, underlying.WindowHeight -1);
            m_sprites = new char[underlying.WindowWidth, underlying.WindowHeight];
            Fill(m_sprites, EmptySprite);
            m_lastFrame = new char[underlying.WindowWidth, underlying.WindowHeight];
            Array.Copy(m_sprites, m_lastFrame, m_lastFrame.Length);
            underlying.CursorVisible = false;
            underlying.Clear();
        }

        public Rectangle Bounds { get; private set; }

        public void Draw(float x, float y, char sprite)
        {
            if (Bounds.Contains(x, y))
            {
                m_sprites[(int)x, (int)y] = sprite;
            }
        }

        public void Render()
        {
            var left = (int)Bounds.Left;
            var top  = (int)Bounds.Top;

            for (int x = left; x < Bounds.Right; x++)
            {
                for (int y = top; y < Bounds.Bottom; y++)
                {
                    var sprite = m_sprites[x, y];
                    var lastFrameSprite = m_lastFrame[x, y];

                    if (sprite != lastFrameSprite)
                    {
                        underlying.SetCursorPosition(x, y);
                        underlying.Write(sprite);
                    }

                    m_lastFrame[x, y] = sprite;
                    m_sprites[x, y] = EmptySprite;
                }
            }
        }

        private static void Fill(char[,] buffer, char ch)
        {
            var width = buffer.GetUpperBound(0);
            var height = buffer.GetUpperBound(1);
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    buffer[x, y] = ch;
                }
            }
        }
    }
}
