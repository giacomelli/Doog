using System;
using Snake.Framework.Graphics;

namespace Snake.Framework
{
    /// <summary>
    /// A base classe for scenes.
    /// </summary>
	public abstract class SceneBase : ComponentBase, IScene
	{
		public virtual void Initialize(IWorldContext worldContext)
		{
		}

		public virtual void Draw(IDrawContext context)
		{
			
		}

		public virtual void Update(IWorldContext context)
		{
			
		}
	}
}