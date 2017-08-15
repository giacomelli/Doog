using System;
using Snake.Framework;
using Snake.Framework.Animations;
using Snake.Framework.Geometry;

namespace Snake.Game.Scenes
{
    public class TestScene : SceneBase
    {
        public TestScene(IWorldContext context)
            : base (context)
        {
        }    
        
        public override void Initialize()
        {
            Context.RemoveAllComponents();

            // Sample 1.
            var food1 = new Food(Context);
            food1.Transform.Position = new Point(1, 10);
            food1
                .Animate("MoveTo", new PositionTween(food1.Transform, new Point(10, 0), 5))
                .PingPong();
            
            // Sample 2.
			var food2 = new Food(Context);
            food2.Transform.Position = new Point(1, 11);
            food2.Transform
                 .MoveTo(10, 20, 5, Easing.Linear)
                 .PingPong();

	    }
    }
}
