using Doog;

namespace Snake
{
    public class FoodSpawner : ComponentBase, IUpdatable
    {
        private Food[] foods = new Food[3];
        private IAnimationPipelineController[] animControllers;

        private FoodSpawner(IWorldContext context)
            : base(context)
        {
            animControllers = new IAnimationPipelineController[foods.Length];

            for (int i = 0; i < foods.Length; i++)
            {
                foods[i] = new Food(Context) { Enabled = false };
                animControllers[i] = AnimationPipelineController.Empty;
            }
        }

        public void Update()
        {
			for (int i = 0; i < foods.Length; i++)
			{
                var food = foods[i];

                if (!food.Enabled)
                {
					food.Transform.Scale = Food.DefaultScale;

					do
                    {
                        food.Transform.Position = Context.Bounds.RandomPoint().Round();
                    } while (Context.PhysicSystem.AnyCollision(food));

                    food.Enabled = true;

                    var animContr = animControllers[i];
                    animContr.Destroy();
                  
                    animContr = food.Transform
                        .ScaleTo(Food.DefaultScale.X * 2f, 0.2f, Easing.InBack)
                        .PingPong(1);
                }
            }
        }

        public static FoodSpawner Create(IWorldContext context)
        {
            return new FoodSpawner(context);
        }
    }
}
