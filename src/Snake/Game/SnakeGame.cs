using System;
using System.Collections;
using System.Collections.Generic;
using Snake.Framework;
using Snake.Framework.Behaviors;
using Snake.Framework.Graphics;
using Snake.Framework.Physics;

namespace Snake.Game
{
    public class SnakeGame : IDisposable
    {
		private const int MaxSnakes = 1;
        private IWorld world;        
        private Snake[] snakes;
        private bool gameOver;
        public void Initialize(IGraphicSystem graphicSystem)
        {
			world = new World(graphicSystem, new PhysicSystem());
			
            // Create the snakes.
            snakes = new Snake[MaxSnakes];

			for (int i = 0; i < MaxSnakes; i++)
			{
				var snake = new Snake();
				snake.Initialize(0, 10 + i, 6, graphicSystem.Bounds, world);
            	snakes[i] = snake;

                world.AddComponent(snake);
			}

            // Create the food spawner.
            world.AddComponent(new FoodSpawner(graphicSystem.Bounds, world));

            gameOver = false;
        }

        public bool GameOver
        {
            get
            {
                return gameOver;
            }
        }

        public void Update()
        {
            CheckGameOver();

            if (!gameOver)
            {
                world.Update();
            }           
        }

        public void Draw()
        {
            world.Draw();
        }

        private bool disposed = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                }

                disposed = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~SnakeGame() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        void IDisposable.Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }

        private void CheckGameOver()
        {
            if (!gameOver)
            {
                for (int i = 0; i < MaxSnakes; i++)
                {
                    var snake = snakes[i];

                    if(snake.IsOutOfBounds() || snake.Dead)
                    {
                        gameOver = true;
                        break;
                    }
                }                
            }
        }
    }
}