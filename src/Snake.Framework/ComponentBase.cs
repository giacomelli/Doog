using System;
using System.Collections.Generic;
using Snake.Framework.Logging;

namespace Snake.Framework
{
    public abstract class ComponentBase : IComponent
    {
        private IList<IComponent> children;
        private bool enabled;

        protected ComponentBase(IWorldContext context, bool addToContext)
        {
            Context = context;
            enabled = true;
			Tag = GetType().Name;
            children = new List<IComponent>();

            if (addToContext)
            {
                context.AddComponent(this);
            }
        }

		protected ComponentBase(IWorldContext context)
            : this(context, true)
		{
		}

        public bool Enabled
        {
            get 
            {
                return enabled;
            }

            set 
            {
                if(value != enabled)
                {
                    enabled = value;

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
		public string Tag { get; protected set; }
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
            children.Add(component);
        }

        public IEnumerable<IComponent> GetChildren()
        {
            return children;
        }

        protected virtual void OnEnabled()
        {
           
        }

        protected virtual void OnDisabled()
        {
        }
    }
}
