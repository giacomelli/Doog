using System;
namespace Snake.Framework.Geometry
{
    public static class TransformExtensions
    {
        public static Transform CentralizePivot(this Transform transform)
        {
            transform.Pivot = Point.HalfOne;

            return transform;
        }
    }
}
