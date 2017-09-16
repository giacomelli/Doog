namespace Doog.Framework
{
	/// <summary>
	/// Defines an interface for font system.
	/// </summary>
	public interface IFontSystem
	{
		IFont GetFont(string fontName = null);
	}
}
