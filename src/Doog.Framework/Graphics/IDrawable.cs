namespace Doog.Framework.Graphics
{
    public interface IDrawable : IComponent
    {
        void Draw(IDrawContext drawContext);
    }
}
