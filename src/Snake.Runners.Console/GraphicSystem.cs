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
            Bounds = new IntRectangle(0, 0, underlying.WindowWidth - 1, underlying.WindowHeight -1);
            m_sprites = new char[underlying.WindowWidth, underlying.WindowHeight];
            underlying.CursorVisible = false;
        }

        public IntRectangle Bounds { get; private set; }

        public void Draw(int x, int y, char sprite)
        {
			if (Bounds.Contains(x, y))
			{
				m_sprites[x, y] = sprite;
			}
        }

        public void Render()
        {
            underlying.Clear();

            for (int x = Bounds.Left; x < Bounds.Right; x++)
            {
                for (int y = Bounds.Top; y < Bounds.Bottom; y++)
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
