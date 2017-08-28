using Snake.Framework;

namespace Snake.Game
{
	public class WallSpawner : ComponentBase
	{
        public WallSpawner(IWorldContext context)
            : base(context)
        {
            
        }

		public void Spawn()
		{
			var bounds = Context.Bounds;

            bounds.Iterate((x, y) =>
            {
				if (bounds.IsBorder(x, y))
				{
					Wall.Create(x, y, Context);
				}
            });
		
		}
	}
}
