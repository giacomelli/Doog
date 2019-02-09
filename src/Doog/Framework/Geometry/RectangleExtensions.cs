using System;
using Doog;

/// <summary>
/// Rectangle extension methods.
/// </summary>
public static class RectangleExtensions
{
    public static Point RandomPoint(this Rectangle rect)
    {
        return new Point(
            rect.Left + 1f.Rand() * rect.Width,
            rect.Top + 1f.Rand() * rect.Height);
    }

    public static Point LeftTopPoint(this Rectangle rect)
    {
        return new Point(rect.Left, rect.Top);
    }

    public static Point RightTopPoint(this Rectangle rect)
    {
        return new Point(rect.Right, rect.Top);
    }

    public static Point RightCenterPoint(this Rectangle rect)
    {
        return new Point(rect.Right, rect.Top + rect.Height / 2);
    }

    public static Point RightBottomPoint(this Rectangle rect)
    {
        return new Point(rect.Right, rect.Bottom);
    }

    public static Point LeftBottomPoint(this Rectangle rect)
    {
        return new Point(rect.Left, rect.Bottom);
    }

    public static Point LeftCenterPoint(this Rectangle rect)
    {
        return new Point(rect.Left, rect.Top + rect.Height / 2);
    }

    public static Point BottomCenterPoint(this Rectangle rect)
    {
        return new Point(rect.Left + rect.Width / 2f, rect.Bottom);
    }

    public static Point TopCenterPoint(this Rectangle rect)
    {
        return new Point(rect.Left + rect.Width / 2f, rect.Top);
    }

    public static bool Contains(this Rectangle rect, float x, float y)
    {
        return rect.Contains(new Point(x, y));
    }

    public static bool IsXBorder(this Rectangle rect, float x)
    {
        return x.EqualsTo(rect.Left) || (x >= rect.Right && x <= rect.Right);
    }

    public static bool IsYBorder(this Rectangle rect, float y)
    {
        return y.EqualsTo(rect.Top) || (y >= rect.Bottom && y <= rect.Bottom);
    }

    public static bool IsBorder(this Rectangle rect, float x, float y)
    {
        return rect.IsXBorder(x) || rect.IsYBorder(y);
    }

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
          
                // TODO: look for a better way to do this.
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

