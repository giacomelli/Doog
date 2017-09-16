using Doog.Framework.Geometry;

namespace Doog.Framework.Graphics
{
    public interface IGraphicSystem : ICanvas
    {
        void Initialize();
        void Render();
    }
}
