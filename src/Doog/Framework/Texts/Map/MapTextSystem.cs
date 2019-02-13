using System;
using System.Collections.Generic;
using System.IO;

namespace Doog
{
    /// <summary>
    /// An ITextSystem implementation that use fonts from map files.
    /// </summary>
    public class MapTextSystem : ITextSystem
	{
		private readonly Dictionary<string, MapFont> _fonts = new Dictionary<string, MapFont>();
		private readonly string _defaultFontName;

        /// <summary>
        /// Initializes a new instance of the <see cref="MapTextSystem"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="defaultFontName">Default name of the font.</param>
        public MapTextSystem(IWorldContext context, string defaultFontName)
		{
            this.Context = context;
			this._defaultFontName = defaultFontName;
		}

        /// <summary>
        /// Gets the world context.
        /// </summary>
        public IWorldContext Context { get; private set; }

        /// <summary>
        /// Initialize this instance.
        /// </summary>
        public void Initialize()
		{
			var fontsFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources/Fonts");
			var fontsFiles = Directory.GetFiles(fontsFolder, "*.txt");

			foreach (var ff in fontsFiles)
			{
				var font = MapFont.LoadFromFile(ff);

				_fonts.Add(font.Name, font);
			}
		}

        /// <summary>
        /// Draw the specified text in the x and y coordinate.
        /// </summary>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        /// <param name="text">The text.</param>
        /// <param name="fontName">The font name.</param>
        /// <returns>
        /// The draw.
        /// </returns>
        public ITextSystem Draw(float x, float y, string text, string fontName = null)
		{
			((MapFont)GetFont(fontName)).Process(
				x,
				y,
				text,
				(cx, cy, c) => Context.GraphicSystem.Draw(cx, cy, c));

            return this;
		}

        /// <summary>
        /// Gets the font.
        /// </summary>
        /// <param name="fontName">The font name.</param>
        /// <returns>
        /// The font.
        /// </returns>
        /// <exception cref="ArgumentException">There is no font with name '{0}'. Please, verify if the file Reosurces/Fonts/{0}.txt exists".With(fontName) - fontName</exception>
        public IFont GetFont(string fontName = null)
		{
			fontName = fontName ?? _defaultFontName;

			if (_fonts.ContainsKey(fontName))
			{
				return _fonts[fontName];
			}

			throw new ArgumentException(
				"There is no font with name '{0}'. Please, verify if the file Reosurces/Fonts/{0}.txt exists".With(fontName),
				"fontName");
		}
	}
}