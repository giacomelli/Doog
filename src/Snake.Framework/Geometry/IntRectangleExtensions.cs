using System;

namespace Snake.Framework.Geometry
{
	/// <summary>
	/// IntRectangle extension methods.
	/// </summary>
	public static class IntRectangleExtensions
	{
		private static readonly Random rnd = new Random(DateTime.UtcNow.Millisecond);

		public static IntPoint RandomIntPoint(this IntRectangle rect)
		{
			return new IntPoint(
					rnd.Next(rect.Left, rect.Right),
					rnd.Next(rect.Top, rect.Bottom)
				);
		}

		public static bool Contains(this IntRectangle rect, IntPoint point)
		{
			return rect.Contains(point.X, point.Y);
		}
	}
}