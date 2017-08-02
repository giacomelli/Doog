namespace Snake.Game
{
    public class SnakeTile
    {
        public int X { get; set; }

        public int Y { get; set; }

        public SnakeTile Next { get; set; }

        public SnakeTile(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void CopyPosition(SnakeTile other)
        {
            X = other.X;
            Y = other.Y;
        }
    }
}