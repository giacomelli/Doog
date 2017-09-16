using Doog.Framework;

namespace Doog.Framework
{
    public interface IDrawContext
    {
        ICanvas Canvas { get; }
		ITextSystem TextSystem { get; }

	}
}