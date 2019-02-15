namespace Doog
{
    /// <summary>
    /// Defines an interface for an object that can be draw in the canvas.
    /// </summary>
    public interface IPixelable : IComponent
    {
        /// <summary>
        /// Gets or sets the pixel.
        /// </summary>
        Pixel Pixel { get; set; }
    }
}
