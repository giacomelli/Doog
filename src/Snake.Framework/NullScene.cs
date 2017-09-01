using Snake.Framework.Graphics;

namespace Snake.Framework
{
	public class NullScene : SceneBase
	{
		public NullScene(IWorldContext context)
            : base(context)
        {
		}

        public override void Draw(IDrawContext drawContext)
        {
       		drawContext.TextSystem.DrawCenter(
				"TIP: You have not set any scene yet. Use the World.OpenScene to open the first scene of your game",
				"Default");
		}
	}
}