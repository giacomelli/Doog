namespace Snake.Framework
{
    /// <summary>
    /// Define an interface for components.
    /// </summary>
    public interface IComponent
    {
        bool Enabled { get; set; }
		string Tag { get; }
    }
}
