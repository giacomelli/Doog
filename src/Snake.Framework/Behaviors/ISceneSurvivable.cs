namespace Snake.Framework
{
	/// <summary>
	/// Defines an interface for a component that can survive when scene change happens.
	/// </summary>
	public interface ISceneSurvivable
	{
		bool CanSurvive(IScene fromScene, IScene toScene);
	}
}