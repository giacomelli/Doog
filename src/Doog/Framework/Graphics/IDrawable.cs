namespace Doog
{
    public interface IDrawable : IComponent
    {
        void Draw(IDrawContext drawContext);
    }
}
