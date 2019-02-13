namespace Doog
{
    /// <summary>
    /// Represents a picture element.
    /// </summary>
    public struct Pixel
    {
        /// <summary>
        /// The default pixel.
        /// </summary>
        public static Pixel Default = new Pixel('.', Color.White);

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Doog.Pixel"/> struct.
        /// </summary>
        /// <param name="char">The char.</param>
        /// <param name="color">The color.</param>
        public Pixel(char @char, Color color)
        {
            Char = @char;
            Color = color;
        }

        /// <summary>
        /// Gets the char.
        /// </summary>
        public char Char { get; }

        /// <summary>
        /// Gets the color.
        /// </summary>
        public Color Color { get; }

        /// <summary>
        /// Creates a black pixel with the specified char.
        /// </summary>
        /// <returns>The pixel.</returns>
        /// <param name="char">The char.</param>
        public static Pixel Black(char @char)
        {
            return new Pixel(@char, Color.Black);
        }

        /// <summary>
        /// Creates a blue pixel with the specified char.
        /// </summary>
        /// <returns>The pixel.</returns>
        /// <param name="char">The char.</param>
        public static Pixel Blue(char @char)
        {
            return new Pixel(@char, Color.Blue);
        }

        /// <summary>
        /// Creates a cyan pixel with the specified char.
        /// </summary>
        /// <returns>The pixel.</returns>
        /// <param name="char">The char.</param>
        public static Pixel Cyan(char @char)
        {
            return new Pixel(@char, Color.Cyan);
        }

        /// <summary>
        /// Creates a dark blue pixel with the specified char.
        /// </summary>
        /// <returns>The pixel.</returns>
        /// <param name="char">The char.</param>
        public static Pixel DarkBlue(char @char)
        {
            return new Pixel(@char, Color.DarkBlue);
        }

        /// <summary>
        /// Creates a dark cyan pixel with the specified char.
        /// </summary>
        /// <returns>The pixel.</returns>
        /// <param name="char">The char.</param>
        public static Pixel DarkCyan(char @char)
        {
            return new Pixel(@char, Color.DarkCyan);
        }

        /// <summary>
        /// Creates a dark gray pixel with the specified char.
        /// </summary>
        /// <returns>The pixel.</returns>
        /// <param name="char">The char.</param>
        public static Pixel DarkGray(char @char)
        {
            return new Pixel(@char, Color.DarkGray);
        }

        /// <summary>
        /// Creates a dark green pixel with the specified char.
        /// </summary>
        /// <returns>The pixel.</returns>
        /// <param name="char">The char.</param>
        public static Pixel DarkGreen(char @char)
        {
            return new Pixel(@char, Color.DarkGreen);
        }

        /// <summary>
        /// Creates a dark green pixel with the specified char.
        /// </summary>
        /// <returns>The pixel.</returns>
        /// <param name="char">The char.</param>
        public static Pixel DarkMagenta(char @char)
        {
            return new Pixel(@char, Color.DarkMagenta);
        }

        /// <summary>
        /// Creates a dark red pixel with the specified char.
        /// </summary>
        /// <returns>The pixel.</returns>
        /// <param name="char">The char.</param>
        public static Pixel DarkRed(char @char)
        {
            return new Pixel(@char, Color.DarkRed);
        }

        /// <summary>
        /// Creates a dark yellow pixel with the specified char.
        /// </summary>
        /// <returns>The pixel.</returns>
        /// <param name="char">The char.</param>
        public static Pixel DarkYellow(char @char)
        {
            return new Pixel(@char, Color.DarkYellow);
        }

        /// <summary>
        /// Creates a gray pixel with the specified char.
        /// </summary>
        /// <returns>The pixel.</returns>
        /// <param name="char">The char.</param>
        public static Pixel Gray(char @char)
        {
            return new Pixel(@char, Color.Gray);
        }

        /// <summary>
        /// Creates a green pixel with the specified char.
        /// </summary>
        /// <returns>The pixel.</returns>
        /// <param name="char">The char.</param>
        public static Pixel Green(char @char)
        {
            return new Pixel(@char, Color.Green);
        }

        /// <summary>
        /// Creates a magenta pixel with the specified char.
        /// </summary>
        /// <returns>The pixel.</returns>
        /// <param name="char">The char.</param>
        public static Pixel Magenta(char @char)
        {
            return new Pixel(@char, Color.Magenta);
        }

        /// <summary>
        /// Creates a red pixel with the specified char.
        /// </summary>
        /// <returns>The pixel.</returns>
        /// <param name="char">The char.</param>
        public static Pixel Red(char @char)
        {
            return new Pixel(@char, Color.Red);
        }

        /// <summary>
        /// Creates a white pixel with the specified char.
        /// </summary>
        /// <returns>The pixel.</returns>
        /// <param name="char">The char.</param>
        public static Pixel White(char @char)
        {
            return new Pixel(@char, Color.White);
        }

        /// <summary>
        /// Creates a yellow pixel with the specified char.
        /// </summary>
        /// <returns>The pixel.</returns>
        /// <param name="char">The char.</param>
        public static Pixel Yellow(char @char)
        {
            return new Pixel(@char, Color.Yellow);
        }

        /// <summary>
        /// Determines whether a specified instance of <see cref="Doog.Pixel"/> is equal to another specified <see cref="Doog.Pixel"/>.
        /// </summary>
        /// <param name="a">The first <see cref="Doog.Pixel"/> to compare.</param>
        /// <param name="b">The second <see cref="Doog.Pixel"/> to compare.</param>
        /// <returns><c>true</c> if <c>a</c> and <c>b</c> are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(Pixel a, Pixel b)
        {
            return a.Char == b.Char && a.Color == b.Color;
        }

        /// <summary>
        /// Determines whether a specified instance of <see cref="Doog.Pixel"/> is not equal to another specified <see cref="Doog.Pixel"/>.
        /// </summary>
        /// <param name="a">The first <see cref="Doog.Pixel"/> to compare.</param>
        /// <param name="b">The second <see cref="Doog.Pixel"/> to compare.</param>
        /// <returns><c>true</c> if <c>a</c> and <c>b</c> are not equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(Pixel a, Pixel b)
        {
            return a.Char != b.Char || a.Color != b.Color;
        }
    }
}
