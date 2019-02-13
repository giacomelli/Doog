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
        /// <param name="color">The text color.</param>
        /// <param name="fontName">Name of the font.</param>
        /// <returns>The text system.</returns>
        public static ITextSystem DrawCenter(this ITextSystem textSystem, string text, Rectangle bounds, Color color, string fontName = null)
        {
            return DrawCenter(textSystem, 0, 0, text, bounds, color, fontName);
        }

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
            return DrawCenter(textSystem, 0, 0, text, bounds, Color.White, fontName);
        }

        /// <summary>
        /// Draws the text in the center of text system.
        /// </summary>
        /// <param name="textSystem">The text system.</param>
        /// <param name="text">The text.</param>
        /// <param name="color">The text color.</param>
        /// <param name="fontName">Name of the font.</param>
        /// <returns>The text system.</returns>
        public static ITextSystem DrawCenter(this ITextSystem textSystem, string text, Color color, string fontName = null)
        {
            return textSystem.DrawCenter(text, textSystem.Context.Bounds, color, fontName);
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
            return textSystem.DrawCenter(text, textSystem.Context.Bounds, Color.White, fontName);
        }

        /// <summary>
        /// Draws the text in the center of bounds using the specified offset.
        /// </summary>
        /// <param name="textSystem">The text system.</param>
        /// <param name="offsetX">The offset x.</param>
        /// <param name="offsetY">The offset y.</param>
        /// <param name="text">The text.</param>
        /// <param name="bounds">The bounds.</param>
        /// <param name="color">The text color.</param>
        /// <param name="fontName">Name of the font.</param>
        /// <returns>The text system.</returns>
        public static ITextSystem DrawCenter(this ITextSystem textSystem, float offsetX, float offsetY, string text, Rectangle bounds, Color color, string fontName = null)
        {
            var size = textSystem.GetFont(fontName).GetTextSize(text);
            var boundsCenter = bounds.GetCenter();
            var x = boundsCenter.X - (size.X / 2);
            var y = boundsCenter.Y - (size.Y / 2);

            return textSystem.Draw(x + offsetX, y + offsetY, text, color, fontName);
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
            return textSystem.DrawCenter(offsetX, offsetY, text, bounds, Color.White, fontName);
        }

        /// <summary>
        /// Draws the text in the center of text system using the specified offset.
        /// </summary>
        /// <param name="textSystem">The text system.</param>
        /// <param name="offsetX">The offset x.</param>
        /// <param name="offsetY">The offset y.</param>
        /// <param name="text">The text.</param>
        /// <param name="color">The text color.</param>
        /// <param name="fontName">Name of the font.</param>
        /// <returns>The text system.</returns>
        public static ITextSystem DrawCenter(this ITextSystem textSystem, float offsetX, float offsetY, string text, Color color, string fontName = null)
        {
            return textSystem.DrawCenter(offsetX, offsetY, text, textSystem.Context.Bounds, color, fontName);
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
            return textSystem.DrawCenter(offsetX, offsetY, text, textSystem.Context.Bounds, Color.White, fontName);
        }

        /// <summary>
        /// Draws the text centralized in the X coordinate.
        /// </summary>
        /// <param name="textSystem">The text system.</param>
        /// <param name="y">The y.</param>
        /// <param name="text">The text.</param>
        /// <param name="bounds">The bounds.</param>
        /// <param name="color">The text color.</param>
        /// <param name="fontName">Name of the font.</param>
        /// <returns>The text system.</returns>
        public static ITextSystem DrawCenterX(this ITextSystem textSystem, float y, string text, Rectangle bounds, Color color, string fontName = null)
        {
            var size = textSystem.GetFont(fontName).GetTextSize(text);
            var boundsCenter = bounds.GetCenter();
            var x = boundsCenter.X - (size.X / 2);

            return textSystem.Draw(x, y, text, color, fontName);
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
            return textSystem.DrawCenterX(y, text, bounds, Color.White, fontName);
        }

        /// <summary>
        /// Draws the text centralized in the X coordinate.
        /// </summary>
        /// <param name="textSystem">The text system.</param>
        /// <param name="y">The y.</param>
        /// <param name="text">The text.</param>
        /// <param name="color">The text color.</param>
        /// <param name="fontName">Name of the font.</param>
        /// <returns>The text system.</returns>
        public static ITextSystem DrawCenterX(this ITextSystem textSystem, float y, string text, Color color, string fontName = null)
        {
            return textSystem.DrawCenterX(y, text, textSystem.Context.Bounds, color, fontName);
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
            return textSystem.DrawCenterX(y, text, textSystem.Context.Bounds, Color.White, fontName);
        }

        /// <summary>
        /// Draws the text centralized in the Y coordinate.
        /// </summary>
        /// <param name="textSystem">The text system.</param>
        /// <param name="x">The x.</param>
        /// <param name="text">The text.</param>
        /// <param name="bounds">The bounds.</param>
        /// <param name="color">The text color.</param>
        /// <param name="fontName">Name of the font.</param>
        /// <returns>The text system.</returns>
        public static ITextSystem DrawCenterY(this ITextSystem textSystem, float x, string text, Rectangle bounds, Color color, string fontName = null)
        {
            var size = textSystem.GetFont(fontName).GetTextSize(text);
            var boundsCenter = bounds.GetCenter();
            var y = boundsCenter.Y - (size.Y / 2);

            return textSystem.Draw(x, y, text, color, fontName);
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
            return textSystem.DrawCenterY(x, text, bounds, Color.White, fontName);
        }

        /// <summary>
        /// Draws the text centralized in the Y coordinate.
        /// </summary>
        /// <param name="textSystem">The text system.</param>
        /// <param name="x">The x.</param>
        /// <param name="text">The text.</param>
        /// <param name="color">The text color.</param>
        /// <param name="fontName">Name of the font.</param>
        /// <returns>The text system.</returns>
        public static ITextSystem DrawCenterY(this ITextSystem textSystem, float x, string text, Color color, string fontName = null)
        {
            return textSystem.DrawCenterY(x, text, textSystem.Context.Bounds, color, fontName);
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
            return textSystem.DrawCenterY(x, text, Color.White, fontName);
        }

        /// <summary>
        /// Draws the text in the specified position.
        /// </summary>
        /// <param name="textSystem">The text system.</param>
        /// <param name="position">The position.</param>
        /// <param name="text">The text.</param>
        /// <param name="color">The text color.</param>
        /// <param name="fontName">Name of the font.</param>
        /// <returns>The text system.</returns>
        public static ITextSystem Draw(this ITextSystem textSystem, Point position, string text, Color color, string fontName = null)
        {
            return textSystem.Draw(position.X, position.Y, text, color, fontName);
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
            return textSystem.Draw(position, text, Color.White, fontName);
        }

        /// <summary>
        /// Draw the specified text in the x and y coordinate.
        /// </summary>
        /// <returns>The draw.</returns>
        /// <param name="textSystem">The text system.</param>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        /// <param name="text">The text.</param>
        /// <param name="fontName">The font name.</param>
        public static ITextSystem Draw(this ITextSystem textSystem, float x, float y, string text, string fontName = null)
        {
            return textSystem.Draw(x, y, text, Color.White, fontName);
        }
    }
}