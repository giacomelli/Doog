using Doog.Framework.Geometry;

namespace Doog.Framework.Graphics
{
    public interface ICanvas
    {
        Rectangle Bounds { get; }
        void Draw(float x, float y, char sprite);
    }
}
