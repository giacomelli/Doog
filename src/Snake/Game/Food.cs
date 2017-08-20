using Snake.Framework;
using Snake.Framework.Geometry;
using Snake.Framework.Graphics;
using Snake.Framework.Physics;

namespace Snake.Game
{
	public class Food : ComponentBase, IDrawable, ICollidable
	{
		public Food(IWorldContext context)
            : base(context)
		{
			Transform = new Transform(context);
		}

		public Transform Transform { get; private set; }

		public void Draw(IDrawContext context)
		{
			context.Canvas.Draw(Transform, '$');
		}

		public void OnCollision(Collision collision)
		{
			Enabled = false;
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
