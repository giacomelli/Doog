using System;

namespace Doog.Framework.Samples
{
    public class MainScene : SceneBase
    {
        public MainScene(IWorldContext context) : base(context)
        {
        }

        public override void Update()
        {
			if (Context.InputSystem.IsKeyDown(Keys.Q))
			{
				Context.Exit();
			}

			Context
				.OpenScene<Sample1Scene>(Keys.D1)
				.OpenScene<Sample2Scene>(Keys.D2)
				.OpenScene<Sample3Scene>(Keys.D3)
				.OpenScene<Sample4Scene>(Keys.D4)
				.OpenScene<Sample5Scene>(Keys.D5)
				.OpenScene<Sample6Scene>(Keys.D6)
				.OpenScene<Sample7Scene>(Keys.D7)
				.OpenScene<Sample8Scene>(Keys.D8)
                .OpenScene<Sample9Scene>(Keys.D9);
        } 

        public override void Draw(IDrawContext drawContext)
        {
            drawContext.TextSystem
                       .DrawCenter("Type 1 to 9 to load the sample scenes", "Default");
        }
    }
}
