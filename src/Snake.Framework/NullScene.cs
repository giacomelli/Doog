namespace Snake.Framework
{
	public class NullScene : SceneBase
	{
		public override void Update(IWorldContext context)
		{
			context.TextSystem.DrawCenter(
				"TIP: You have not set any scene yet. Use the World.OpenScene to open the first scene of your game",
				context.Bounds,
				"Default");
		}
	}
}