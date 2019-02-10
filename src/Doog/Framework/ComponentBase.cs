using System.Collections.Generic;
using System.Diagnostics;

namespace Doog
{
    [DebuggerDisplay("{Tag}")]
    public abstract class ComponentBase : IComponent
    {
        private readonly IList<IComponent> _children;
        private bool _enabled;

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

		protected ComponentBase(IWorldContext context)
            : this(context, true)
		{
		}

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

		public string Tag { get; set; }
        public IWorldContext Context { get; private set; }

        protected ILogSystem Log 
        {
            get
            {
                return Context.LogSystem;    
            }
        }

        public void AddChild(IComponent component)
        {
            _children.Add(component);
        }

        public IEnumerable<IComponent> GetChildren()
        {
            return _children;
        }

        protected virtual void OnEnabled()
        {
            Log.Debug("{0} enabled.", this);
        }

        protected virtual void OnDisabled()
        {
            Log.Debug("{0} disabled.", this);
        }
    }
}
