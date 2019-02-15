using System;

namespace Doog
{
    /// <summary>
    /// An IGraphicSystem's console implementation.
    /// </summary>
    /// <seealso cref="Doog.IGraphicSystem" />
    public class GraphicSystem : IGraphicSystem
    {
        private static readonly Pixel EmptyPixel = Pixel.Black;
        private Pixel[,] _pixels;
        private Pixel[,] _lastFrame;

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
            Console.CursorVisible = false;
            Console.BackgroundColor = (ConsoleColor) EmptyPixel.BackgroundColor;
            Console.ForegroundColor = (ConsoleColor) EmptyPixel.ForegroundColor;
            Console.Clear();

            _pixels = new Pixel[Console.WindowWidth, Console.WindowHeight];
            Fill(_pixels, EmptyPixel);

            _lastFrame = new Pixel[Console.WindowWidth, Console.WindowHeight];

            Array.Copy(_pixels, _lastFrame, _lastFrame.Length);
        }

        /// <summary>
        /// Gets the bounds.
        /// </summary>
        public Rectangle Bounds { get; private set; }

        /// <summary>
        /// Draw the pixel in the specified x and y coordinates.
        /// </summary>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        /// <param name="pixel">The pixel.</param>
        public void Draw(float x, float y, Pixel pixel)
        {
            if (Bounds.Contains(x, y))
            {
                _pixels[(int)x, (int)y] = pixel;
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
                    var pixel = _pixels[x, y];
                    var lastFramePixel = _lastFrame[x, y];

                    if (pixel != lastFramePixel)
                    {
                        Console.SetCursorPosition(x, y);
                        Console.BackgroundColor = (ConsoleColor) pixel.BackgroundColor;
                        Console.ForegroundColor = (ConsoleColor) pixel.ForegroundColor;
                        Console.Write(pixel.Char);
                    }

                    _lastFrame[x, y] = pixel;
                    _pixels[x, y] = EmptyPixel;
                }
            }
        }

        private static void Fill(Pixel[,] buffer, Pixel pixel)
        {
            var width = buffer.GetUpperBound(0);
            var height = buffer.GetUpperBound(1);

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    buffer[x, y] = pixel;
                }
            }
        }
    }
}
