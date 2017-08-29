namespace Snake.Framework.Geometry
{
    /// <summary>
    /// An immutable circle.
    /// </summary>
    public struct Circle : ICircle
    {
		private readonly float x;
		private readonly float y;
        private readonly float radius;

        public Circle(Point point, float radius)
            : this(point.X, point.Y, radius)
        {
        }

        public Circle(float x, float y, float radius)
        {
            this.x = x;
            this.y = y;
            this.radius = radius;
        }

		public float X
		{
			get
			{
				return x;
			}
		}

		public float Y
		{
			get
			{
				return y;
			}
		}

        public float Radius 
        {
            get
            {
                return radius;
            }
        }
    }
}
