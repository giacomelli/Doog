using System;

namespace Doog.Framework
{
    /// <summary>
    /// Line extension methods.
    /// </summary>
    public static class LineExtensions
    {
        // https://en.wikipedia.org/wiki/Line_drawing_algorithm
        // https://en.wikipedia.org/wiki/Bresenham%27s_line_algorithm
        // https://stackoverflow.com/a/11683720/956886
        public static void Iterate(this ILine line, Action<float, float> step)
        {
            var pointA = line.PointA;
            var pointB = line.PointB;

            var x = (int)Math.Round(line.PointA.X);
            var x2 = (int)Math.Round(line.PointB.X);
            var y = (int)Math.Round(line.PointA.Y);
            var y2 = (int)Math.Round(line.PointB.Y);

            int w = x2 - x;
            int h = y2 - y;
            int dx1 = 0, dy1 = 0, dx2 = 0, dy2 = 0;

            if (w < 0) dx1 = -1; else if (w > 0) dx1 = 1;
            if (h < 0) dy1 = -1; else if (h > 0) dy1 = 1;
            if (w < 0) dx2 = -1; else if (w > 0) dx2 = 1;

            int longest = Math.Abs(w);
            int shortest = Math.Abs(h);

            if (!(longest > shortest))
            {
                longest = Math.Abs(h);
                shortest = Math.Abs(w);
                if (h < 0) dy2 = -1; else if (h > 0) dy2 = 1;
                dx2 = 0;
            }

            int numerator = longest >> 1;

            for (int i = 0; i <= longest; i++)
            {
                step(x, y);

                numerator += shortest;

                if (!(numerator < longest))
                {
                    numerator -= longest;
                    x += dx1;
                    y += dy1;
                }
                else
                {
                    x += dx2;
                    y += dy2;
                }
            }
        }
    }
}