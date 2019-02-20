using System;
using System.Collections.Generic;
using System.Linq;

namespace Doog
{
    /// <summary>
    /// Responsible to control the game loop flow.
    /// </summary>
    public class World : IWorld
	{
		private IDrawContext _drawContext;
		private IList<IUpdatable> _updatables;
		private IList<IDrawable> _drawables;
		private int _drawablesCount;
		private IList<IComponent> _componentsToRemove;
		private IScene _pendingSceneToOpen;
        private Time _time;
        private Action _exitAction;
        private IList<IWorld> _subWorlds;

        /// <summary>
        /// Initializes the specified graphic system.
        /// </summary>
        /// <param name="graphicSystem">The graphic system.</param>
        /// <param name="physicSystem">The physic system.</param>
        /// <param name="textSystem">The text system.</param>
        /// <param name="inputSystem">The input system.</param>
        /// <param name="exitAction">The exit action.</param>
        public virtual void Initialize(
            IGraphicSystem graphicSystem, 
            IPhysicSystem physicSystem, 
            ITextSystem textSystem,
            IInputSystem inputSystem,
            Action exitAction)
		{
			Components = new List<IComponent>();
			_componentsToRemove = new List<IComponent>();
			_updatables = new List<IUpdatable>();
			_drawables = new List<IDrawable>();
            _subWorlds = new List<IWorld>();

            _time = new Time();
			_pendingSceneToOpen = new NullScene(this);

			graphicSystem.Initialize();
			textSystem.Initialize();

			_drawContext = new DrawContext(graphicSystem, textSystem);
			GraphicSystem = graphicSystem;

			Bounds = Bounds == Rectangle.Zero ? graphicSystem.Bounds : Bounds;
			PhysicSystem = physicSystem;

	        LogSystem = new NullLogSystem();           
            FontSystem = textSystem;
            TextSystem = textSystem;
            InputSystem = inputSystem;

            this._exitAction = exitAction;
		}

        /// <summary>
        /// Gets the current scene.
        /// </summary>
        public IScene CurrentScene { get; private set; }

        /// <summary>
        /// Gets the bounds.
        /// </summary>
        public Rectangle Bounds { get; protected set; }

        /// <summary>
        /// Gets the time.
        /// </summary>
        public ITime Time => _time;

        /// <summary>
        /// Gets the graphic system.
        /// </summary>
        public IGraphicSystem GraphicSystem { get; private set; }

        /// <summary>
        /// Gets the input system.
        /// </summary>
        public IInputSystem InputSystem { get; private set; }

        /// <summary>
        /// Gets the physic system.
        /// </summary>
        public IPhysicSystem PhysicSystem { get; private set; }

        /// <summary>
        /// Gets the log system.
        /// </summary>
        public ILogSystem LogSystem { get; set; }

        /// <summary>
        /// Gets the font system.
        /// </summary>
        public IFontSystem FontSystem { get; private set; }

        /// <summary>
        /// Gets the text system.
        /// </summary>
        public ITextSystem TextSystem { get; private set; }

        /// <summary>
        /// Gets the components.
        /// </summary>
        public IList<IComponent> Components { get; private set; }

        /// <summary>
        /// Adds the component.
        /// </summary>
        /// <param name="component">The component.</param>
        public void AddComponent(IComponent component)
		{
           	Components.Add(component);

			var u = component as IUpdatable;

			if (u != null)
			{
				_updatables.Add(u);
			}

			var d = component as IDrawable;

			if (d != null)
			{
				_drawables.Add(d);
			}

			var c = component as ICollidable;

			if (c != null)
			{
				PhysicSystem.AddCollidable(c);
			}
		}

        public void AddSubWorld(IWorld subWorld)
        {
            _subWorlds.Add(subWorld);
        }

        /// <summary>
        /// Removes the component.
        /// </summary>
        /// <param name="component">The component.</param>
        public void RemoveComponent(IComponent component)
		{			
			component.Enabled = false;
			_componentsToRemove.Add(component);
		}

        /// <summary>
        /// Opens the scene.
        /// </summary>
        /// <param name="scene">The scene.</param>
        public void OpenScene(IScene scene)
		{
			_pendingSceneToOpen = scene;
		}

		private void OpenSceneIfPending(DateTime now)
		{
			if (_pendingSceneToOpen != null)
			{
                LogSystem.Debug("WORLD: opening scene {0}", _pendingSceneToOpen.GetType().Name);

				// Time.
				if (_time.SinceGameStart <= float.Epsilon)
				{
					_time.MarkAsGameStarted(now);
				}

				_time.MarkAsSceneStarted(now);
                _time.Update(now);

				// Call new scene initialization, in this moment the scene decide which components will be kept
				// on world and wich objects will be removed.
				_pendingSceneToOpen.Initialize();

				// Remove the scene survivors from components to remove.
				var sceneSurvivables = _componentsToRemove
					.Where(c => (c is ISceneSurvivable) && ((ISceneSurvivable)c).CanSurvive(CurrentScene, _pendingSceneToOpen));
				sceneSurvivables.EnableAll();
				_componentsToRemove = _componentsToRemove.Except(sceneSurvivables).ToList();

				// Remove the components selected by the scene to be removed from world.
				foreach (var c in _componentsToRemove)
				{
					Components.Remove(c);
					_updatables.Remove(c as IUpdatable);
					_drawables.Remove(c as IDrawable);
					PhysicSystem.RemoveCollidable(c as ICollidable);
				}

				_componentsToRemove.Clear();

				// Change the current world scene.
				CurrentScene = _pendingSceneToOpen;

				_pendingSceneToOpen = null;

                LogSystem.Debug("WORLD: scene opened");
			}
            else 
            {
                _time.Update(now);
            }
		}

        /// <summary>
        /// Update the instance.
        /// </summary>
        /// <param name="now">The current real world time.</param>
        public void Update(DateTime now)
		{
			OpenSceneIfPending(now);
			CurrentScene.Update();

			var updatablesCount = _updatables.Count;
			_drawablesCount = _drawables.Count;

            IUpdatable current;

			for (int i = 0; i < updatablesCount; i++)
			{
                current = _updatables[i];

				if (current.Enabled)
				{
					current.Update();
				}
			}

            foreach(var sub in _subWorlds)
            {
                sub.Update(now);
            }

			PhysicSystem.Update();
            InputSystem.Update();
		}

        /// <summary>
        /// Draw this instance on current frame.
        /// </summary>
        public void Draw()
		{
		    IDrawable current;

			for (int i = 0; i < _drawablesCount; i++)
			{
                current = _drawables[i];

				if (current.Enabled)
				{
					current.Draw(_drawContext);
				}
			}

			CurrentScene.Draw(_drawContext);

            foreach (var sub in _subWorlds)
            {
                sub.Draw();
            }

            GraphicSystem.Render();
		}

        /// <summary>
        /// Exit the world.
        /// </summary>
        public void Exit()
        {
            this._exitAction();
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
        }
    }
}
