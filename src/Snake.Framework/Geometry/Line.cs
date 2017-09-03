namespace Snake.Framework.Geometry
{
    /// <summary>
    /// An immutable line.
    /// </summary>
    public struct Line : ILine
    {
        private readonly Point pointA;
        private readonly Point pointB;
     
        public Line(Point pointA, Point pointB)
        {
            this.pointA = pointA;
            this.pointB = pointB;
        }

        public Line(float pointAX, float pointAY, float pointBX, float pointBY)
            : this (new Point(pointAX, pointAY), new Point(pointBX, pointBY))
        {
        }

		public Point PointA
		{
			get
			{
				return pointA;
			}
		}

		public Point PointB
		{
			get
			{
				return pointB;
			}
		}
    }
}
