using System;
using Snake.Framework;
using Snake.Framework.Animations;
using Snake.Framework.Geometry;

namespace Snake.Game.Scenes
{
    public class TestScene : SceneBase
    {
        public override void Initialize(IWorldContext worldContext)
        {
            worldContext.RemoveAllComponents();

            // Sample 1.
            var food1 = new Food();
            food1
                .Animate("MoveTo", new FloatTween(1, 10, 5, worldContext, (v) => food1.Transform.Position = new Point(v, 10)), worldContext)
                .PingPong();

            worldContext.AddComponent(food1);

            // Sample 2.
			var food2 = new Food();
            food2.Transform.Position = new Point(1, 11);
            food2.Transform
                 .MoveTo(10, 20, 5, Easing.Linear, worldContext)
                 .PingPong();

			worldContext.AddComponent(food2);
        }
    }
}
