using System;

namespace Doog
{
    /// <summary>
    /// Rectangle extension methods.
    /// </summary>
    public static partial class RectangleExtensions
    {
        /// <summary>
        /// Gets a random point from rectangle.
        /// </summary>
        /// <returns>The point.</returns>
        /// <param name="rect">Rect.</param>
        public static Point RandomPoint(this Rectangle rect)
        {
            return new Point(
                rect.Left + 1f.Rand() * rect.Width,
                rect.Top + 1f.Rand() * rect.Height);
        }

        /// <summary>
        /// Gets the left top point.
        /// </summary>
        /// <returns>The left top point.</returns>
        /// <param name="rect">Rect.</param>
        public static Point LeftTopPoint(this Rectangle rect)
        {
            return new Point(rect.Left, rect.Top);
        }

        /// <summary>
        /// Gets the right top point.
        /// </summary>
        /// <returns>The right top point.</returns>
        /// <param name="rect">Rect.</param>
        public static Point RightTopPoint(this Rectangle rect)
        {
            return new Point(rect.Right, rect.Top);
        }

        /// <summary>
        /// Gets the right center point.
        /// </summary>
        /// <returns>The right center point.</returns>
        /// <param name="rect">Rect.</param>
        public static Point RightCenterPoint(this Rectangle rect)
        {
            return new Point(rect.Right, rect.Top + rect.Height / 2);
        }

        /// <summary>
        /// Gets right bottom point.
        /// </summary>
        /// <returns>The right bottom point.</returns>
        /// <param name="rect">Rect.</param>
        public static Point RightBottomPoint(this Rectangle rect)
        {
            return new Point(rect.Right, rect.Bottom);
        }

        /// <summary>
        /// Gets the left bottom point.
        /// </summary>
        /// <returns>The left bottom point.</returns>
        /// <param name="rect">Rect.</param>
        public static Point LeftBottomPoint(this Rectangle rect)
        {
            return new Point(rect.Left, rect.Bottom);
        }

        /// <summary>
        /// Gets the left center point.
        /// </summary>
        /// <returns>The left center point.</returns>
        /// <param name="rect">Rect.</param>
        public static Point LeftCenterPoint(this Rectangle rect)
        {
            return new Point(rect.Left, rect.Top + rect.Height / 2);
        }

        /// <summary>
        /// Gets the bottom center point.
        /// </summary>
        /// <returns>The bottom center point.</returns>
        /// <param name="rect">Rect.</param>
        public static Point BottomCenterPoint(this Rectangle rect)
        {
            return new Point(rect.Left + rect.Width / 2f, rect.Bottom);
        }

        /// <summary>
        /// Gets the top center point.
        /// </summary>
        /// <returns>The top center point.</returns>
        /// <param name="rect">Rect.</param>
        public static Point TopCenterPoint(this Rectangle rect)
        {
            return new Point(rect.Left + rect.Width / 2f, rect.Top);
        }

        /// <summary>
        /// Contains the specified x and y point.
        /// </summary>
        /// <returns>True if contains the specified point.</returns>
        /// <param name="rect">Rect.</param>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        public static bool Contains(this Rectangle rect, float x, float y)
        {
            return rect.Contains(new Point(x, y));
        }

        /// <summary>
        /// Verify if specfied X is the rectangle X border.
        /// </summary>
        /// <returns><c>true</c>, if specfied X is the rectangle X border, <c>false</c> otherwise.</returns>
        /// <param name="rect">Rect.</param>
        /// <param name="x">The x coordinate.</param>
        public static bool IsXBorder(this Rectangle rect, float x)
        {
            return x.EqualsTo(rect.Left) || x.EqualsTo(rect.Right);
        }

        /// <summary>
        /// Verify if specfied Y is the rectangle Y `border.
        /// </summary>
        /// <returns><c>true</c>, if specfied Y is the rectangle Y border, <c>false</c> otherwise.</returns>
        /// <param name="rect">Rect.</param>
        /// <param name="y">The y coordinate.</param>
        public static bool IsYBorder(this Rectangle rect, float y)
        {
            return y.EqualsTo(rect.Top) || y.EqualsTo(rect.Bottom);
        }

        /// <summary>
        /// Verify if specfied point is the rectangle border.
        /// </summary>
        /// <returns><c>true</c>, if specfied point is the rectangle border, <c>false</c> otherwise.</returns>
        /// <param name="rect">Rect.</param>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        public static bool IsBorder(this Rectangle rect, float x, float y)
        {
            return rect.IsXBorder(x) || rect.IsYBorder(y);
        }

        /// <summary>
        /// Iterate the specified rectangle.
        /// </summary>
        /// <param name="rect">The rectangle..</param>
        /// <param name="filled">If set to <c>true</c> filled.</param>
        /// <param name="step">The callback called for each step on iteration.</param>
        // https://stackoverflow.com/a/23561713/956886
        public static void Iterate(this Rectangle rect, bool filled, Action<float, float> step)
        {
            if (rect.Width <= 0 && rect.Height <= 0)
            {
                // Only one point.
                step(rect.Left, rect.Top);
            }
            else if (rect.Height <= 0)
            {
                // Only top line.
                new Line(rect.LeftTop, rect.RightTop)
                    .Iterate(step);
            }
            else if (rect.Width <= 0)
            {
                // Only left line.
                new Line(rect.LeftTop, rect.LeftBottom)
                    .Iterate(step);
            }
            else
            {
                if (filled)
                {
                    var topLine = new Line(rect.LeftTop, rect.RightTop);
                    var bottomLine = new Line(rect.LeftBottom, rect.RightBottom);
                    
                    topLine.Iterate((x1, y1) =>
                    {
                        bottomLine.Iterate((x2, y2) =>
                        {
                            var verticalLine = new Line(x1, y1, x2, y2);
                            verticalLine.Iterate(step);
                        });
                    });
                }
                else
                {
                    var topLine = new Line(rect.LeftTop, rect.RightTop);
                    var rightLine = new Line(rect.RightTop, rect.RightBottom);
                    var bottomLine = new Line(rect.RightBottom, rect.LeftBottom);
                    var leftLine = new Line(rect.LeftBottom, rect.LeftTop);
                    topLine.Iterate(step);
                    rightLine.Iterate(step);
                    bottomLine.Iterate(step);
                    leftLine.Iterate(step);
                }
            }
        }
    }
}