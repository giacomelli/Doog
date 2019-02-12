namespace Doog
{
    /// <summary>
    /// Defines an interface for a font.
    /// </summary>
    public interface IFont
	{
        /// <summary>
        /// Gets the name.
        /// </summary>
		string Name { get; }

        /// <summary>
        /// Gets the size.
        /// </summary>
		Point Size { get; }

        /// <summary>
        /// Gets the size of the text.
        /// </summary>
        /// <returns>The text size.</returns>
        /// <param name="text">The text.</param>
		Point GetTextSize(string text);
	}
}
