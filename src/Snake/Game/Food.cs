using Snake.Framework;
using Snake.Framework.Geometry;
using Snake.Framework.Graphics;
using Snake.Framework.Physics;

namespace Snake.Game
{
	public class Food : RectangleComponent, IDrawable, ICollidable
	{
		public Food(IWorldContext context)
            : base(0, 0, context)
		{
            Sprite = 'o';
		}

  		public void OnCollision(Collision collision)
		{
            if (collision.Other.Tag != "Food")
            {
                Enabled = false;
            }
		}

        protected override void OnEnabled()
        {
            base.OnEnabled();
            Transform.Enabled = true;
        }

        protected override void OnDisabled()
        {
            base.OnDisabled();
            Transform.Enabled = false;
        }
	}
}
