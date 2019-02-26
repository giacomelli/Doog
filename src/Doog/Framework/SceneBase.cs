namespace Doog
{
    /// <summary>
    /// A base classe for scenes.
    /// </summary>
	public abstract class SceneBase : ComponentBase, IScene
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SceneBase"/> class.
        /// </summary>
        /// <param name="context">The world context.</param>
        protected SceneBase(IWorldContext context)
            : base(context, false)
        {

        }

        /// <summary>
        /// Initialize the scene.
        /// </summary>
        /// <remarks>
        /// Here is where the scene should decide which world components should be kept, which ones should be removed
        /// and which ones should be added the the world context.
        /// </remarks>
        public virtual void Initialize()
        {
        }

        /// <summary>
        /// Draws the instance on the specified draw context.
        /// </summary>
        /// <param name="drawContext">The draw context.</param>
        public virtual void Draw(IDrawContext drawContext)
        {
        }

        /// <summary>
        /// Update this instance.
        /// </summary>
        public virtual void Update()
        {
        }
	}
}