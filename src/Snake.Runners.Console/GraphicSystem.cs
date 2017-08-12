using Snake.Framework.Geometry;
using Snake.Framework.Graphics;
using underlying = System.Console;

namespace Snake.Runners.Console
{
    public class GraphicSystem : IGraphicSystem
    {
        private const char EmptySprite = '\0';
        private char[,] m_sprites;

        public void Initialize()
        {
            Bounds = new Rectangle(0, 0, underlying.WindowWidth - 1, underlying.WindowHeight -1);
            m_sprites = new char[underlying.WindowWidth, underlying.WindowHeight];
            underlying.CursorVisible = false;
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
            underlying.Clear();
            var left = (int)Bounds.Left;
            var top  = (int)Bounds.Top;

            for (int x = left; x < Bounds.Right; x++)
            {
                for (int y = top; y < Bounds.Bottom; y++)
                {
                    var sprite = m_sprites[x, y];

                    if (sprite != EmptySprite)
                    {
                        underlying.SetCursorPosition(x, y);
                        underlying.Write(sprite);

                        m_sprites[x, y] = EmptySprite;
                    }
                }
            }
        }
    }
}
