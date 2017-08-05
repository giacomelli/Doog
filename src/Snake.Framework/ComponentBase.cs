namespace Snake.Framework
{
    public abstract class ComponentBase : IComponent
    {
        protected ComponentBase()
        {
            Enabled = true;
			Tag = GetType().Name;
        }

        public bool Enabled { get; set; }
		public string Tag { get; protected set; }
    }
}
