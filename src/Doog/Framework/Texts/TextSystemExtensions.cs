namespace Doog
{
    /// <summary>
    /// ITextSystem extension methods.
    /// </summary>
    public static class TextSystemExtensions
    {
        /// <summary>
        /// Draws the text in the center of the bounds.
        /// </summary>
        /// <param name="textSystem">The text system.</param>
        /// <param name="text">The text.</param>
        /// <param name="bounds">The bounds.</param>
        /// <param name="fontName">Name of the font.</param>
        /// <returns>The text system.</returns>
        public static ITextSystem DrawCenter(this ITextSystem textSystem, string text, Rectangle bounds, string fontName = null)
        {
            return DrawCenter(textSystem, 0, 0, text, bounds, fontName);
        }

        /// <summary>
        /// Draws the text in the center of text system.
        /// </summary>
        /// <param name="textSystem">The text system.</param>
        /// <param name="text">The text.</param>
        /// <param name="fontName">Name of the font.</param>
        /// <returns>The text system.</returns>
        public static ITextSystem DrawCenter(this ITextSystem textSystem, string text, string fontName = null)
        {
            return textSystem.DrawCenter(text, textSystem.Context.Bounds, fontName);
        }

        /// <summary>
        /// Draws the text in the center of bounds using the specified offset.
        /// </summary>
        /// <param name="textSystem">The text system.</param>
        /// <param name="offsetX">The offset x.</param>
        /// <param name="offsetY">The offset y.</param>
        /// <param name="text">The text.</param>
        /// <param name="bounds">The bounds.</param>
        /// <param name="fontName">Name of the font.</param>
        /// <returns>The text system.</returns>
        public static ITextSystem DrawCenter(this ITextSystem textSystem, float offsetX, float offsetY, string text, Rectangle bounds, string fontName = null)
        {
            var size = textSystem.GetFont(fontName).GetTextSize(text);
            var boundsCenter = bounds.GetCenter();
            var x = boundsCenter.X - (size.X / 2);
            var y = boundsCenter.Y - (size.Y / 2);

            return textSystem.Draw(x + offsetX, y + offsetY, text, fontName);
        }

        /// <summary>
        /// Draws the text in the center of text system using the specified offset.
        /// </summary>
        /// <param name="textSystem">The text system.</param>
        /// <param name="offsetX">The offset x.</param>
        /// <param name="offsetY">The offset y.</param>
        /// <param name="text">The text.</param>
        /// <param name="fontName">Name of the font.</param>
        /// <returns>The text system.</returns>
        public static ITextSystem DrawCenter(this ITextSystem textSystem, float offsetX, float offsetY, string text, string fontName = null)
        {
            return textSystem.DrawCenter(offsetX, offsetY, text, textSystem.Context.Bounds, fontName);
        }

        /// <summary>
        /// Draws the text centralized in the X coordinate.
        /// </summary>
        /// <param name="textSystem">The text system.</param>
        /// <param name="y">The y.</param>
        /// <param name="text">The text.</param>
        /// <param name="bounds">The bounds.</param>
        /// <param name="fontName">Name of the font.</param>
        /// <returns>The text system.</returns>
        public static ITextSystem DrawCenterX(this ITextSystem textSystem, float y, string text, Rectangle bounds, string fontName = null)
        {
            var size = textSystem.GetFont(fontName).GetTextSize(text);
            var boundsCenter = bounds.GetCenter();
            var x = boundsCenter.X - (size.X / 2);

            return textSystem.Draw(x, y, text, fontName);
        }

        /// <summary>
        /// Draws the text centralized in the X coordinate.
        /// </summary>
        /// <param name="textSystem">The text system.</param>
        /// <param name="y">The y.</param>
        /// <param name="text">The text.</param>
        /// <param name="fontName">Name of the font.</param>
        /// <returns>The text system.</returns>
        public static ITextSystem DrawCenterX(this ITextSystem textSystem, float y, string text, string fontName = null)
        {
            return textSystem.DrawCenterX(y, text, textSystem.Context.Bounds, fontName);
        }

        /// <summary>
        /// Draws the text centralized in the Y coordinate.
        /// </summary>
        /// <param name="textSystem">The text system.</param>
        /// <param name="x">The x.</param>
        /// <param name="text">The text.</param>
        /// <param name="bounds">The bounds.</param>
        /// <param name="fontName">Name of the font.</param>
        /// <returns>The text system.</returns>
        public static ITextSystem DrawCenterY(this ITextSystem textSystem, float x, string text, Rectangle bounds, string fontName = null)
        {
            var size = textSystem.GetFont(fontName).GetTextSize(text);
            var boundsCenter = bounds.GetCenter();
            var y = boundsCenter.Y - (size.Y / 2);

            return textSystem.Draw(x, y, text, fontName);
        }

        /// <summary>
        /// Draws the text centralized in the Y coordinate.
        /// </summary>
        /// <param name="textSystem">The text system.</param>
        /// <param name="x">The x.</param>
        /// <param name="text">The text.</param>
        /// <param name="fontName">Name of the font.</param>
        /// <returns>The text system.</returns>
        public static ITextSystem DrawCenterY(this ITextSystem textSystem, float x, string text, string fontName = null)
        {
            return textSystem.DrawCenterY(x, text, textSystem.Context.Bounds, fontName);
        }

        /// <summary>
        /// Draws the text in the specified position.
        /// </summary>
        /// <param name="textSystem">The text system.</param>
        /// <param name="position">The position.</param>
        /// <param name="text">The text.</param>
        /// <param name="fontName">Name of the font.</param>
        /// <returns>The text system.</returns>
        public static ITextSystem Draw(this ITextSystem textSystem, Point position, string text, string fontName = null)
        {
            return textSystem.Draw(position.X, position.Y, text, fontName);
        }
    }
}