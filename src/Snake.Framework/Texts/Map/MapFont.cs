using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Snake.Framework.Geometry;

namespace Snake.Framework.Texts.Map
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
		private Dictionary<string, IntPoint> textsSizeCache = new Dictionary<string, IntPoint>();


		private MapFont()
		{
		}

		public string Name { get; private set; }
		public IntPoint Size { get; private set; }

		public IntPoint GetTextSize(string text)
		{
			if (!textsSizeCache.ContainsKey(text))
			{
				var x = 0;

				Process(
					0,
					0,
					text,
					(cx, cy, c) => { x = cx; });

				textsSizeCache.Add(text, new IntPoint(x, Size.Y));
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
			font.Size = new IntPoint(
				Convert.ToInt32(ReadMetadata(content, 2)),
				Convert.ToInt32(ReadMetadata(content, 3)));

			var currentCharReadLines = 0;

			// Space.
			font.charsData.Add(' ', new List<string> { string.Empty.PadRight(font.Size.X, ' ') });

			for (int i = 4; i < content.Length; i++)
			{
				var line = content[i].TrimEnd();

				if (currentCharReadLines == font.Size.Y)
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

		public void Process(int x, int y, string text, Action<int, int, char> processChar)
		{
			foreach (char c in text.ToUpperInvariant())
			{
				x += Draw(x, y, c, processChar) + 1;
			}
		}

		private int Draw(int x, int y, char c, Action<int, int, char> processChar)
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
