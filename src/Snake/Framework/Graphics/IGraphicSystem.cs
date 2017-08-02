using Snake.Framework.Geometry;

namespace Snake.Framework.Graphics
{
    public interface IGraphicSystem
    {
        void Initialize();
        IntRectangle Bounds { get; }
        void Draw(int x, int y, char sprite);
        void Render();
    }
}
