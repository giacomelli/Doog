using Doog.Framework.Texts;

namespace Doog.Framework.Graphics
{
    public interface IDrawContext
    {
        ICanvas Canvas { get; }
		ITextSystem TextSystem { get; }

	}
}