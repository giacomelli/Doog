using Snake.Framework.Texts;

namespace Snake.Framework.Graphics
{
    public interface IDrawContext
    {
        ICanvas Canvas { get; }
		ITextSystem TextSystem { get; }

	}
}