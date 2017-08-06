using Snake.Framework.Geometry;

namespace Snake.Framework.Texts
{
	/// <summary>
	/// ITextSystem extension methods.
	/// </summary>
	public static class TextSystemExtensions
	{
		public static void DrawCenter(this ITextSystem textSystem, string text, IntRectangle bounds, string fontName = null)
		{
			DrawCenter(textSystem, 0, 0, text, bounds, fontName);
		}

		public static void DrawCenter(this ITextSystem textSystem, int offsetX, int offsetY, string text, IntRectangle bounds, string fontName = null)
		{
			var size = textSystem.GetTextSize(text, fontName);
			var boundsCenter = bounds.GetCenter();
			var x = boundsCenter.X - (size.X / 2);
			var y = boundsCenter.Y - (size.Y / 2);

			textSystem.Draw(x + offsetX, y + offsetY, text, fontName);
		}

		public static void DrawCenterX(this ITextSystem textSystem, int y, string text, IntRectangle bounds, string fontName = null)
		{
			var size = textSystem.GetTextSize(text, fontName);
			var boundsCenter = bounds.GetCenter();
			var x = boundsCenter.X - (size.X / 2);

			textSystem.Draw(x, y, text, fontName);
		}

		public static void DrawCenterY(this ITextSystem textSystem, int x, string text, IntRectangle bounds, string fontName = null)
		{
			var size = textSystem.GetTextSize(text, fontName);
			var boundsCenter = bounds.GetCenter();
			var y = boundsCenter.Y - (size.Y / 2);

			textSystem.Draw(x, y, text, fontName);
		}
	}
}
