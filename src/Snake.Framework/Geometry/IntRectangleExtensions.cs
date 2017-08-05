using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snake.Framework.Geometry
{
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
    }
}
