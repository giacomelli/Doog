namespace Snake.Framework.Geometry
{
    /// <summary>
    /// An immutable integer rectangle.
    /// </summary>
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

        public bool Contains(int x, int y)
        {
            return !(x < left ||
                    x > right ||
                    y < top ||
                    y > bottom);
        }
    }
}