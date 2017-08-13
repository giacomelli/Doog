namespace Snake.Framework
{
    public abstract class ComponentBase : IComponent
    {
        protected ComponentBase(IWorldContext context)
        {
            Context = context;
            Enabled = true;
			Tag = GetType().Name;
        }

        public bool Enabled { get; set; }
		public string Tag { get; protected set; }
        public IWorldContext Context { get; private set; }
    }
}
