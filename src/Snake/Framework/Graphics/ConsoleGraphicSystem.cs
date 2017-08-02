using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snake.Framework.Geometry;

namespace Snake.Framework.Graphics
{
    public class ConsoleGraphicSystem : IGraphicSystem
    {
        private const char EmptySprite = ' ';
        private char[,] m_sprites;

        public void Initialize()
        {
            Bounds = new IntRectangle(0, 0, Console.WindowWidth - 1, Console.WindowHeight - 1);
            m_sprites = new char[Console.WindowWidth, Console.WindowHeight];
            Console.CursorVisible = false;
        }

        public IntRectangle Bounds { get; private set; }

        public void Draw(int x, int y, char sprite)
        {
            m_sprites[x, y] = sprite;
        }

        public void Render()
        {
            Console.Clear();

            for (int x = Bounds.Left; x < Bounds.Right; x++)
            {
                for (int y = Bounds.Top; y < Bounds.Bottom; y++)
                {
                    var sprite = m_sprites[x, y];

                    if (sprite != EmptySprite)
                    {
                        Console.SetCursorPosition(x, y);
                        Console.Write(sprite);

                        m_sprites[x, y] = EmptySprite;
                    }
                }
            }
        }
    }
}
