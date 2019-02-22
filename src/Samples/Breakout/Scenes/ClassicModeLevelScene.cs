using Doog;
using Breakout.Commands;

namespace Breakout.Scenes
{
    public class ClassicModeLevelScene : SceneBase
    {
        private const int MaxBreakouts = 1;
		private BallSpawner ballSpawner;
    
        public ClassicModeLevelScene(IWorldContext context)
            : base(context)
        {

        }

        public override void Initialize()
        {
            Context.RemoveAllComponents();
            var bounds = Context.GraphicSystem.Bounds;
            var center = bounds.GetCenter();

            // Create the walls.
            var wallSpawner = new WallSpawner(Context);
            wallSpawner.Spawn();

			var paddle = new Paddle(Context, new KeyboardCommandReader(Context.InputSystem, KeyBinding.Default));
			paddle.Initialize(100.0f);

            ballSpawner = BallSpawner.Create(Context);
			ballSpawner.Spawn();

            bounds = Context.Bounds;

            // Score.
            // TODO: now it is prepared to only one Breakout.
            // We must decide if only one Score will show all Breakouts scores (as list)
            // or each Breakout will have its own score instance.
            // Score.Create(new Point(bounds.Right, bounds.Top), paddle, Context);
        }

        public void ChangeToGameOver()
        {
            Context.OpenScene<GameOverScene>();
        }
    }
}
