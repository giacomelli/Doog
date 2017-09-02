using Snake.Framework;
using Snake.Framework.Geometry;
using Snake.Framework.Graphics;
using Snake.Framework.Physics;

namespace Snake.Game
{
    public class Wall : RectangleComponent, IDrawable, ICollidable
    {
        private Wall(float x, float y, IWorldContext context)
            : base(x, y, context)
        {
        }

        public static Wall Create(float x, float y, IWorldContext context)
        {
            return new Wall(x, y, context);
        }

        public void OnCollision(Collision collision)
        {
        }
    }
}
