using System;
using Snake.Framework;
using Snake.Framework.Animations;
using Snake.Framework.Geometry;
using Snake.Framework.Graphics;

namespace Snake.Game.Scenes
{
    public class Test2Scene : SceneBase
    {
        public Test2Scene(IWorldContext context)
            : base(context)
        {
        }

        public override void Initialize()
        {
            Context.RemoveAllComponents();

            var center = Context.Bounds.GetCenter();
            var rightBottom = Context.Bounds.RightBottomPoint();
            var wall = Wall.Create(center.X, center.Y, Context);

            wall.Transform
                .ScaleTo(new Point(40, 20), 1, Easing.Linear)
                .MoveTo(new Point(1, 1), 1, Easing.Linear)
				.MoveTo(rightBottom, 1, Easing.Linear)
                .PingPong();
        }

    }
}
