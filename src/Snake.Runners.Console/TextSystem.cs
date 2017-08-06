using System;
using System.Collections.Generic;
using System.IO;
using Snake.Framework.Graphics;
using Snake.Framework.Texts;
using System.Linq;
using Snake.Framework.Geometry;

namespace Snake.Runners.Console
{
	public class TextSystem : ITextSystem
	{
		private IGraphicSystem graphicSystem;
		private Dictionary<string, Font> fonts = new Dictionary<string, Font>();
		private string defaultFontName;
		private Dictionary<string, IntPoint> textsSizeCache = new Dictionary<string, IntPoint>();

		public TextSystem(IGraphicSystem graphicSystem, string defaultFontName)
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
				var font = Font.LoadFromFile(ff);

				fonts.Add(font.Name, font);
			}
		}

		public void Draw(int x, int y, string text, string fontName = null)
		{
			GetFont(fontName).Process(
				x, 
				y, 
				text, 
				(cx, cy, c) => graphicSystem.Draw(cx, cy, c));
		}

		public IntPoint GetTextSize(string text, string fontName = null)
		{
			if (!textsSizeCache.ContainsKey(text))
			{
				var x = 0;

				var font = GetFont(fontName);
				font.Process(
					0,
					0,
					text,
					(cx, cy, c) => { x = cx; });

				textsSizeCache.Add(text, new IntPoint(x, font.Height));
			}

			return textsSizeCache[text];
		}

		private Font GetFont(string fontName = null)
		{
			fontName = fontName ?? defaultFontName;

			return fonts[fontName];
		}
	}
} 