using Snake.Framework;
using Snake.Framework.Animations;
using Snake.Framework.Geometry;
using Snake.Framework.Graphics;

namespace Snake.Game
{
    public class Score : ComponentBase, IDrawable
    {
        private int points;

        private Score(Snake snake, IWorldContext ctx)
            : base(ctx)
        {
            snake.FoodEaten += delegate
            {
                var effect = new RectangleComponent(snake.Head.Transform.Position, ctx)
                {
                    Sprite = '+'
                };

                effect
                    .Transform
                    .MoveTo(ctx.Bounds.GetCenter().X, Y + 1, .8f, Easing.OutCubic)
                    .Do(() =>
                    {
                        ctx.RemoveComponent(effect);
                        points += 100;
                    })
                    .Once();
            };
        }

        public float Y { get; set; }
 
        public static Score Create(float y, Snake snake, IWorldContext ctx)
        {
            return new Score(snake, ctx)
            {
                Y = y
            };
        }

        public void Draw(IDrawContext context)
        {
            Context.TextSystem
                   .DrawCenterX(Y, "Score: {0:000000}".With(points), "Default");
        }
    }
}
