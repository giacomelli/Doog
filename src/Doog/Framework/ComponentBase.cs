using System.Collections.Generic;
using System.Diagnostics;

namespace Doog
{
    /// <summary>
    /// A component base class.
    /// </summary>
    [DebuggerDisplay("{Tag}")]
    public abstract class ComponentBase : IComponent
    {
        private readonly IList<IComponent> _children;
        private bool _enabled;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Doog.ComponentBase"/> class.
        /// </summary>
        /// <param name="context">The world context.</param>
        /// <param name="addToContext">If set to <c>true</c> the component will be added to context.</param>
        protected ComponentBase(IWorldContext context, bool addToContext)
        {
            Context = context;
            _enabled = true;
			Tag = GetType().Name;
            _children = new List<IComponent>();

            if (addToContext)
            {
                context.AddComponent(this);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Doog.ComponentBase"/> class.
        /// </summary>
        /// <param name="context">The world context.</param>
        protected ComponentBase(IWorldContext context)
            : this(context, true)
		{
		}

        /// <summary>
        /// Removes the component from the its context.
        /// </summary>

		public void Remove()
		{
			Context.RemoveComponent(this);
		}

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:Doog.ComponentBase"/> is enabled.
        /// </summary>
        /// <value><c>true</c> if enabled; otherwise, <c>false</c>.</value>
        public virtual bool Enabled
        {
            get 
            {
                return _enabled;
            }

            set 
            {
                if(value != _enabled)
                {
                    _enabled = value;

                    if (value)
                    {
                        OnEnabled();
                    }
                    else 
                    {
                        OnDisabled();    
                    }
                }    
            }
        }

        /// <summary>
        /// Gets or sets the tag.
        /// </summary>
        /// <value>The tag.</value>
		public string Tag { get; set; }

        /// <summary>
        /// Gets the world context.
        /// </summary>
        /// <value>The context.</value>
        public IWorldContext Context { get; private set; }

        /// <summary>
        /// Gets the log sytem.
        /// </summary>
        /// <value>The log.</value>
        protected ILogSystem Log 
        {
            get
            {
                return Context.LogSystem;    
            }
        }

        /// <summary>
        /// Adds the child to the component,.
        /// </summary>
        /// <param name="component">Component.</param>
        public void AddChild(IComponent component)
        {
            _children.Add(component);
        }

        /// <summary>
        /// Gets the children components.
        /// </summary>
        /// <returns>The children.</returns>
        public IEnumerable<IComponent> GetChildren()
        {
            return _children;
        }

        /// <summary>
        /// Called when component became enabled.
        /// </summary>
        protected virtual void OnEnabled()
        {
            Log.Debug("{0} enabled.", this);
        }

        /// <summary>
        /// Called when component became disabled.
        /// </summary>
        protected virtual void OnDisabled()
        {
            Log.Debug("{0} disabled.", this);
        }
    }
}
