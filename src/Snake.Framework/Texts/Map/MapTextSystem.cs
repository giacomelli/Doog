using System;
using System.Collections.Generic;
using System.IO;
using Snake.Framework.Graphics;

namespace Snake.Framework.Texts.Map
{
	/// <summary>
	/// An ITextSystem implementation that use fonts from map files.
	/// </summary>
	public class MapTextSystem : ITextSystem
	{
		private IGraphicSystem graphicSystem;
		private Dictionary<string, MapFont> fonts = new Dictionary<string, MapFont>();
		private string defaultFontName;

		public MapTextSystem(IGraphicSystem graphicSystem, string defaultFontName)
		{
			this.graphicSystem = graphicSystem;
			this.defaultFontName = defaultFontName;
		}

		public void Initialize()
		{
			var fontsFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources/Fonts");
			var fontsFiles = Directory.GetFiles(fontsFolder, "*.txt");

			foreach (var ff in fontsFiles)
			{
				var font = MapFont.LoadFromFile(ff);

				fonts.Add(font.Name, font);
			}
		}

		public void Draw(float x, float y, string text, string fontName = null)
		{
			((MapFont)GetFont(fontName)).Process(
				x,
				y,
				text,
				(cx, cy, c) => graphicSystem.Draw(cx, cy, c));
		}

		public IFont GetFont(string fontName = null)
		{
			fontName = fontName ?? defaultFontName;

			if (fonts.ContainsKey(fontName))
			{
				return fonts[fontName];
			}

			throw new ArgumentException(
				"There is no font with name '{0}'. Please, verify if the file Reosurces/Fonts/{0}.txt exists".With(fontName),
				"fontName");
		}
	}
}