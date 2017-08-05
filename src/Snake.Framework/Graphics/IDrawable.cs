namespace Snake.Framework.Graphics
{
    public interface IDrawable : IComponent
    {
        void Draw(IDrawContext context);
    }
}
