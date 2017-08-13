using Snake.Framework.Graphics;

namespace Snake.Framework
{
    /// <summary>
    /// A base classe for scenes.
    /// </summary>
	public abstract class SceneBase : ComponentBase, IScene
    {
        protected SceneBase(IWorldContext context)
            : base(context)
        {

        }

        public virtual void Initialize()
        {
        }

        public virtual void Draw(IDrawContext context)
        {
        }

        public virtual void Update()
        {
        }
    }
}