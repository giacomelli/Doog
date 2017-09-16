using Doog.Framework;

namespace Doog.Framework
{
    public interface IGraphicSystem : ICanvas
    {
        void Initialize();
        void Render();
    }
}
