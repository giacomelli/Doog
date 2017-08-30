using Snake.Framework;
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
                points++;
            };
        }

        public float Y { get; set; }
        public override bool Enabled
        {
            get
            {
                return base.Enabled;
            }
            set
            {
                base.Enabled = value;
            }
        }
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
                   .DrawCenterX(Y, "Score: {0}".With(points), "Default");
        }
    }
}
