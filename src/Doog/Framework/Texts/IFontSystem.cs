namespace Doog
{
	/// <summary>
	/// Defines an interface for font system.
	/// </summary>
	public interface IFontSystem
	{
        /// <summary>
        /// Gets the font.
        /// </summary>
        /// <returns>The font.</returns>
        /// <param name="fontName">The font name.</param>
		IFont GetFont(string fontName = null);
	}
}
