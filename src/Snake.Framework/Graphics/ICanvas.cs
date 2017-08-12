using Snake.Framework.Geometry;

namespace Snake.Framework.Graphics
{
    public interface ICanvas
    {
        Rectangle Bounds { get; }
        void Draw(float x, float y, char sprite);
    }
}
