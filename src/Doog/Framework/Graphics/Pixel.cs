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
        public static readonly Pixel Default = new Pixel('.', Color.White);
        //public static readonly Pixel Red = new Pixel(' ', Color.Red, Color.Red);
        //public static readonly Pixel Green = new Pixel(' ', Color.Green, Color.Green);
        //public static readonly Pixel Blue = new Pixel(' ', Color.Blue, Color.Blue);
        //public static readonly Pixel Yellow = new Pixel(' ', Color.Yellow, Color.Yellow);

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Doog.Pixel"/> struct.
        /// </summary>
        /// <param name="char">The char.</param>
        /// <param name="foregroundColor">The foreground color.</param>
        /// <param name="backgroundColor">The background color.</param>
        public Pixel(char @char, Color foregroundColor, Color backgroundColor)
        {
            Char = @char;
            ForegroundColor = foregroundColor;
            BackgroundColor = backgroundColor;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Doog.Pixel"/> struct.
        /// </summary>
        /// <param name="char">The char.</param>
        /// <param name="foregroundColor">The foreground color.</param>
        public Pixel(char @char, Color foregroundColor)
            : this(@char, foregroundColor, Color.Black)
        {
        }

        /// <summary>
        /// Gets the char.
        /// </summary>
        public char Char { get; }

        /// <summary>
        /// Gets the foreground color.
        /// </summary>
        public Color ForegroundColor { get; }

        /// <summary>
        /// Gets the foreground color.
        /// </summary>
        public Color BackgroundColor { get; }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (!(obj is Pixel))
            {
                return false;
            }

            return ((Pixel)obj) == this;
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + Char.GetHashCode();
                hash = hash * 23 + ForegroundColor.GetHashCode();
                hash = hash * 23 + BackgroundColor.GetHashCode();

                return hash;
            }
        }

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return $"{Char} {ForegroundColor} / {BackgroundColor}";
        }

        /// <summary>
        /// Creates a black pixel with the specified char.
        /// </summary>
        /// <returns>The pixel.</returns>
        /// <param name="char">The char.</param>
        public static Pixel Black(char @char, Color backgroundColor = Color.Black)
        {
            return new Pixel(@char, Color.Black, backgroundColor);
        }

        /// <summary>
        /// Creates a blue pixel with the specified char.
        /// </summary>
        /// <returns>The pixel.</returns>
        /// <param name="char">The char.</param>
        public static Pixel Blue(char @char, Color backgroundColor = Color.Black)
        {
            return new Pixel(@char, Color.Blue, backgroundColor);
        }

        public static Pixel Blue()
        {
            return new Pixel(' ', Color.Blue, Color.Blue);
        }

        /// <summary>
        /// Creates a cyan pixel with the specified char.
        /// </summary>
        /// <returns>The pixel.</returns>
        /// <param name="char">The char.</param>
        public static Pixel Cyan(char @char, Color backgroundColor = Color.Black)
        {
            return new Pixel(@char, Color.Cyan, backgroundColor);
        }

        /// <summary>
        /// Creates a dark blue pixel with the specified char.
        /// </summary>
        /// <returns>The pixel.</returns>
        /// <param name="char">The char.</param>
        public static Pixel DarkBlue(char @char, Color backgroundColor = Color.Black)
        {
            return new Pixel(@char, Color.DarkBlue, backgroundColor);
        }

        /// <summary>
        /// Creates a dark cyan pixel with the specified char.
        /// </summary>
        /// <returns>The pixel.</returns>
        /// <param name="char">The char.</param>
        public static Pixel DarkCyan(char @char, Color backgroundColor = Color.Black)
        {
            return new Pixel(@char, Color.DarkCyan, backgroundColor);
        }

        /// <summary>
        /// Creates a dark gray pixel with the specified char.
        /// </summary>
        /// <returns>The pixel.</returns>
        /// <param name="char">The char.</param>
        public static Pixel DarkGray(char @char, Color backgroundColor = Color.Black)
        {
            return new Pixel(@char, Color.DarkGray, backgroundColor);
        }

        /// <summary>
        /// Creates a dark green pixel with the specified char.
        /// </summary>
        /// <returns>The pixel.</returns>
        /// <param name="char">The char.</param>
        public static Pixel DarkGreen(char @char, Color backgroundColor = Color.Black)
        {
            return new Pixel(@char, Color.DarkGreen, backgroundColor);
        }

        /// <summary>
        /// Creates a dark green pixel with the specified char.
        /// </summary>
        /// <returns>The pixel.</returns>
        /// <param name="char">The char.</param>
        public static Pixel DarkMagenta(char @char, Color backgroundColor = Color.Black)
        {
            return new Pixel(@char, Color.DarkMagenta, backgroundColor);
        }

        /// <summary>
        /// Creates a dark red pixel with the specified char.
        /// </summary>
        /// <returns>The pixel.</returns>
        /// <param name="char">The char.</param>
        public static Pixel DarkRed(char @char, Color backgroundColor = Color.Black)
        {
            return new Pixel(@char, Color.DarkRed, backgroundColor);
        }

        /// <summary>
        /// Creates a dark yellow pixel with the specified char.
        /// </summary>
        /// <returns>The pixel.</returns>
        /// <param name="char">The char.</param>
        public static Pixel DarkYellow(char @char, Color backgroundColor = Color.Black)
        {
            return new Pixel(@char, Color.DarkYellow, backgroundColor);
        }

        /// <summary>
        /// Creates a gray pixel with the specified char.
        /// </summary>
        /// <returns>The pixel.</returns>
        /// <param name="char">The char.</param>
        public static Pixel Gray(char @char, Color backgroundColor = Color.Black)
        {
            return new Pixel(@char, Color.Gray, backgroundColor);
        }

        /// <summary>
        /// Creates a green pixel with the specified char.
        /// </summary>
        /// <returns>The pixel.</returns>
        /// <param name="char">The char.</param>
        public static Pixel Green(char @char, Color backgroundColor = Color.Black)
        {
            return new Pixel(@char, Color.Green, backgroundColor);
        }

        public static Pixel Green()
        {
            return new Pixel(' ', Color.Green, Color.Green);
        }

        /// <summary>
        /// Creates a magenta pixel with the specified char.
        /// </summary>
        /// <returns>The pixel.</returns>
        /// <param name="char">The char.</param>
        public static Pixel Magenta(char @char, Color backgroundColor = Color.Black)
        {
            return new Pixel(@char, Color.Magenta, backgroundColor);
        }

        /// <summary>
        /// Creates a red pixel with the specified char.
        /// </summary>
        /// <returns>The pixel.</returns>
        /// <param name="char">The char.</param>
        public static Pixel Red(char @char, Color backgroundColor = Color.Black)
        {
            return new Pixel(@char, Color.Red, backgroundColor);
        }

        public static Pixel Red()
        {
            return new Pixel(' ', Color.Red, Color.Red);
        }

        /// <summary>
        /// Creates a white pixel with the specified char.
        /// </summary>
        /// <returns>The pixel.</returns>
        /// <param name="char">The char.</param>
        public static Pixel White(char @char, Color backgroundColor = Color.Black)
        {
            return new Pixel(@char, Color.White, backgroundColor);
        }

        /// <summary>
        /// Creates a yellow pixel with the specified char.
        /// </summary>
        /// <returns>The pixel.</returns>
        /// <param name="char">The char.</param>
        public static Pixel Yellow(char @char, Color backgroundColor = Color.Black)
        {
            return new Pixel(@char, Color.Yellow, backgroundColor);
        }

        public static Pixel Yellow()
        {
            return new Pixel(' ', Color.Yellow, Color.Yellow);
        }

        /// <summary>
        /// Determines whether a specified instance of <see cref="Doog.Pixel"/> is equal to another specified <see cref="Doog.Pixel"/>.
        /// </summary>
        /// <param name="a">The first <see cref="Doog.Pixel"/> to compare.</param>
        /// <param name="b">The second <see cref="Doog.Pixel"/> to compare.</param>
        /// <returns><c>true</c> if <c>a</c> and <c>b</c> are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(Pixel a, Pixel b)
        {
            return a.Char == b.Char 
                && a.ForegroundColor == b.ForegroundColor
                && a.BackgroundColor == b.BackgroundColor;
        }

        /// <summary>
        /// Determines whether a specified instance of <see cref="Doog.Pixel"/> is not equal to another specified <see cref="Doog.Pixel"/>.
        /// </summary>
        /// <param name="a">The first <see cref="Doog.Pixel"/> to compare.</param>
        /// <param name="b">The second <see cref="Doog.Pixel"/> to compare.</param>
        /// <returns><c>true</c> if <c>a</c> and <c>b</c> are not equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(Pixel a, Pixel b)
        {
            return a.Char != b.Char
                || a.ForegroundColor != b.ForegroundColor
                || a.BackgroundColor != b.BackgroundColor;
        }
    }
}
