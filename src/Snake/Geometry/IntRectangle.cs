namespace Snake.Geometry
{
    public class IntRectangle
    {
        private int left;
        private int top;
        private int right;
        private int bottom;

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