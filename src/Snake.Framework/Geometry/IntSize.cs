namespace Snake.Framework.Geometry
{
    /// <summary>
    /// An immutable integer size.
    /// </summary>
    public struct IntSize
    {
        private readonly int width;
        private readonly int height;

        public IntSize(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        public int Width
        {
            get
            {
                return width;
            }
        }

        public int Height
        {
            get
            {
                return height;
            }
        }
    }
}