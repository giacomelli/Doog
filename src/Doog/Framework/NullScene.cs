namespace Doog
{
    /// <summary> 
    /// A Null object pattern IScene's implementation.
    /// </summary>
    /// <seealso cref="Doog.SceneBase" />
    public class NullScene : SceneBase
	{
        /// <summary>
        /// Initializes a new instance of the <see cref="NullScene"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public NullScene(IWorldContext context)
            : base(context)
        {
		}

        /// <summary>
        /// Draws the instance on the specified draw context.
        /// </summary>
        /// <param name="drawContext">The draw context.</param>
        public override void Draw(IDrawContext drawContext)
        {
       		drawContext.TextSystem.DrawCenter(
				"TIP: You have not set any scene yet. Use the World.OpenScene to open the first scene of your game",
				"Default");
		}
	}
}