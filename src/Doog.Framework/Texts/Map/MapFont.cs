using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Doog.Framework.Geometry;

namespace Doog.Framework.Texts.Map
{
	/// <summary>
	/// An IFont implementation that use a map (file) to build the texts.
	/// </summary>
	/// <remarks>
	/// To see the map file format, take a look on existing map font files on Resources/Fonts folder.
	/// </remarks>
	public class MapFont : IFont
	{
		private Dictionary<char, List<string>> charsData = new Dictionary<char, List<string>>();
		private Dictionary<string, Point> textsSizeCache = new Dictionary<string, Point>();


		private MapFont()
		{
		}

		public string Name { get; private set; }
		public Point Size { get; private set; }

		public Point GetTextSize(string text)
		{
			if (!textsSizeCache.ContainsKey(text))
			{
                var x = 0f;

				Process(
					0,
					0,
					text,
					(cx, cy, c) => { x = cx; });

				textsSizeCache.Add(text, new Point(x, Size.Y));
			}

			return textsSizeCache[text];
		}

		public static MapFont LoadFromFile(string fileName)
		{
			var font = new MapFont();
			var content = File.ReadAllLines(fileName).ToArray();
			var currentChar = '!';
			var currentCharData = new List<string>();

			// METADATA
			// Name: 
			// Url:
			// Width:
			// Height:
			font.Name = ReadMetadata(content, 0);
			font.Size = new Point(
				Convert.ToInt32(ReadMetadata(content, 2)),
				Convert.ToInt32(ReadMetadata(content, 3)));

			var currentCharReadLines = 0;

			// Space.
			font.charsData.Add(' ', new List<string> { string.Empty.PadRight((int)font.Size.X, ' ') });

			for (int i = 4; i < content.Length; i++)
			{
				var line = content[i].TrimEnd();

				if (font.Size.Y.EqualsTo(currentCharReadLines))
				{
					font.charsData.Add(currentChar, currentCharData);
					currentChar++;
					currentCharData = new List<string>();
					currentCharReadLines = 0;
				}

				currentCharReadLines++;
				currentCharData.Add(line);
			}

			return font;
		}

		public void Process(float x, float y, string text, Action<float, float, char> processChar)
		{
			foreach (char c in text.ToUpperInvariant())
			{
				x += Draw(x, y, c, processChar);
			}
		}

		private int Draw(float x, float y, char c, Action<float, float, char> processChar)
		{
			var longestLine = 0;

			if (charsData.ContainsKey(c))
			{
				var charData = charsData[c];

				for (int i = 0; i < charData.Count; i++)
				{
					var line = charData[i];

					if (line.Length > longestLine)
					{
						longestLine = line.Length;
					}

					for (int j = 0; j < line.Length; j++)
					{
						processChar(x + j, y + i, line[j]);
					}
				}
			}

			return longestLine;
		}

		private static string ReadMetadata(string[] content, int lineIndex)
		{
			return content[lineIndex].Split(':')[1].Trim();
		}
	}
}
