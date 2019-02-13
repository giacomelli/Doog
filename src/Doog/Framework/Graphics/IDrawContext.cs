using Doog;

namespace Doog
{
    /// <summary>
    /// Defines an interface for a draw context.
    /// </summary>
    public interface IDrawContext
    {
        /// <summary>
        /// Gets the canvas.
        /// </summary>
        ICanvas Canvas { get; }

        /// <summary>
        /// Gets the text system.
        /// </summary>
		ITextSystem TextSystem { get; }
	}
}