namespace Doog
{
	/// <summary>
	/// Defines an interface for a text system.
	/// </summary>
	public interface ITextSystem : IFontSystem
	{
        /// <summary>
        /// Gets the world context.
        /// </summary>
        IWorldContext Context { get; }

        /// <summary>
        /// Initialize this instance.
        /// </summary>
		void Initialize();

        /// <summary>
        /// Draw the specified text in the x and y coordinate.
        /// </summary>
        /// <returns>The draw.</returns>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        /// <param name="text">The text.</param>
        /// <param name="fontName">The font name.</param>
		ITextSystem Draw(float x, float y, string text, string fontName = null);
	}
}
