using Doog;

namespace Doog
{
    public interface IDrawContext
    {
        ICanvas Canvas { get; }
		ITextSystem TextSystem { get; }

	}
}