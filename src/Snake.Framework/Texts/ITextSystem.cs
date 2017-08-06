using System;
using Snake.Framework.Geometry;

namespace Snake.Framework.Texts
{
	public interface ITextSystem
	{
		void Initialize();
		void Draw(int x, int y, string text, string fontName = null);
		IntPoint GetTextSize(string text, string fontName = null);
	}
}
