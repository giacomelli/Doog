using Doog;

namespace Doog
{
    public interface ICanvas
    {
        Rectangle Bounds { get; }
        void Draw(float x, float y, char sprite);
    }
}
