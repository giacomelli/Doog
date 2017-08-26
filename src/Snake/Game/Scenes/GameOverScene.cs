using System.Linq;
using System;
using Snake.Framework;
using Snake.Framework.Graphics;
using Snake.Game.Scenes.Samples;

namespace Snake.Game.Scenes
{
    public class GameOverScene : SceneBase
    {
        private int foodEatenCount;

        public GameOverScene(IWorldContext context)
            : base(context)
        {

        }

        public override void Initialize()
        {
            var snakes = Context.Components.Get<Snake>();
            foodEatenCount = snakes.First().FoodsEatenCount;

            Context.RemoveComponentsWithoutTag("Wall");
        }

        public override void Update()
        {
            if (Context.InputSystem.IsKeyDown(Framework.Input.Keys.Enter))
            {
                Context.OpenScene<ClassicModeLevelScene>();
            }
            else if (Context.InputSystem.IsKeyDown(Framework.Input.Keys.D1))
            {
                Context.OpenScene<Sample1Scene>();
            }
            else if (Context.InputSystem.IsKeyDown(Framework.Input.Keys.D2))
            {
                Context.OpenScene<Sample2Scene>();
            }
            else if (Context.InputSystem.IsKeyDown(Framework.Input.Keys.D3))
            {
                Context.OpenScene<Sample3Scene>();
            }
            else if (Context.InputSystem.IsKeyDown(Framework.Input.Keys.D4))
            {
                Context.OpenScene<Sample4Scene>();
            }
        }

        public override void Draw(IDrawContext context)
        {
            Context.TextSystem
                   .DrawCenter("Game over")
			       .DrawCenter(0, 7, "Score: {0}".With(foodEatenCount), "Default");

		}
    }
}