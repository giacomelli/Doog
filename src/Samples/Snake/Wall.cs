using Doog;

namespace Snake
{
    public class Wall : RectangleComponent, IDrawable, ICollidable
    {
        private Wall(float x, float y, IWorldContext context)
            : base(x, y, context)
        {
            Pixel = Pixel.DarkGray;
        }

        public static Wall Create(float x, float y, float scaleX, float scaleY, IWorldContext context)
        {
            var wall = new Wall((int)x, (int)y, context);
            wall.Transform.Scale = new Point(scaleX, scaleY);

            return wall;
        }

        public void OnCollision(Collision collision)
        {
        }
    }
}
