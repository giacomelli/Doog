using System;
using System.Diagnostics;

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
            InitializeConsoleConfig();

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
        /// Terminate this instance.
        /// </summary>
        public void Terminate()
        {
            TerminateConsoleConfig();
            Console.CursorVisible = true;
            Console.ResetColor();
            Console.Clear();
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
				var roundedX = (int)Math.Round(x);
				var roundedY = (int)Math.Round(y);

				var xDecimal = x - roundedX;
				var yDecimal = y - roundedY;
				int? xFix = null;
				int? yFix = null;
				if (xDecimal >= 0.4 && xDecimal <= 0.6)
				{
					xFix = (int)Math.Ceiling(x);
					_pixels[xFix.Value, roundedY] = pixel;
				}

				if (yDecimal >= 0.4 && yDecimal <= 0.6)
				{
					yFix = (int)Math.Ceiling(y);
					_pixels[roundedX, yFix.Value] = pixel;
				}

				if (!xFix.HasValue && !yFix.HasValue)
				{
					_pixels[roundedX, roundedY] = pixel;
				}
				else if (xFix.HasValue && yFix.HasValue)
				{
					_pixels[xFix.Value, yFix.Value] = pixel;
				}
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

        private static void InitializeConsoleConfig()
        {
            // Console implementation for Unix platforms (https://github.com/dotnet/corefx/blob/v2.0.0/src/System.Console/src/System/ConsolePal.Unix.cs) 
            // is letting escape typed chars even when ReadKey(true) is used:
            //  - https://github.com/dotnet/corefx/issues/25916#issuecomment-376689779
            //  - https://github.com/dotnet/corefx/issues/25916
            //  - https://github.com/dotnet/corefx/issues/34501
            // 
            // The code below is just a temp workaround until those issue been solved.
            if (Environment.OSVersion.Platform == PlatformID.Unix)
            {
                Process.Start("stty", "-echo");
            }
        }

        private static void TerminateConsoleConfig()
        {
            if (Environment.OSVersion.Platform == PlatformID.Unix)
            {
                Process.Start("stty", "echo");
            }
        }
    }
}
