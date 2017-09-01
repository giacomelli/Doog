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
                    .MoveTo(Transform.Position, 1f, Easing.OutCubic)
                    .Do(() =>
                    {
                        ctx.RemoveComponent(effect);
                    })
                    .Once();

                this
                    .To(points, points + 10, 1f, Easing.InOutQuint, v => points = (int)v)
                    .Once();
            };

            Transform.CentralizePivot();
        }

        public static Score Create(Point position, Snake snake, IWorldContext ctx)
        {
            var textSize = snake.Context.TextSystem.GetFont().GetTextSize("000000");
            position -= textSize;
            position -= new Point(1, 0);

            return new Score(position, snake, ctx);
        }

        public override void Draw(IDrawContext context)
        {
            Context.TextSystem
                   .Draw(
                       Transform.Position.X,
                       Transform.Position.Y - Transform.Pivot.Y,
                       "{0:000000}".With(points));
        }
    }
}
