namespace Doog
{
    /// <summary>
    /// Defines an interface for an object that can be draw in the canvas.
    /// </summary>
    public interface IDrawable : IComponent
    {
        /// <summary>
        /// Draws the instance on the specified draw context.
        /// </summary>
        /// <param name="drawContext">The draw context.</param>
        void Draw(IDrawContext drawContext);
    }
}
