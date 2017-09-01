using System;
using Snake.Framework.Geometry;

/// <summary>
/// Rectangle extension methods.
/// </summary>
public static class RectangleExtensions
{
    private static readonly Random rnd = new Random(DateTime.UtcNow.Millisecond);

    public static Point RandomPoint(this Rectangle rect)
    {
        return new Point(
            rect.Left + (float)rnd.NextDouble() * (rect.Right - rect.Left),
            rect.Top + (float)rnd.NextDouble() * (rect.Bottom - rect.Top));
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
        return new Point(rect.Right - 1, rect.Bottom -1);
    }

    public static Point LeftBottomPoint(this Rectangle rect)
    {
        return new Point(rect.Left, rect.Bottom -1);
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

	public static void Iterate(this Rectangle rect, Action<float, float> step, float stepSize = 1f)
    {
        for (var x = rect.Left; x < rect.Right; x += stepSize)
        {
            for (var y = rect.Top; y < rect.Bottom; y += stepSize)
            {
                step(x, y);
            }
        }
    }
}

