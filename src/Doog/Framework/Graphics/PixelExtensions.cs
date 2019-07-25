namespace Doog
{
    /// <summary>
    /// Pixel extension methods.
    /// </summary>
    public static class PixelExtensions
    {
        /// <summary>
        /// Creates a black pixel using the specified char.
        /// </summary>
        /// <param name="char">The char.</param>
        /// <returns>The pixel.</returns>
        public static Pixel Black(this char @char)
        {
            return new Pixel(@char, Color.Black);
        }

        /// <summary>
        /// Creates a blue pixel using the specified char.
        /// </summary>
        /// <param name="char">The char.</param>
        /// <returns>The pixel.</returns>
        public static Pixel Blue(this char @char)
        {
            return new Pixel(@char, Color.Blue);
        }

        /// <summary>
        /// Creates a cyan pixel using the specified char.
        /// </summary>
        /// <param name="char">The char.</param>
        /// <returns>The pixel.</returns>
        public static Pixel Cyan(this char @char)
        {
            return new Pixel(@char, Color.Cyan);
        }

        /// <summary>
        /// Creates a dark blue pixel using the specified char.
        /// </summary>
        /// <param name="char">The char.</param>
        /// <returns>The pixel.</returns>
        public static Pixel DarkBlue(this char @char)
        {
            return new Pixel(@char, Color.DarkBlue);
        }

        /// <summary>
        /// Creates a dark cyan pixel using the specified char.
        /// </summary>
        /// <param name="char">The char.</param>
        /// <returns>The pixel.</returns>
        public static Pixel DarkCyan(this char @char)
        {
            return new Pixel(@char, Color.DarkCyan);
        }

        /// <summary>
        /// Creates a dark gray pixel using the specified char.
        /// </summary>
        /// <param name="char">The char.</param>
        /// <returns>The pixel.</returns>
        public static Pixel DarkGray(this char @char)
        {
            return new Pixel(@char, Color.DarkGray);
        }

        /// <summary>
        /// Creates a dark green pixel using the specified char.
        /// </summary>
        /// <param name="char">The char.</param>
        /// <returns>The pixel.</returns>
        public static Pixel DarkGreen(this char @char)
        {
            return new Pixel(@char, Color.DarkGreen);
        }

        /// <summary>
        /// Creates a dark magenta pixel using the specified char.
        /// </summary>
        /// <param name="char">The char.</param>
        /// <returns>The pixel.</returns>
        public static Pixel DarkMagenta(this char @char)
        {
            return new Pixel(@char, Color.DarkMagenta);
        }

        /// <summary>
        /// Creates a dark red pixel using the specified char.
        /// </summary>
        /// <param name="char">The char.</param>
        /// <returns>The pixel.</returns>
        public static Pixel DarkRed(this char @char)
        {
            return new Pixel(@char, Color.DarkRed);
        }

        /// <summary>
        /// Creates a dark yellow pixel using the specified char.
        /// </summary>
        /// <param name="char">The char.</param>
        /// <returns>The pixel.</returns>
        public static Pixel DarkYellow(this char @char)
        {
            return new Pixel(@char, Color.DarkYellow);
        }

        /// <summary>
        /// Creates a gray pixel using the specified char.
        /// </summary>
        /// <param name="char">The char.</param>
        /// <returns>The pixel.</returns>
        public static Pixel Gray(this char @char)
        {
            return new Pixel(@char, Color.Gray);
        }

        /// <summary>
        /// Creates a green pixel using the specified char.
        /// </summary>
        /// <param name="char">The char.</param>
        /// <returns>The pixel.</returns>
        public static Pixel Green(this char @char)
        {
            return new Pixel(@char, Color.Green);
        }

        /// <summary>
        /// Creates a magenta pixel using the specified char.
        /// </summary>
        /// <param name="char">The char.</param>
        /// <returns>The pixel.</returns>
        public static Pixel Magenta(this char @char)
        {
            return new Pixel(@char, Color.Magenta);
        }

        /// <summary>
        /// Creates a red pixel using the specified char.
        /// </summary>
        /// <param name="char">The char.</param>
        /// <returns>The pixel.</returns>
        public static Pixel Red(this char @char)
        {
            return new Pixel(@char, Color.Red);
        }

        /// <summary>
        /// Creates a white pixel using the specified char.
        /// </summary>
        /// <param name="char">The char.</param>
        /// <returns>The pixel.</returns>
        public static Pixel White(this char @char)
        {
            return new Pixel(@char, Color.White);
        }

        /// <summary>
        /// Creates an yellow pixel using the specified char.
        /// </summary>
        /// <param name="char">The char.</param>
        /// <returns>The pixel.</returns>
        public static Pixel Yellow(this char @char)
        {
            return new Pixel(@char, Color.Yellow);
        }
    }
}