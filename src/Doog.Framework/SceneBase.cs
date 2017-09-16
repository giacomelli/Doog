using Doog.Framework.Graphics;

namespace Doog.Framework
{
    /// <summary>
    /// A base classe for scenes.
    /// </summary>
	public abstract class SceneBase : ComponentBase, IScene
    {
        protected SceneBase(IWorldContext context)
            : base(context, false)
        {

        }

        public virtual void Initialize()
        {
        }

        public virtual void Draw(IDrawContext drawContext)
        {
        }

        public virtual void Update()
        {
        }
    }
}