using System;
using Snake.Framework.Geometry;
using Snake.Framework;

/// <summary>
/// Rectangle extension methods.
/// </summary>
public static class RectangleExtensions
{
    public static Point RandomPoint(this Rectangle rect)
    {
        return new Point(
            rect.Left + 1f.Rand() * (rect.Width - 1),
            rect.Top + 1f.Rand() * (rect.Height - 1));
    }

    public static Point LeftTopPoint(this Rectangle rect)
    {
        return new Point(rect.Left, rect.Top);
    }

    public static Point RightTopPoint(this Rectangle rect)
    {
        return new Point(rect.Right - 1, rect.Top);
    }

    public static Point RightCenterPoint(this Rectangle rect)
    {
        return new Point(rect.Right - 1, rect.Top + rect.Height / 2);
    }

    public static Point RightBottomPoint(this Rectangle rect)
    {
        return new Point(rect.Right - 1, rect.Bottom - 1);
    }

    public static Point LeftBottomPoint(this Rectangle rect)
    {
        return new Point(rect.Left, rect.Bottom - 1);
    }

    public static Point LeftCenterPoint(this Rectangle rect)
    {
        return new Point(rect.Left, rect.Top + rect.Height / 2);
    }

    public static Point BottomCenterPoint(this Rectangle rect)
    {
        return new Point(rect.Left + rect.Width / 2f, rect.Bottom - 1);
    }

    public static Point TopCenterPoint(this Rectangle rect)
    {
        return new Point(rect.Left + rect.Width / 2f, rect.Top);
    }

    public static bool Contains(this Rectangle rect, Point point)
    {
        return rect.Contains(point.X, point.Y);
    }

    public static bool IsXBorder(this Rectangle rect, float x)
    {
        return x.EqualsTo(rect.Left) || (x >= (rect.Right - 1) && x <= rect.Right);
    }

    public static bool IsYBorder(this Rectangle rect, float y)
    {
        return y.EqualsTo(rect.Top) || (y >= (rect.Bottom - 1) && y <= rect.Bottom);
    }

    public static bool IsBorder(this Rectangle rect, float x, float y)
    {
        return rect.IsXBorder(x) || rect.IsYBorder(y);
    }

    // https://stackoverflow.com/a/23561713/956886
    public static void Iterate(this Rectangle rect, bool filled, Action<float, float> step)
    {        
        if (rect.Width <= 1 && rect.Height <= 1)
        {
            // Only one point.
            step(rect.Left, rect.Top);
        }
        else if (rect.Height <= 1)
        {
            // Only top line.
            new Line(rect.leftTop, rect.rightTop - new Point(1, 0))
                .Iterate(step);
        }
        else if (rect.Width <= 1)
        {
            // Only left line.
            new Line(rect.leftTop, rect.leftBottom - new Point(0, 1))
                .Iterate(step);
        }
        else
        {
            if (filled)
            {
                var topLine = new Line(rect.leftTop, rect.rightTop - new Point(1, 0));
                var bottomLine = new Line(rect.leftBottom - new Point(0, 1), rect.rightBottom - Point.One);
                var currentTopPointIndex = 0;
                var currentBottomPointIndex = 0;

                topLine.Iterate((x1, y1) =>
                {
                    currentBottomPointIndex = 0;

                    bottomLine.Iterate((x2, y2) =>
                    {
                        // TODO: find better way to do this. Maybe add the capacity of pass the start point index to Line.Iterate.
                        if (currentTopPointIndex == currentBottomPointIndex)
                        {
                            var verticalLine = new Line(x1, y1, x2, y2);
                            verticalLine.Iterate(step);
                        }

                        currentBottomPointIndex++;
                    });
                    currentTopPointIndex++;
                });
            }
            else
            {
                var topLine = new Line(rect.leftTop, rect.rightTop - new Point(1, 0));
                var rightLine = new Line(rect.rightTop + new Point(-1, 1), rect.rightBottom - new Point(1, 2));
                var bottomLine = new Line(rect.rightBottom - Point.One, rect.leftBottom - new Point(0, 1));
                var leftLine = new Line(rect.leftBottom - new Point(0, 2), rect.leftTop + new Point(0, 1));
                topLine.Iterate(step);
                rightLine.Iterate(step);
                bottomLine.Iterate(step);
                leftLine.Iterate(step);
            }
        }
    }
}

