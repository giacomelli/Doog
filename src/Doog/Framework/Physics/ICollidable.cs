namespace Doog
{
    /// <summary>
    /// Defines an interface for collidable objects in the phisycs system.
    /// </summary>
    /// <seealso cref="Doog.IComponent" />
    public interface ICollidable : IComponent
    {
        /// <summary>
        /// Gets the transform.
        /// </summary>
        Transform Transform { get; }

        /// <summary>
        /// Called when some collidable collides with this instance.
        /// </summary>
        /// <param name="collision">The collision.</param>
        void OnCollision(Collision collision);
    }
}
