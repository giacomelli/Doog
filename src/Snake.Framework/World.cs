using System;
using System.Collections.Generic;
using System.Linq;
using Snake.Framework.Behaviors;
using Snake.Framework.Geometry;
using Snake.Framework.Graphics;
using Snake.Framework.Logging;
using Snake.Framework.Physics;
using Snake.Framework.Texts;

namespace Snake.Framework
{
	/// <summary>
	/// Responsible to control the game loop flow.
	/// </summary>
	public class World : IWorld
	{
		private IDrawContext drawContext;
		private IList<IUpdatable> updatables;
		private IList<IDrawable> drawables;
		private int updatablesCount;
		private int drawablesCount;
		private IList<IComponent> componentsToRemove;
		private IScene pendingSceneToOpen;
        private Time time;

		public virtual void Initialize(IGraphicSystem graphicSystem, IPhysicSystem physicSystem, ITextSystem textSystem)
		{
			Components = new List<IComponent>();
			componentsToRemove = new List<IComponent>();
			updatables = new List<IUpdatable>();
			drawables = new List<IDrawable>();

            time = new Time();
			pendingSceneToOpen = new NullScene(this);

			graphicSystem.Initialize();
			drawContext = new DrawContext(graphicSystem);
			GraphicSystem = graphicSystem;

			Bounds =  Bounds == Rectangle.Zero ? graphicSystem.Bounds : Bounds;
			PhysicSystem = physicSystem;

			textSystem.Initialize();
			TextSystem = textSystem;

            LogSystem = new NullLogSystem();
		}

		public IScene CurrentScene { get; private set; }

		public Rectangle Bounds { get; protected set; }

        public ITime Time
        {
            get
            {
                return time;
            }
        }

		public IGraphicSystem GraphicSystem { get; private set; }

		public IPhysicSystem PhysicSystem { get; private set; }

		public ITextSystem TextSystem { get; private set; }

        public ILogSystem LogSystem { get; set; }

		public IList<IComponent> Components { get; private set; }

		public void AddComponent(IComponent component)
		{
           	Components.Add(component);

			var u = component as IUpdatable;

			if (u != null)
			{
				updatables.Add(u);
			}

			var d = component as IDrawable;

			if (d != null)
			{
				drawables.Add(d);
			}

			var c = component as ICollidable;

			if (c != null)
			{
				PhysicSystem.AddCollidable(c);
			}
		}

		public void RemoveComponent(IComponent component)
		{
			// TODO: maybe we should use another property (removed?) to mark a object to be removed.
			component.Enabled = false;
			componentsToRemove.Add(component);
		}

		public void OpenScene(IScene scene)
		{
			pendingSceneToOpen = scene;
		}

		private void OpenSceneIfPending(DateTime now)
		{
			if (pendingSceneToOpen != null)
			{
                LogSystem.Debug("WORLD: opening scene {0}", pendingSceneToOpen.GetType().Name);

				// Time.
				if (time.SinceGameStart <= float.Epsilon)
				{
					time.MarkAsGameStarted(now);
				}

				time.MarkAsSceneStarted(now);
                time.Update(now);

				// Call new scene initialization, in this moment the scene decide which components will be kept
				// on world and wich objects will be removed.
				pendingSceneToOpen.Initialize();

				// Remove the scene survivors from components to remove.
				var sceneSurvivables = componentsToRemove
					.Where(c => (c is ISceneSurvivable) && ((ISceneSurvivable)c).CanSurvive(CurrentScene, pendingSceneToOpen));
				sceneSurvivables.EnableAll();
				componentsToRemove = componentsToRemove.Except(sceneSurvivables).ToList();

				// Remove the components selected by the scene to be removed from world.
				foreach (var c in componentsToRemove)
				{
					Components.Remove(c as IComponent);
					updatables.Remove(c as IUpdatable);
					drawables.Remove(c as IDrawable);
					PhysicSystem.RemoveCollidable(c as ICollidable);
				}

				componentsToRemove.Clear();

				// Change the current world scene.
				CurrentScene = pendingSceneToOpen;

				pendingSceneToOpen = null;

                LogSystem.Debug("WORLD: scene opened");
			}
            else 
            {
                time.Update(now);
            }
		}

		public void Update(DateTime now)
		{
			OpenSceneIfPending(now);
			CurrentScene.Update();

			updatablesCount = updatables.Count;
			drawablesCount = drawables.Count;

            IUpdatable current;

			for (int i = 0; i < updatablesCount; i++)
			{
                current = updatables[i];

				if (current.Enabled)
				{
					current.Update();
				}
			}

			PhysicSystem.Update();
		}

		public void Draw()
		{
		    IDrawable current;

			for (int i = 0; i < drawablesCount; i++)
			{
                current = drawables[i];

				if (current.Enabled)
				{
					current.Draw(drawContext);
				}
			}

			CurrentScene.Draw(drawContext);

			GraphicSystem.Render();
		}
	}
}
