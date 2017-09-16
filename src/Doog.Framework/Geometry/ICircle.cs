using System;
namespace Doog.Framework
{
    public interface ICircle
    {
        float Left { get; }
        float Top { get; }
        float Right { get; }
        float Bottom { get; }
        float Radius { get; }

		Point GetCenter();
    }
}
