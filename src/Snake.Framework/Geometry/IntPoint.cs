namespace Snake.Framework.Geometry
{
    public struct IntPoint
    {
        private readonly int x;
        private readonly int y;

        public IntPoint(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int X
        {
            get
            {
                return x;
            }
        }

        public int Y
        {
            get
            {
                return y;
            }
        }
    }
}