using System;
using Snake.Framework.Behaviors;
using Snake.Framework.Graphics;

namespace Snake.Framework
{
	public interface IScene : IUpdatable, IDrawable
	{
		void Initialize(IWorld world);
	}
}
