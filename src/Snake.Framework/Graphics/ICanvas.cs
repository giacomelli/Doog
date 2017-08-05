using Snake.Framework.Geometry;

namespace Snake.Framework.Graphics
{
    public interface ICanvas
    {
        IntRectangle Bounds { get; }
        void Draw(int x, int y, char sprite);
    }
}
