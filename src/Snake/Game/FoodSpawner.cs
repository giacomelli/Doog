using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Snake.Framework;
using Snake.Framework.Behaviors;
using Snake.Framework.Geometry;
using Snake.Framework.Graphics;

namespace Snake.Game
{
    public class FoodSpawner : ComponentBase, IUpdatable
    {
        private Rectangle bounds;
        private Food food;

        private FoodSpawner(IWorldContext context)
            :base(context)
        {
            this.bounds = Context.Bounds;
            food = new Food(Context) { Enabled = false };
        }

        public void Update()
        {
            if(!food.Enabled)
            {
				do
				{
					food.Transform.Position = bounds.RandomPoint().Truncate();
				} while (Context.PhysicSystem.AnyCollision(food));

                food.Enabled = true;
            }
        }

        public static FoodSpawner Create(IWorldContext context)
        {
            return new FoodSpawner(context);
        }
    }
}
