using Doog;

namespace Breakout
{
    public class Wall : RectangleComponent, IDrawable, ICollidable
    {
        private Wall(float x, float y, IWorldContext context)
            : base(x, y, context)
        {
            Pixel = Pixel.DarkGray;
        }

        public static Wall Create(float x, float y, float scaleX, float scaleY, IWorldContext context, string tag = null)
        {
            var wall = new Wall((int)x, (int)y, context);
            wall.Transform.Scale = new Point(scaleX, scaleY);
			if (tag != null)
			{
				wall.Tag = tag;
			}

            return wall;
        }

        public void OnCollision(Collision collision)
        {
			if (collision.Other.Tag != "Wall" && collision.Other.Tag != "Paddle")
			{

			}
        }
    }
}
