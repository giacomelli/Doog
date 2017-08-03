namespace Snake.Framework.Geometry
{
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

        public int Area
        {
            get
            {
                return width * height;
            }
        }
    }
}