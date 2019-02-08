namespace Doog
{
	/// <summary>
	/// Defines an interface for font system.
	/// </summary>
	public interface IFontSystem
	{
		IFont GetFont(string fontName = null);
	}
}
