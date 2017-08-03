namespace Snake.Framework.Geometry
{
    public struct IntRectangle
    {
        private readonly int left;
        private readonly int top;
        private readonly int right;
        private readonly int bottom;

        public IntRectangle(int left, int top, int right, int bottom)
        {
            this.left = left;
            this.top = top;
            this.right = right;
            this.bottom = bottom;
        }

        public int Left
        {
            get
            {
                return left;
            }
        }

        public int Top
        {
            get
            {
                return top;
            }
        }

        public int Right
        {
            get
            {
                return right;
            }
        }

        public int Bottom
        {
            get
            {
                return bottom;
            }
        }
    }
}