using Snake.Framework.Geometry;

namespace Snake.Framework.Graphics
{
    public interface IGraphicSystem : ICanvas
    {
        void Initialize();
        void Render();
    }
}
