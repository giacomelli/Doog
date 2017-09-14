namespace Snake.Framework.Texts
{
	/// <summary>
	/// Defines an interface for a text system.
	/// </summary>
	public interface ITextSystem : IFontSystem
	{
        IWorldContext Context { get; }

		void Initialize();
		ITextSystem Draw(float x, float y, string text, string fontName = null);
	}
}
