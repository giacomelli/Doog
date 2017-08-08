using Snake.Framework.Geometry;

namespace Snake.Framework.Texts
{
	/// <summary>
	/// Defines an interface for a font.
	/// </summary>
	public interface IFont
	{
		string Name { get; }
		IntPoint Size { get; }
		IntPoint GetTextSize(string text);
	}
}
