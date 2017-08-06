using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Snake.Framework.Graphics;

namespace Snake.Runners.Console
{
	public class Font
	{
		private Dictionary<char, List<string>> charsData = new Dictionary<char, List<string>>();

		private Font()
		{
		}

		public string Name { get; private set; }
		public string Url { get; private set; }
		public int Width { get; private set; }
		public int Height { get; private set; }

		public static Font LoadFromFile(string fileName)
		{
			var font = new Font();
			var content = File.ReadLines(fileName).ToArray();
			var currentChar = '!';
			var currentCharData = new List<string>();

			// METADATA
			// Name: 
			// Url:
			// Width:
			// Height:
			font.Name = ReadMetadata(content, 0);
			font.Url = ReadMetadata(content, 1);
			font.Width = Convert.ToInt32(ReadMetadata(content, 2));
			font.Height = Convert.ToInt32(ReadMetadata(content, 3));

			var currentCharReadLines = 0;

			// Space.
			font.charsData.Add(' ', new List<string> { string.Empty.PadRight(font.Width, ' ') });

			for (int i = 4; i < content.Length; i++)
			{
				var line = content[i].TrimEnd();

				if (currentCharReadLines == font.Height)
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
