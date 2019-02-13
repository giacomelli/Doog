namespace Doog
{
    /// <summary>
    /// The default IDrawContext's implementation.
    /// </summary>
    /// <seealso cref="Doog.IDrawContext" />
    public class DrawContext : IDrawContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DrawContext"/> class.
        /// </summary>
        /// <param name="canvas">The canvas.</param>
        /// <param name="textSystem">The text system.</param>
        public DrawContext(ICanvas canvas, ITextSystem textSystem)
        {
            Canvas = canvas;
            TextSystem = textSystem;
        }

        /// <summary>
        /// Gets the canvas.
        /// </summary>
        public ICanvas Canvas { get; private set; }

        /// <summary>
        /// Gets the text system.
        /// </summary>
        public ITextSystem TextSystem { get; private set; }
	}
}
