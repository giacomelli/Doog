namespace Doog
{
    /// <summary>
    /// Define an interface for a object that holds a Transform.
    /// </summary>
    public interface ITransformable : IComponent
    {
        /// <summary>
        /// Gets the transform.
        /// </summary>
        Transform Transform { get; }
    }
}
