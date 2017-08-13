namespace Snake.Framework
{
	public class NullScene : SceneBase
	{
		public NullScene(IWorldContext context)
            : base(context)
        {
		}

		public override void Update()
		{
			Context.TextSystem.DrawCenter(
				"TIP: You have not set any scene yet. Use the World.OpenScene to open the first scene of your game",
				Context.Bounds,
				"Default");
		}
	}
}