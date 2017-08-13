using System;
using System.Collections.Generic;

namespace Snake.Framework
{
    public abstract class ComponentBase : IComponent
    {
        private bool enabled;
        private IList<IComponent> children;

        protected ComponentBase()
        {
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

        public void AddChild(IComponent component, IWorldContext worldContext)
        {
            children.Add(component);
            worldContext.AddComponent(component);
        }

        public IEnumerable<IComponent> GetChildren()
        {
            return children;
        }
    }
}
