using System;

namespace Snake.Framework.Geometry
{
	/// <summary>
	/// IntRectangle extension methods.
	/// </summary>
	public static class RectangleExtensions
	{
		private static readonly Random rnd = new Random(DateTime.UtcNow.Millisecond);

		public static Point RandomIntPoint(this Rectangle rect)
		{
			return new Point(
                   (float) rnd.NextDouble() * (rect.Right - rect.Left),
                (float) rnd.NextDouble() * (rect.Bottom - rect.Top)
				);
		}

		public static bool Contains(this Rectangle rect, Point point)
		{
			return rect.Contains(point.X, point.Y);
		}
	}
}