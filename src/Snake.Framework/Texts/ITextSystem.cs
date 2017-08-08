using System;
using Snake.Framework.Geometry;

namespace Snake.Framework.Texts
{
	/// <summary>
	/// Defines an interface for a text system.
	/// </summary>
	public interface ITextSystem
	{
		void Initialize();
		void Draw(int x, int y, string text, string fontName = null);
		IFont GetFont(string fontName = null);
	}
}
