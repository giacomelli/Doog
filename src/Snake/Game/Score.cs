using Snake.Framework;
using Snake.Framework.Animations;
using Snake.Framework.Geometry;
using Snake.Framework.Graphics;

namespace Snake.Game
{
    public class Score : RectangleComponent, IDrawable
    {
        private int points;

        private Score(Point position, Snake snake, IWorldContext ctx)
            : base(position, ctx)
        {
            snake.FoodEaten += delegate
            {
                var effect = new RectangleComponent(snake.Head.Transform.Position, ctx)
                {
                    Sprite = '+'
                };

                effect
                    .Transform
                    .MoveTo(Transform.Position, 1.2f, Easing.OutCubic)
                    .Do(() =>
                    {
                        ctx.RemoveComponent(effect);
                        points += 100;

                        this.Transform
                            .ScaleTo(30, 3, .3f, Easing.InOutBounce)
                            .PingPong(1);
                    })
                    .Once();
            };

            Filled = true;
            Sprite = '.';
            Transform.Scale = new Point(16, 3);
            Transform.CentralizePivot();
        }

        public static Score Create(Point position, Snake snake, IWorldContext ctx)
        {
            return new Score(position, snake, ctx);
        }

        public override void Draw(IDrawContext context)
        {
            base.Draw(context);
            Context.TextSystem
                   .Draw(Transform.Position.X - 7, Transform.Position.Y - Transform.Pivot.Y, "Score: {0:0000000}".With(points), "Default");
        }
    }
}
