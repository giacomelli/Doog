namespace Doog
{
    /// <summary>
    /// Represents a picture element.
    /// </summary>
    public struct Pixel
    {
        /// <summary>
        /// The default character.
        /// </summary>
        public const char DefaultChar = ' ';

        /// <summary>
        /// The default foreground color.
        /// </summary>
        public const Color DefaultForegroundColor = Color.White;

        /// <summary>
        /// The default background color.
        /// </summary>
        public const Color DefaultBackgroundColor = Color.Black;

        /// <summary>
        /// The default pixel.
        /// </summary>
        public static readonly Pixel Default = new Pixel(DefaultChar);

        /// <summary>
        /// The black pixel.
        /// </summary>
        public static readonly Pixel Black = new Pixel(Color.Black);

        /// <summary>
        /// The dark blue pixel.
        /// </summary>
        public static readonly Pixel DarkBlue = new Pixel(Color.DarkBlue);

        /// <summary>
        /// The dark green pixel.
        /// </summary>
        public static readonly Pixel DarkGreen = new Pixel(Color.DarkGreen);

        /// <summary>
        /// The dark cyan pixel.
        /// </summary>
        public static readonly Pixel DarkCyan = new Pixel(Color.DarkCyan);

        /// <summary>
        /// The dark red pixel.
        /// </summary>
        public static readonly Pixel DarkRed = new Pixel(Color.DarkRed);

        /// <summary>
        /// The dark magenta pixel.
        /// </summary>
        public static readonly Pixel DarkMagenta = new Pixel(Color.DarkMagenta);

        /// <summary>
        /// The dark yellow pixel.
        /// </summary>
        public static readonly Pixel DarkYellow = new Pixel(Color.DarkYellow);

        /// <summary>
        /// The gray pixel.
        /// </summary>
        public static readonly Pixel Gray = new Pixel(Color.Gray);

        /// <summary>
        /// The dark gray pixel.
        /// </summary>
        public static readonly Pixel DarkGray = new Pixel(Color.DarkGray);

        /// <summary>
        /// The blue pixel.
        /// </summary>
        public static readonly Pixel Blue = new Pixel(Color.Blue);

        /// <summary>
        /// The green pixel.
        /// </summary>
        public static readonly Pixel Green = new Pixel(Color.Green);

        /// <summary>
        /// The cyan pixel.
        /// </summary>
        public static readonly Pixel Cyan = new Pixel(Color.Cyan);

        /// <summary>
        /// The red pixel.
        /// </summary>
        public static readonly Pixel Red = new Pixel(Color.Red);

        /// <summary>
        /// The magenta pixel.
        /// </summary>
        public static readonly Pixel Magenta = new Pixel(Color.Magenta);

        /// <summary>
        /// The yellow pixel.
        /// </summary>
        public static readonly Pixel Yellow = new Pixel(Color.Yellow);

        /// <summary>
        /// The white pixel.
        /// </summary>
        public static readonly Pixel White = new Pixel(Color.White);

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Doog.Pixel"/> struct.
        /// </summary>
        /// <param name="char">The char.</param>
        /// <param name="foregroundColor">The foreground color.</param>
        /// <param name="backgroundColor">The background color.</param>
        public Pixel(char @char, Color foregroundColor = DefaultForegroundColor, Color backgroundColor = DefaultBackgroundColor)
        {
            Char = @char;
            ForegroundColor = foregroundColor;
            BackgroundColor = backgroundColor;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Pixel"/> struct using the default char (' ') and same color for foreground and background.
        /// </summary>
        /// <param name="color">The foreground and background color.</param>
        public Pixel(Color color)
            : this (DefaultChar, color, color)
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

		public Pixel WithChar(char ch)
		{
			return new Pixel(ch, ForegroundColor, BackgroundColor);
		}

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