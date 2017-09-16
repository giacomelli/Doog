using Doog.Framework;

namespace Doog.Framework
{
    public interface ICanvas
    {
        Rectangle Bounds { get; }
        void Draw(float x, float y, char sprite);
    }
}
