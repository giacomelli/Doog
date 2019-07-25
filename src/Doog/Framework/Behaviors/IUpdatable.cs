namespace Doog
{
	/// <summary>
	/// Defines an interface for an updatable component.
	/// </summary>
	public interface IUpdatable : IComponent
	{
        /// <summary>
        /// Update this instance.
        /// </summary>
		void Update();
	}
}