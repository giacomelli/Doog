namespace Snake.Framework.Texts
{
	/// <summary>
	/// Defines an interface for a text system.
	/// </summary>
	public interface ITextSystem
	{
        IWorldContext Context { get; }

		void Initialize();
		void Draw(float x, float y, string text, string fontName = null);
		IFont GetFont(string fontName = null);
	}
}
