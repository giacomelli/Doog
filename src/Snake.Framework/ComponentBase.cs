using System;
using System.Collections.Generic;

namespace Snake.Framework
{
    public abstract class ComponentBase : IComponent
    {
        private bool enabled;
        private IList<IComponent> children;

        protected ComponentBase(IWorldContext context)
        {
            Context = context;
            enabled = true;
			Tag = GetType().Name;
            children = new List<IComponent>();
        }

        public virtual bool Enabled
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

                    foreach(var child in children)
                    {
                        child.Enabled = value;
                    }
                }
            }
        }

		public string Tag { get; protected set; }
        public IWorldContext Context { get; private set; }

        public void AddChild(IComponent component)
        {
            children.Add(component);
            Context.AddComponent(component);
        }

        public IEnumerable<IComponent> GetChildren()
        {
            return children;
        }
    }
}
