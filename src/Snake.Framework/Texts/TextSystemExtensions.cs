using Snake.Framework.Geometry;
using Snake.Framework.Texts;

/// <summary>
/// ITextSystem extension methods.
/// </summary>
public static class TextSystemExtensions
{
	public static void DrawCenter(this ITextSystem textSystem, string text, Rectangle bounds, string fontName = null)
	{
		DrawCenter(textSystem, 0, 0, text, bounds, fontName);
	}

	public static void DrawCenter(this ITextSystem textSystem, string text, string fontName = null)
	{
		textSystem.DrawCenter(text, textSystem.Context.Bounds, fontName);
	}

	public static void DrawCenter(this ITextSystem textSystem, float offsetX, float offsetY, string text, Rectangle bounds, string fontName = null)
	{
		var size = textSystem.GetFont(fontName).GetTextSize(text);
		var boundsCenter = bounds.GetCenter();
		var x = boundsCenter.X - (size.X / 2);
		var y = boundsCenter.Y - (size.Y / 2);

		textSystem.Draw(x + offsetX, y + offsetY, text, fontName);
	}

	public static void DrawCenter(this ITextSystem textSystem, float offsetX, float offsetY, string text, string fontName = null)
	{
		textSystem.DrawCenter(offsetX, offsetY, text, textSystem.Context.Bounds, fontName);
	}

	public static void DrawCenterX(this ITextSystem textSystem, float y, string text, Rectangle bounds, string fontName = null)
	{
		var size = textSystem.GetFont(fontName).GetTextSize(text);
		var boundsCenter = bounds.GetCenter();
		var x = boundsCenter.X - (size.X / 2);

		textSystem.Draw(x, y, text, fontName);
	}

	public static void DrawCenterX(this ITextSystem textSystem, float y, string text, string fontName = null)
	{
       textSystem.DrawCenterX(y, text, textSystem.Context.Bounds, fontName);
	}

	public static void DrawCenterY(this ITextSystem textSystem, float x, string text, Rectangle bounds, string fontName = null)
	{
		var size = textSystem.GetFont(fontName).GetTextSize(text);
		var boundsCenter = bounds.GetCenter();
		var y = boundsCenter.Y - (size.Y / 2);

		textSystem.Draw(x, y, text, fontName);
	}

	public static void DrawCenterY(this ITextSystem textSystem, float x, string text, string fontName = null)
	{
		textSystem.DrawCenterY(x, text, textSystem.Context.Bounds, fontName);
	}
}
