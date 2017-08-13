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
        private IntRectangle bounds;
        private Food food;

        public FoodSpawner(IntRectangle bounds, IWorldContext context)
            :base(context)
        {
            this.bounds = bounds;
            food = new Food(context) { Enabled = false };
            context.AddComponent(food);
        }

        public void Update()
        {
            if(!food.Enabled)
            {
				do
				{
					food.Transform.Position = bounds.RandomIntPoint();
				} while (Context.PhysicSystem.AnyCollision(food));

                food.Enabled = true;
            }
        }
    }
}
