using Snake.Framework.Geometry;

namespace Snake.Framework.Texts
{
	/// <summary>
	/// Defines an interface for a font.
	/// </summary>
	public interface IFont
	{
		string Name { get; }
		Point Size { get; }
		Point GetTextSize(string text);
	}
}
