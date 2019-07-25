namespace Doog
{
	/// <summary>
	/// Defines an interface for a component that can survive when scene change happens.
	/// </summary>
	public interface ISceneSurvivable
	{
        /// <summary>
        /// Verify if this instance can survive when scene changes.
        /// </summary>
        /// <returns><c>true</c>, if can survive, <c>false</c> otherwise.</returns>
        /// <param name="fromScene">From scene.</param>
        /// <param name="toScene">To scene.</param>
		bool CanSurvive(IScene fromScene, IScene toScene);
	}
}