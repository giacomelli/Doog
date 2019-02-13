using System;

namespace Doog
{
    /// <summary>
    /// An IGraphicSystem's console implementation.
    /// </summary>
    /// <seealso cref="Doog.IGraphicSystem" />
    public class GraphicSystem : IGraphicSystem
    {
        private const char EmptySprite = ' ';
        private char[,] _sprites;
        private char[,] _lastFrame;

        /// <summary>
        /// Initializes a new instance of the <see cref="GraphicSystem"/> class.
        /// </summary>
        public GraphicSystem()
        {
			Bounds = new Rectangle(0, 0, Console.WindowWidth - 1, Console.WindowHeight - 1);
		}

        /// <summary>
        /// Initialize this instance.
        /// </summary>
        public void Initialize()
        {
            _sprites = new char[Console.WindowWidth, Console.WindowHeight];

            Fill(_sprites, EmptySprite);

            _lastFrame = new char[Console.WindowWidth, Console.WindowHeight];

            Array.Copy(_sprites, _lastFrame, _lastFrame.Length);
            Console.CursorVisible = false;
            Console.Clear();
        }

        /// <summary>
        /// Gets the bounds.
        /// </summary>
        public Rectangle Bounds { get; private set; }

        /// <summary>
        /// Draw the sprite in the specified x and y coordinates.
        /// </summary>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        /// <param name="sprite">The sprite.</param>
        public void Draw(float x, float y, char sprite)
        {
            if (Bounds.Contains(x, y))
            {
                _sprites[(int)x, (int)y] = sprite;
            }
        }

        /// <summary>
        /// Render all objects register by the Draw method in the current frame.
        /// </summary>
        public void Render()
        {
            var left = (int)Bounds.Left;
            var top  = (int)Bounds.Top;

            for (int x = left; x < Bounds.Right; x++)
            {
                for (int y = top; y < Bounds.Bottom; y++)
                {
                    var sprite = _sprites[x, y];
                    var lastFrameSprite = _lastFrame[x, y];

                    if (sprite != lastFrameSprite)
                    {
                        Console.SetCursorPosition(x, y);
                        Console.Write(sprite);
                    }

                    _lastFrame[x, y] = sprite;
                    _sprites[x, y] = EmptySprite;
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
