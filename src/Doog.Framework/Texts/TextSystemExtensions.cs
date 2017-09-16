using Doog.Framework;

/// <summary>
/// ITextSystem extension methods.
/// </summary>
public static class TextSystemExtensions
{
	public static ITextSystem DrawCenter(this ITextSystem textSystem, string text, Rectangle bounds, string fontName = null)
	{
		return DrawCenter(textSystem, 0, 0, text, bounds, fontName);
	}

	public static ITextSystem DrawCenter(this ITextSystem textSystem, string text, string fontName = null)
	{
		return textSystem.DrawCenter(text, textSystem.Context.Bounds, fontName);
	}

	public static ITextSystem DrawCenter(this ITextSystem textSystem, float offsetX, float offsetY, string text, Rectangle bounds, string fontName = null)
	{
		var size = textSystem.GetFont(fontName).GetTextSize(text);
		var boundsCenter = bounds.GetCenter();
		var x = boundsCenter.X - (size.X / 2);
		var y = boundsCenter.Y - (size.Y / 2);

		return textSystem.Draw(x + offsetX, y + offsetY, text, fontName);
	}

	public static ITextSystem DrawCenter(this ITextSystem textSystem, float offsetX, float offsetY, string text, string fontName = null)
	{
		return textSystem.DrawCenter(offsetX, offsetY, text, textSystem.Context.Bounds, fontName);
	}

	public static ITextSystem DrawCenterX(this ITextSystem textSystem, float y, string text, Rectangle bounds, string fontName = null)
	{
		var size = textSystem.GetFont(fontName).GetTextSize(text);
		var boundsCenter = bounds.GetCenter();
		var x = boundsCenter.X - (size.X / 2);

		return textSystem.Draw(x, y, text, fontName);
	}


	public static ITextSystem DrawCenterX(this ITextSystem textSystem, float y, string text, string fontName = null)
	{
      return textSystem.DrawCenterX(y, text, textSystem.Context.Bounds, fontName);
	}

	public static ITextSystem DrawCenterY(this ITextSystem textSystem, float x, string text, Rectangle bounds, string fontName = null)
	{
		var size = textSystem.GetFont(fontName).GetTextSize(text);
		var boundsCenter = bounds.GetCenter();
		var y = boundsCenter.Y - (size.Y / 2);

		return textSystem.Draw(x, y, text, fontName);
	}

	public static ITextSystem DrawCenterY(this ITextSystem textSystem, float x, string text, string fontName = null)
	{
		return textSystem.DrawCenterY(x, text, textSystem.Context.Bounds, fontName);
	}

    public static ITextSystem Draw(this ITextSystem textSystem, Point position, string text, string fontName = null)
    {
        return textSystem.Draw(position.X, position.Y, text, fontName);
    }
}
