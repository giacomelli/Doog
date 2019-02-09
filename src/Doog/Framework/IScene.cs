namespace Doog
{
    /// <summary>
    /// Define an interface for scenes.
    /// </summary>
	public interface IScene : IUpdatable, IDrawable
	{
        /// <summary>
        /// Initialize the scene.
        /// </summary>
        /// <remarks>
        /// Here is where the scene should decide which world components should be kept, which ones should be removed
        /// and which ones should be added the the world context.
        /// </remarks>
      	void Initialize();
	}
}
